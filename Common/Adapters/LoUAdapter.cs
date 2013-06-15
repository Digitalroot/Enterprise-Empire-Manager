using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using EEM.Common.Protocol;
using Newtonsoft.Json;

namespace EEM.Common.Adapters
{
  /// <remarks>
  /// This class is the interface that other code should use to 
  /// get data about LoU. This class looks in the Protocol for how to make a request. 
  /// Sends it to the JsonWebClient. Then uses the Protocol for how to interpret a response.
  /// 
  /// Request:
  /// [Other Code] -> [LoUAdapter + Protocols] -> [MessageExchangeAdapter] -> [JsonWebClient] -> [LoU Server]
  /// 
  /// Response:
  /// [LoU Server] -> [JsonWebClient] -> [MessageExchangeAdapter] -> [LoUAdapter + Protocols] -> [Other Code]
  /// 
  /// Example: 
  ///   var louClient = new LoUClient();
  ///   var currentWood = louClient.GetWood();
  ///   
  ///   GetWood() = return louGameServerQuerier.QueryUrlAsAJAXRequest("/Presentation/Service.svc/ajaxEndpoint/Poll", "{w,0}");
  /// </remarks>
  public sealed partial class LoUAdapter : ILoUAdapter
  {
    /// <summary>
    /// Adapter configuration
    /// </summary>
    private AdapterConfiguration _configuration;

    /// <summary>
    /// Current Connection State.
    /// </summary>
    private ConnectionState _connectionState;

    /// <summary>
    /// Singleton Instance
    /// </summary>
    private static volatile LoUAdapter _instance;

    /// <summary>
    /// List of Poll request Id's
    /// </summary>
    private readonly List<int> _listOfPollIds = new List<int>();

    /// <summary>
    /// Poll timer
    /// </summary>
    private readonly Timer _polltimer = new Timer { Interval = 10000 };

    /// <summary>
    /// Items included in the poll request.
    /// </summary>
    private readonly Hashtable _pollRequestItems = new Hashtable();

    /// <summary>
    /// Adapter configuration
    /// </summary>
    public AdapterConfiguration Configuration
    {
      get { return _configuration; }
      set
      {
        _configuration = value;
        MessageExchangeAdapter.Configuration = value;
        System.Diagnostics.Debug.WriteLine("Configuration:");
        System.Diagnostics.Debug.WriteLine(String.Format("AuthenticationUrl = {0}", value.AuthenticationUrl));
        System.Diagnostics.Debug.WriteLine(String.Format("GameServerUrl = {0}", value.GameServerUrl));
        System.Diagnostics.Debug.WriteLine(String.Format("HomePageUrl = {0}", value.HomePageUrl));
        System.Diagnostics.Debug.WriteLine(String.Format("SessionUrl = {0}", value.SessionUrl));
      }
    }

    /// <summary>
    /// Current Connection State.
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
            StartPollTimer();
            break;

