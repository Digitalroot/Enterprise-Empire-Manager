﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using EEM.Common.Exceptions;
using EEM.Common.Protocol;
using Newtonsoft.Json;

namespace EEM.Common.Adapters
{
  /// <remarks>
  ///   This class is the interface that other code should use to
  ///   get data about LoU. This class looks in the Protocol for how to make a request.
  ///   Sends it to the JsonWebClient. Then uses the Protocol for how to interpret a response.
  ///   Request:
  ///   [Other Code] -> [LoUAdapter + Protocols] -> [MessageExchangeAdapter] -> [JsonWebClient] -> [LoU Server]
  ///   Response:
  ///   [LoU Server] -> [JsonWebClient] -> [MessageExchangeAdapter] -> [LoUAdapter + Protocols] -> [Other Code]
  ///   Example:
  ///   var louClient = new LoUClient();
  ///   var currentWood = louClient.GetWood();
  ///   GetWood() = return louGameServerQuerier.QueryUrlAsAJAXRequest("/Presentation/Service.svc/ajaxEndpoint/Poll", "{w,0}");
  /// </remarks>
  public sealed partial class LoUAdapter : ILoUAdapter
  {
    /// <summary>
    ///   Singleton Instance
    /// </summary>
    private static volatile LoUAdapter _instance;

    /// <summary>
    ///   Lock to make thread safe.
    /// </summary>
    private static readonly object SyncRoot = new Object();

    #region Constructors

    /// <summary>
    ///   Constructor
    /// </summary>
    private LoUAdapter(AdapterConfiguration loUAdapterConfiguration, NetworkCredential credentials)
    {
      TimeService = new TimeService();
      PollingService = new PollingService(TimeService);
      ConnectionState = ConnectionState.Disconnected;
      Credentials = credentials;
      MessageExchangeAdapter = MessageExchangeAdapter.Instance;
      MessageExchangeAdapter.OnServerRequest += MessageExchangeAdapter_OnServerRequest;
      MessageExchangeAdapter.OnServerResponse += MessageExchangeAdapter_OnServerResponse;
      MessageExchangeAdapter.OnServerResponseToQueuedCommand += MessageExchangeAdapter_OnServerResponseToQueuedCommand;
      OnPlayerResponse += LoUAdapter_OnPlayerResponse;
      OnSystemResponse += LoUAdapter_OnSystemResponse;

      Configuration = loUAdapterConfiguration;

      Debug.WriteLine("Configuration:");
      Debug.WriteLine("AuthenticationUrl = {0}", loUAdapterConfiguration.AuthenticationUrl);
      Debug.WriteLine("GameServerUrl = {0}", loUAdapterConfiguration.GameServerUrl);
      Debug.WriteLine("HomePageUrl = {0}", loUAdapterConfiguration.HomePageUrl);
      Debug.WriteLine("SessionUrl = {0}", loUAdapterConfiguration.SessionUrl);
      Debug.WriteLine("email = {0}", credentials.UserName);
      Debug.WriteLine("pass = {0}", credentials.Password);

      PollingService.Polltimer.Tick += polltimer_Tick;

      Cities = new List<City>();
    }

    /// <summary>
    ///   Constructor
    /// </summary>
    private LoUAdapter()
      : this(new AdapterConfiguration(), new NetworkCredential())
    {
    }

    #endregion

    /// <summary>
    ///   Adapter used to pass commands to the LoU servers.
    /// </summary>
    internal readonly MessageExchangeAdapter MessageExchangeAdapter;

    private readonly LoUAdapterDB _loUAdapterDb = new LoUAdapterDB();
    private readonly Hashtable _queuedCityLookupIds = new Hashtable();

    public LoadingScreen LoadingScreen = new LoadingScreen();

    /// <summary>
    ///   Adapter configuration
    /// </summary>
    private AdapterConfiguration _configuration;

    /// <summary>
    ///   Current Connection State.
    /// </summary>
    private ConnectionState _connectionState;

    private City _currentCity;

    /// <summary>
    ///   Adapter configuration
    /// </summary>
    public AdapterConfiguration Configuration
    {
      get { return _configuration; }
      set
      {
        _configuration = value;
        MessageExchangeAdapter.Configuration = value;
        Debug.WriteLine("Configuration:");
        Debug.WriteLine("AuthenticationUrl = {0}", value.AuthenticationUrl);
        Debug.WriteLine("GameServerUrl = {0}", value.GameServerUrl);
        Debug.WriteLine("HomePageUrl = {0}", value.HomePageUrl);
        Debug.WriteLine("SessionUrl = {0}", value.SessionUrl);
      }
    }