          case ConnectionState.Disconnected:
            StopPollTimer();
            break;
        }
      }
    }

    /// <summary>
    /// Current City - Some Actions can only be done from the current city.
    /// </summary>
    public City CurrentCity { get; set; }

    /// <summary>
    /// List of a players Cities
    /// </summary>
    public List<City> Cities { get; private set; }

    /// <summary>
    /// Username and password for logging into LoU.
    /// </summary>
    private NetworkCredential Credentials { get; set; }

    /// <summary>
    /// Singleton
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
    /// True once we log into LoU
    /// </summary>
    private bool IsAuthenticated { get; set; }

    /// <summary>
    /// Adapter used to pass commands to the LoU servers.
    /// </summary>
    internal readonly MessageExchangeAdapter MessageExchangeAdapter;

    /// <summary>
    /// Request Counter.
    /// </summary>
    private int RequestCount { get; set; }

    /// <summary>
    /// Name of the server we are connected to.
    /// </summary>
    public string ServerName { get; private set; }

    /// <summary>
    /// Current Session Id
    /// </summary>
    private string SessionId { get; set; }

    /// <summary>
    /// Lock to make thread safe
    /// </summary>
    private static readonly object SyncRoot = new Object();

    #region Constructors

    /// <summary>
    /// Constructor
    /// </summary>
    private LoUAdapter(AdapterConfiguration loUAdapterConfiguration, NetworkCredential credentials)
    {
      ConnectionState = ConnectionState.Disconnected;
      Credentials = credentials;
      MessageExchangeAdapter = MessageExchangeAdapter.Instance;
      MessageExchangeAdapter.OnServerRequest  += MessageExchangeAdapter_OnServerRequest;
      MessageExchangeAdapter.OnServerResponse += MessageExchangeAdapter_OnServerResponse;
      MessageExchangeAdapter.OnServerResponseToQueuedCommand += MessageExchangeAdapter_OnServerResponseToQueuedCommand;
      OnPlayerResponse += LoUAdapter_OnPlayerResponse;

      Configuration = loUAdapterConfiguration;
      
      System.Diagnostics.Debug.WriteLine("Configuration:");
      System.Diagnostics.Debug.WriteLine(String.Format("AuthenticationUrl = {0}", loUAdapterConfiguration.AuthenticationUrl));
      System.Diagnostics.Debug.WriteLine(String.Format("GameServerUrl = {0}", loUAdapterConfiguration.GameServerUrl));
      System.Diagnostics.Debug.WriteLine(String.Format("HomePageUrl = {0}", loUAdapterConfiguration.HomePageUrl));
      System.Diagnostics.Debug.WriteLine(String.Format("SessionUrl = {0}", loUAdapterConfiguration.SessionUrl));
      System.Diagnostics.Debug.WriteLine(String.Format("email = {0}", credentials.UserName));
      System.Diagnostics.Debug.WriteLine(String.Format("pass = {0}", credentials.Password));

      _polltimer.Tick += polltimer_Tick;

      Cities = new List<City>();
    }

    /// <summary>
    /// Constructor
    /// </summary>
    private LoUAdapter()
      : this(new AdapterConfiguration(), new NetworkCredential())
    {}

    #endregion


    /// <summary>
    /// Adds a new value to the poll request items.
    /// If the item already exists then update is called
    /// </summary>
    /// <param name="pollRequestItems"></param>
    /// <param name="value"></param>
    public void AddPollRequestItems(PollRequestItems[] pollRequestItems, string value)
    {
      foreach (PollRequestItems pollRequestItem in pollRequestItems)
      {
        if (_pollRequestItems.ContainsKey(pollRequestItem.ToString()))
        {
          UpdatePollRequestItem(pollRequestItem, value);
        }
        else
        {
          _pollRequestItems.Add(pollRequestItem.ToString(), value);  
        }
      }

      if (!_polltimer.Enabled && _pollRequestItems.Count > 0)
      {
        StartPollTimer();
      }
    }

    /// <summary>
    /// Handles logging into LoU.
    /// </summary>
    /// <returns>True if we log into LoU</returns>
    private bool Authenticate()
    {
      if (Credentials == null || string.IsNullOrEmpty(Credentials.UserName) || string.IsNullOrEmpty(Credentials.Password))
      {
        AuthenticationFailed(new ArrayList {"MISSING_USERNAME_OR_PASSWORD"});
        IsAuthenticated = false;
      }

      // Load LoU Home Page to get Cookies
      var result = MessageExchangeAdapter.GetHomePage();

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
        result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.OpenSession, new JsonRequest(new { session = SessionId }));
        if (result == "0")
        {
          IsAuthenticated = true;
        }
      }

      return IsAuthenticated;
    }

    /// <summary>
    /// Raises the onError Event for not being connected.
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
    /// External Method used to have the LoUAdapter try and connect to LoU.
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
          SetCities(playerInfo.Cities);
        }

        ConnectionState = ConnectionState.Connected;
      }
    }

    /// <summary>
    /// External Method is have the LoUAdapter Disconnect.
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
    /// Reads the Html code returned by the server to find the error messages.
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
    /// Gets the game page for the server after logging in.
    /// </summary>
    /// <returns></returns>
    private string GetGamePage()
    {
      return MessageExchangeAdapter.GetGamePage(SessionId);
    }

    /// <summary>
    /// Uses the louGameServerQuerier to Query the LoU Home Page.
    /// </summary>
    /// <returns></returns>
    private string GetHomePage()
    {
      return MessageExchangeAdapter.GetHomePage();
    }

    /// <summary>
    /// Reads the html and pulls the session id out of it. 
    /// </summary>
    /// <returns>A Session Id</returns>
    private static string GetSessionId(string result)
    {
      if (!result.Contains("index.aspx?sessionId=") && !result.Contains("SessionId = \"") && !result.Contains("<input type=\"hidden\" name=\"sessionId\" id=\"sessionId\" value=\""))
      {
        System.Diagnostics.Debug.WriteLine(String.Format("Unable to find (index.aspx?sessionId=) or (SessionId = \") in last HtmlResult."));
        return null;
      }

      var reader = new StringReader(result);
      string line;
      string sessionId = null;
      while ((line = reader.ReadLine()) != null)
      {
        if (!line.Contains("?sessionId=") && !line.Contains("SessionId = \"") && !result.Contains("<input type=\"hidden\" name=\"sessionId\" id=\"sessionId\" value=\"")) continue;

        if (line.Contains("?sessionId="))
        {
          sessionId = line.Substring(line.IndexOf("?sessionId=") + 11, 36);
          System.Diagnostics.Debug.WriteLine("Test: {0}, Session Id found in HTML. Line: {1}", "LoUCloent.GetSessionId", line);
          break;
        }

        if (line.Contains("SessionId = \""))
        {
          sessionId = line.Substring(line.IndexOf("SessionId = \"") + 13, 36);
          System.Diagnostics.Debug.WriteLine("Test: {0}, Session Id found in HTML. Line: {1}", "LoUCloent.GetSessionId", line);
          break;
        }

        if (line.Contains("<input type=\"hidden\" name=\"sessionId\" id=\"sessionId\" value=\""))
        {
          sessionId = line.Substring(line.IndexOf("<input type=\"hidden\" name=\"sessionId\" id=\"sessionId\" value=\"") + 60, 36);
          System.Diagnostics.Debug.WriteLine("Test: {0}, Session Id found in HTML. Line: {1}", "LoUCloent.GetSessionId", line);
          break;
        }
      }
      return sessionId;
    }

    /// <summary>
    /// Handles Errors from Delegates.
    /// </summary>
    /// <param name="method"></param>
    /// <param name="exception"></param>
    private static void HandleDelegateError(MethodInfo method, Exception exception)
    {
      MessageBox.Show(exception.Message, String.Format("Error: {0}", method));
    }

    /// <summary>
    /// Handles the Response from the LoU Server.
    /// </summary>
    /// <param name="response"></param>
    private void HandlePollResponse(object response)
    {
      var deserializeObject = JsonConvert.DeserializeObject<PollResponse<object>>(response.ToString());

      switch (deserializeObject.C)
      {
        case "ALLIANCE":
          //AllianceResponse(JsonConvert.DeserializeObject<AllianceResponse>(response.ToString()));
          break;

        case "CHAT":
          ChatResponse(JsonConvert.DeserializeObject<ChatResponse>(response.ToString()));
          break;

        case "CITY":
          CityResponse(JsonConvert.DeserializeObject<CityResponse>(response.ToString()));
          break;

        case "FRIENDINV": // Do Nothing
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

        case "SYS":
          SystemResponse(JsonConvert.DeserializeObject<SysResponse>(response.ToString()));
          break;

        case "VERSION":
          VersionResponse(JsonConvert.DeserializeObject<VersionResponse>(response.ToString()));
          break;

        case "VIS": // Vision
          break;

        default:
          System.Diagnostics.Debug.WriteLine(String.Format("Unknown Response: {0}", response));
          break;
      }
    }

    /// <summary>
    /// Removes a poll request item.
    /// </summary>
    /// <param name="pollRequestItem"></param>
    public void RemovePollRequestItem(PollRequestItems pollRequestItem)
    {
      if (_pollRequestItems.ContainsKey(pollRequestItem.ToString()))
      {
        _pollRequestItems.Remove(pollRequestItem);
      }
      if (_polltimer.Enabled && _pollRequestItems.Count == 0)
      {
        StopPollTimer();
      }
    }

    /// <summary>
    /// Populates the list of cities. 
    /// </summary>
    /// <param name="cities"></param>
    private void SetCities(List<CityResponse> cities)
    {
      if (Cities.Count != cities.Count)
      {
        if (Cities.Count > 0)
        {
          Cities.Clear();
          CurrentCity = null;
        }
        foreach (CityResponse city in cities)
        {
          Cities.Add(new City(city));
        }
      }

      if (CurrentCity == null && Cities.Count > 0)
      {
        CurrentCity = Cities[0];
      }
    }

    /// <summary>
    /// Starts the Poll timer.
    /// </summary>
    private void StartPollTimer()
    {
      if (ConnectionState == ConnectionState.Connected &&
          _pollRequestItems.Count > 0 &&
          !_polltimer.Enabled)
      {
        _polltimer.Start();
      }
    }

    /// <summary>
    /// Sets the login username and password.
    /// </summary>
    /// <param name="credential"></param>
    public void SetCredentials(NetworkCredential credential)
    {
      Credentials = credential;
      System.Diagnostics.Debug.WriteLine(String.Format("email = {0}", credential.UserName));
      System.Diagnostics.Debug.WriteLine(String.Format("pass = {0}", credential.Password));
    }

    /// <summary>
    /// Stops the Poll timer
    /// </summary>
    private void StopPollTimer()
    {
      if (_polltimer.Enabled)
      {
        _polltimer.Stop();
      }
    }

    /// <summary>
    /// Updates a value on the poll request items.
    /// if the item does not exist then it is added.
    /// </summary>
    /// <param name="pollRequestItem"></param>
    /// <param name="value"></param>
    public void UpdatePollRequestItem(PollRequestItems pollRequestItem, string value)
    {
      if (_pollRequestItems.ContainsKey(pollRequestItem.ToString()))
      {
        _pollRequestItems[pollRequestItem.ToString()] = value;
      }
      else
      {
        PollRequestItems[] item = { pollRequestItem };
        AddPollRequestItems(item, value);
      }
    }

  }
}