    public Player CurrentPlayer { get; private set; }

    /// <summary>
    ///   Username and password for logging into LoU.
    /// </summary>
    private NetworkCredential Credentials { get; set; }

    /// <summary>
    ///   Singleton
    /// </summary>
    public static LoUAdapter Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (SyncRoot)
          {
            if (_instance == null)
              _instance = new LoUAdapter();
          }
        }
        return _instance;
      }
    }

    /// <summary>
    ///   True once we log into LoU
    /// </summary>
    private bool IsAuthenticated { get; set; }

    /// <summary>
    ///   Request Counter.
    /// </summary>
    private int RequestCount { get; set; }

    /// <summary>
    ///   Name of the server we are connected to.
    /// </summary>
    public string ServerName { get; private set; }

    /// <summary>
    ///   Current Session Id
    /// </summary>
    private string SessionId { get; set; }

    public PollingService PollingService { get; private set; }

    public TimeService TimeService { get; private set; }

    /// <summary>
    ///   Current Connection State.
    /// </summary>
    public ConnectionState ConnectionState
    {
      get { return _connectionState; }
      private set
      {
        if (_connectionState != value)
        {
          _connectionState = value;
          ConnectionStateChanged(value);
        }

        switch (value)
        {
          case ConnectionState.Connected:
            PollingService.StartPollTimer();
            break;

          case ConnectionState.Disconnected:
            PollingService.StopPollTimer();
            break;
        }
      }
    }

    /// <summary>
    ///   Current City - Some Actions can only be done from the current city.
    /// </summary>
    public City CurrentCity
    {
      get { return _currentCity; }
      set
      {
        _currentCity = value;
        CurrentCityChanged(value);
      }
    }

    /// <summary>
    ///   List of a players Cities
    /// </summary>
    public List<City> Cities { get; private set; }

    /// <summary>
    ///   Handles logging into LoU.
    /// </summary>
    /// <returns>True if we log into LoU</returns>
    private bool Authenticate()
    {
      if (Credentials == null || string.IsNullOrEmpty(Credentials.UserName) ||
          string.IsNullOrEmpty(Credentials.Password))
      {
        AuthenticationFailed(new ArrayList {"MISSING_USERNAME_OR_PASSWORD"});
        IsAuthenticated = false;
      }

      // Load LoU Home Page to get Cookies
      string result = MessageExchangeAdapter.GetHomePage();

      // Check if we find the session id in the home page. 
      SessionId = GetSessionId(result);

      // If we didn't find the session id
      if (String.IsNullOrEmpty(SessionId))
      {
        // then login via the form with the username and password we have.
        result = MessageExchangeAdapter.Authenticate(Credentials);

        // Find the session id in the result.
        SessionId = GetSessionId(result);

        // if we still don't have a session id we might have a login error. 
        if (String.IsNullOrEmpty(SessionId))
        {
          ArrayList errorMessages = GetErrorMessages(result);
          if (errorMessages.Count > 0)
          {
            OnAuthenticationFailed(errorMessages);
          }
        }
      }

      // Last try. To get the session id. 
      if (String.IsNullOrEmpty(SessionId))
      {
        result = MessageExchangeAdapter.GetSessionPage();
        SessionId = GetSessionId(result);
      }

      // if we now have a session id.
      if (!String.IsNullOrEmpty(SessionId))
      {
        // open the Ajax session
        OpenSessionResponse sessionInfo = OpenSession(SessionId);

        if (sessionInfo != null)
        {
          SessionId = sessionInfo.SessionId;
        }

        if (!String.IsNullOrEmpty(SessionId))
        {
          IsAuthenticated = true;
        }
      }

      return IsAuthenticated;
    }

    /// <summary>
    ///   Raises the onError Event for not being connected.
    /// </summary>
    /// <returns>Returns true if we are connected.</returns>
    private void ErrorIfNotConnected()
    {
      if (ConnectionState == ConnectionState.Disconnected)
      {
        throw new NotConnected();
      }
    }

    /// <summary>
    ///   External Method used to have the LoUAdapter try and connect to LoU.
    /// </summary>
    public void Connect()
    {
      // If we are already connected then do nothing.
      if (ConnectionState == ConnectionState.Connected)
      {
        return;
      }

      if (Authenticate())
      {
        // Load the server webpage
        GetGamePage();

        ServerInfoResponse serverInfo = GetServerInfo();
        ServerName = serverInfo.ServerName;

        GetPlayerResponse playerInfo = GetPlayerInfo();

        if (playerInfo != null)
        {
          CurrentPlayer = new Player(playerInfo);
          SetCities(playerInfo.Cities);
        }

        ConnectionState = ConnectionState.Connected;
      }
    }

    /// <summary>
    ///   External Method is have the LoUAdapter Disconnect.
    /// </summary>
    public void Disconnect()
    {
      // If we are already connected then do nothing.
      if (ConnectionState == ConnectionState.Disconnected)
      {
        return;
      }

      ServerName = String.Empty;
      IsAuthenticated = false;
      RequestCount = 0;
      ConnectionState = ConnectionState.Disconnected;
    }

    /// <summary>
    ///   Reads the Html code returned by the server to find the error messages.
    /// </summary>
    /// <param name="htmlCode"></param>
    /// <returns></returns>
    private static ArrayList GetErrorMessages(string htmlCode)
    {
      using (var stringReader = new StringReader(htmlCode))
      {
        string line;
        var listOfErrors = new ArrayList();
        while ((line = stringReader.ReadLine()) != null)
        {
          if (line.Contains("<ul class=\"errors\">"))
          {
            bool readingErrors = true;
            while (readingErrors)
            {
              string error = stringReader.ReadLine();

              if (error != null)
              {
                error = error.Trim();
                if (error.StartsWith("<li><h2>") && error.EndsWith("</h2></li>"))
                {
                  // We have an error. 
                  listOfErrors.Add(error.Replace("<li><h2>", "").Replace("</h2></li>", ""));
                }
                if (error.Trim() == "</ul>")
                {
                  readingErrors = false;
                }
              }
            }
          }
        }
        return listOfErrors;
      }
    }

    /// <summary>
    ///   Gets the game page for the server after logging in.
    /// </summary>
    /// <returns></returns>
    private string GetGamePage()
    {
      return MessageExchangeAdapter.GetGamePage(SessionId);
    }

    /// <summary>
    ///   Uses the louGameServerQuerier to Query the LoU Home Page.
    /// </summary>
    /// <returns></returns>
    private string GetHomePage()
    {
      return MessageExchangeAdapter.GetHomePage();
    }

    /// <summary>
    ///   Reads the html and pulls the session id out of it.
    /// </summary>
    /// <returns>A Session Id</returns>
    private static string GetSessionId(string result)
    {
      if (!result.Contains("index.aspx?sessionId=") && !result.Contains("SessionId = \"") &&
          !result.Contains("<input type=\"hidden\" name=\"sessionId\" id=\"sessionId\" value=\""))
      {
        Debug.WriteLine("Unable to find (index.aspx?sessionId=) or (SessionId = \") in last HtmlResult.");
        return null;
      }

      var reader = new StringReader(result);
      string line;
      string sessionId = null;
      while ((line = reader.ReadLine()) != null)
      {
        if (!line.Contains("?sessionId=") && !line.Contains("SessionId = \"") &&
            !result.Contains("<input type=\"hidden\" name=\"sessionId\" id=\"sessionId\" value=\"")) continue;

        if (line.Contains("?sessionId="))
        {
          sessionId = line.Substring(line.IndexOf("?sessionId=", StringComparison.Ordinal) + 11, 36);
          Debug.WriteLine("Test: {0}, Session Id found in HTML. Line: {1}", "LoUCloent.GetSessionId", line);
          break;
        }

        if (line.Contains("SessionId = \""))
        {
          sessionId = line.Substring(line.IndexOf("SessionId = \"", StringComparison.Ordinal) + 13, 36);
          Debug.WriteLine("Test: {0}, Session Id found in HTML. Line: {1}", "LoUCloent.GetSessionId", line);
          break;
        }

        if (line.Contains("<input type=\"hidden\" name=\"sessionId\" id=\"sessionId\" value=\""))
        {
          sessionId =
            line.Substring(line.IndexOf("<input type=\"hidden\" name=\"sessionId\" id=\"sessionId\" value=\"", StringComparison.Ordinal) + 60, 36);
          Debug.WriteLine("Test: {0}, Session Id found in HTML. Line: {1}", "LoUCloent.GetSessionId", line);
          break;
        }
      }
      return sessionId;
    }

    /// <summary>
    ///   Handles Errors from Delegates.
    /// </summary>
    /// <param name="method"></param>
    /// <param name="exception"></param>
    private static void HandleDelegateError(MethodInfo method, Exception exception)
    {
      MessageBox.Show(exception.Message, String.Format("Error: {0}", method));
    }

    /// <summary>
    ///   Handles the Response from the LoU Server.
    /// </summary>
    /// <param name="response"></param>
    private void HandlePollResponse(object response)
    {
      var deserializeObject = JsonConvert.DeserializeObject<PollResponse<object>>(response.ToString());

      switch (deserializeObject.C)
      {
        case "ALL_AT":
          ALLATResponse(JsonConvert.DeserializeObject<ALLATResponse>(response.ToString()));
          break;

        case "ALLIANCE":
          //AllianceResponse(JsonConvert.DeserializeObject<AllianceResponse>(response.ToString()));
          break;

        case "CAT": // Do Nothing
          break;

        case "CHAT":
          ChatResponse(JsonConvert.DeserializeObject<ChatResponse>(response.ToString()));
          break;

        case "CITY":
          CityResponse(JsonConvert.DeserializeObject<CityResponse>(response.ToString()));
          break;

        case "FRIENDINV": // Do Nothing
          break;

        case "INV": // Do nothing
          break;

        case "MAIL": // Do Nothing
          break;

        case "PLAYER":
          PlayerResponse(JsonConvert.DeserializeObject<PlayerResponse>(response.ToString()));
          break;

        case "QUEST": // Do Nothing
          break;

        case "REPORT":
          // ReportResponse(JsonConvert.DeserializeObject<ReportResponse>(response.ToString()));
          break;

        case "SERVER": // Do Nothing
          break;

        case "SUBSTITUTION": // Do nothing
          break;

        case "SYS":
          SystemResponse(JsonConvert.DeserializeObject<SysResponse>(response.ToString()));
          break;

        case "TIME": // TIME
          TimeService.Update(JsonConvert.DeserializeObject<TimeResponse>(response.ToString()));
          break;

        case "VERSION":
          VersionResponse(JsonConvert.DeserializeObject<VersionResponse>(response.ToString()));
          break;

        case "VIS": // Vision
          break;

        default:
          Debug.WriteLine("Unknown Response: {0}", response);
          break;
      }
    }

    /// <summary>
    ///   Populates the list of cities.
    /// </summary>
    /// <param name="cities"></param>
    private void SetCities(List<CityResponseToBeFixed> cities)
    {
      if (Cities.Count != cities.Count)
      {
        if (Cities.Count > 0)
        {
          Cities.Clear();
          CurrentCity = null;
        }

        MessageExchangeAdapter.OnServerResponseToQueuedCommand += City_OnServerResponseToQueuedCommand;

        // Queue city look up
        foreach (CityResponseToBeFixed city in cities)
        {
          City dbCity = _loUAdapterDb.Load(city.Id);

          if (dbCity == null)
          {
            // Load from LoU
            _queuedCityLookupIds.Add(QueueGetPublicCityInfo(city.Id), city.Id);
          }
          else
          {
            Cities.Add(dbCity);
          }
        }
      }

      if (CurrentCity == null && Cities.Count > 0)
      {
        CurrentCity = Cities[0];
      }
    }

    private void City_OnServerResponseToQueuedCommand(int id, string message)
    {
      if (_queuedCityLookupIds.Count > 0 && !LoadingScreen.Visible)
      {
        LoadingScreen.labelLoadingInfo.Text = "Loading City Info.";
        LoadingScreen.progressBarLoading.Step = 1;
        LoadingScreen.progressBarLoading.Maximum = _queuedCityLookupIds.Count;
        LoadingScreen.progressBarLoading.Value = 0;
        LoadingScreen.Show();
        LoadingScreen.Refresh();
      }

      if (LoadingScreen.Visible)
      {
        LoadingScreen.progressBarLoading.PerformStep();
      }

      if (_queuedCityLookupIds.ContainsKey(id))
      {
        var newCity = new City(JsonConvert.DeserializeObject<GetPublicCityInfoResponse>(message),
                               (int) _queuedCityLookupIds[id]);
        _queuedCityLookupIds.Remove(id);
        Cities.Add(newCity);
        _loUAdapterDb.Save(newCity);
      }

      if (_queuedCityLookupIds.Count == 0)
      {
        LoadingScreen.Hide();
        MessageExchangeAdapter.OnServerResponseToQueuedCommand -= City_OnServerResponseToQueuedCommand;
      }
    }


    /// <summary>
    ///   Sets the login username and password.
    /// </summary>
    /// <param name="credential"></param>
    public void SetCredentials(NetworkCredential credential)
    {
      Credentials = credential;
      Debug.WriteLine("email = {0}", credential.UserName);
      Debug.WriteLine("pass = {0}", credential.Password);
    }
  }
}