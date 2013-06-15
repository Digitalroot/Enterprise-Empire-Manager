using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using EEM.Common.Clients;
using EEM.Common.Protocol;

namespace EEM.Common.Adapters
{
  /// <summary>
  /// This is the piece that exchanges messages with the LoU Servers
  /// </summary>
  public sealed class MessageExchangeAdapter
  {
    /// <summary>
    /// Background worker thread.
    /// </summary>
    private readonly BackgroundWorker _backgroundWorker = new BackgroundWorker();

    /// <summary>
    /// Singleton Instance
    /// </summary>
    private static volatile MessageExchangeAdapter _instance;

    /// <summary>
    /// Stores commands to be executed.
    /// </summary>
    private readonly Queue<QueuedCommand> _queuedCommands = new Queue<QueuedCommand>();

    /// <summary>
    /// Counts the number of queued commands.
    /// </summary>
    private Int32 _queuedCommandsIdCounter;

    /// <summary>
    /// Poll timer
    /// </summary>
    private readonly System.Windows.Forms.Timer _queuetimer = new System.Windows.Forms.Timer { Interval = 10000 };

    /// <summary>
    /// Used to make request to the LoU Server
    /// </summary>
    private readonly JsonWebClient _webClient = new JsonWebClient();

    /// <summary>
    /// Configuration for the adapter
    /// </summary>
    internal AdapterConfiguration Configuration { get; set; }

    /// <summary>
    /// Singleton
    /// </summary>
    public static MessageExchangeAdapter Instance
    {
      get
      {
        if (_instance == null)
        {
          lock (SyncRoot)
          {
            if (_instance == null)
              _instance = new MessageExchangeAdapter();
          }
        }
        return _instance;
      }
    }

    /// <summary>
    /// Exposes the Response Headers from the JsonWebClient
    /// </summary>
    internal WebHeaderCollection ResponseHeaders { get; private set; }

    /// <summary>
    /// Exposes the Request Headers from the JsonWebClient
    /// </summary>
    internal WebHeaderCollection RequestHeaders { get; private set; }

    /// <summary>
    /// Lock to make thread safe
    /// </summary>
    private static readonly object SyncRoot = new Object();

    /// <summary>
    /// Lock to make thread safe.
    /// </summary>
    public static readonly object SyncBackGroundWorker = new Object();

    #region Events

    public delegate void ServerResponseHandler(string message);
    public event ServerResponseHandler OnServerResponse;
    private void ServerResponded(string message)
    {
      if (OnServerResponse != null)
      {
        Delegate[] subscribers = OnServerResponse.GetInvocationList();
        foreach (ServerResponseHandler subscriber in subscribers)
        {
          try
          {
            subscriber(message);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void ServerRequestSentHandler(string url, JsonRequest request);
    public event ServerRequestSentHandler OnServerRequest;
    private void ServerRequestSent(string url, JsonRequest request)
    {
      if (OnServerRequest != null)
      {
        Delegate[] subscribers = OnServerRequest.GetInvocationList();
        foreach (ServerRequestSentHandler subscriber in subscribers)
        {
          try
          {
            subscriber(url, request);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void ServerResponseToQueuedCommandHandler(Int32 id, string message);
    public event ServerResponseToQueuedCommandHandler OnServerResponseToQueuedCommand;
    private void ServerRespondedToQueuedCommand(Int32 id, string result)
    {
      if (OnServerResponseToQueuedCommand != null)
      {
        Delegate[] subscribers = OnServerResponseToQueuedCommand.GetInvocationList();
        foreach (ServerResponseToQueuedCommandHandler subscriber in subscribers)
        {
          try
          {
            subscriber(id, result);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    #endregion

    /// <summary>
    /// Constructor
    /// </summary>
    private MessageExchangeAdapter()
      : this(null)
    { }

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="configuration"></param>
    private MessageExchangeAdapter(AdapterConfiguration configuration)
    {
      Configuration = configuration;
      _backgroundWorker.DoWork += BackgroundWorkerDoWork;
      _backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
      _queuetimer.Tick += queuetimer_Tick;
      _queuetimer.Start();
    }

    /// <summary>
    /// Takes passed credentials and posts them to the LoU website to log into the server.
    /// </summary>
    /// <param name="credential">Username and password to post to the sever.</param>
    /// <returns></returns>
    internal string Authenticate(NetworkCredential credential)
    {
      // fields mail:password
      if (credential == null || string.IsNullOrEmpty(credential.UserName) || string.IsNullOrEmpty(credential.Password))
      {
        throw new AuthenticationException("MISSING_USERNAME_OR_PASSWORD");
      }

      var formData = new NameValueCollection();
      formData["mail"] = credential.UserName;
      formData["password"] = credential.Password;

      byte[] responseBytes = _webClient.UploadValues(Configuration.AuthenticationUrl, "POST", formData);
      RequestHeaders = _webClient.Headers;
      ResponseHeaders = _webClient.ResponseHeaders;
      var result = Decode(responseBytes);

      ServerResponded(result);
      return result;
    }

    /// <summary>
    /// What work the background worker thread does. 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void BackgroundWorkerDoWork(object sender, DoWorkEventArgs e)
    {
        var command = _queuedCommands.Dequeue();
        if (command != null)
        {
          var result = ExecuteServerCommand(command.Command, command.JsonRequest, true);
          e.Result = new QueuedResult(result, command.Id);
        }
    }

    /// <summary>
    /// Runs when Background working is finished.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    // ReSharper restore InconsistentNaming
    {
      var results = e.Result as QueuedResult;
      
      if (results != null) ServerRespondedToQueuedCommand(results.Id, results.Result);

      if (_queuedCommands.Count > 0 && !_backgroundWorker.IsBusy)
      {
        _backgroundWorker.RunWorkerAsync();
        Thread.Sleep(1000);
      }
    }

    /// <summary>
    /// Used for debugging.
    /// </summary>
    /// <param name="method"></param>
    /// <param name="htmlResult"></param>
    internal static void Debug(string method, string htmlResult)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("Connect: {0}, HtmlResult: {1}", method, htmlResult));
    }

    /// <summary>
    /// Converts from byte[] to string.
    /// </summary>
    /// <param name="input"></param>
    /// <returns></returns>
    private static string Decode(byte[] input)
    {
      return Encoding.ASCII.GetString(input);
    }

    /// <summary>
    /// Query the LoU Game server with a command.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="json"></param>
    /// <param name="isQueuedCommand"></param>
    /// <returns></returns>
    internal string ExecuteServerCommand(ServerCommand command, JsonRequest json, bool isQueuedCommand = false)
    {
      Thread.Sleep(500); // Throttle Requests.
      var htmlResult = _webClient.QueryUrlAsJSONRequest(Configuration.GameServerUrl + "/Presentation/Service.svc/ajaxEndpoint/" + command, json);
      ServerRequestSent(Configuration.GameServerUrl + "/Presentation/Service.svc/ajaxEndpoint/" + command, json);

      if (String.IsNullOrEmpty(htmlResult) && _webClient.RequestStatusCode != HttpStatusCode.OK)
      {
        Thread.Sleep(10000);
        htmlResult = _webClient.QueryUrlAsJSONRequest(Configuration.GameServerUrl + "/Presentation/Service.svc/ajaxEndpoint/" + command, json);
        ServerRequestSent(Configuration.GameServerUrl + "/Presentation/Service.svc/ajaxEndpoint/" + command, json);
      }

      if (!String.IsNullOrEmpty(htmlResult) && _webClient.RequestStatusCode == HttpStatusCode.OK && !isQueuedCommand)
      {
        ServerResponded(htmlResult);
      }

      RequestHeaders = _webClient.Headers;
      ResponseHeaders = _webClient.ResponseHeaders;

      return htmlResult;
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
    /// Queues commands to be executed by a background worker thread.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="json"></param>
    /// <returns>The Id number of the request. Use this to read which response is yours.</returns>
    internal int QueueServerCommand(ServerCommand command, JsonRequest json)
    {
      int id = _queuedCommandsIdCounter;
      _queuedCommandsIdCounter++;
      _queuedCommands.Enqueue(new QueuedCommand(json, command, id));

      lock (SyncBackGroundWorker)
      {
        if (!_backgroundWorker.IsBusy && _queuedCommands.Count > 0)
        {
          _backgroundWorker.RunWorkerAsync();
        }
      }
      return id;
    }

    /// <summary>
    /// Keeps the background worker working.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    void queuetimer_Tick(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      lock (SyncBackGroundWorker)
      {
        if (!_backgroundWorker.IsBusy && _queuedCommands.Count > 0)
        {
          _backgroundWorker.RunWorkerAsync();              
        }
      }
    }

    /// <summary>
    /// Gets the Home Page.
    /// </summary>
    /// <returns></returns>
    internal string GetHomePage()
    {
      var result = _webClient.QueryUrl(Configuration.HomePageUrl);
      ServerResponded(result);
      return result;
    }

    /// <summary>
    /// Calls the Logout Page.
    /// </summary>
    /// <returns></returns>
    internal string GetLogoutPage()
    {
      var result = _webClient.QueryUrl(Configuration.LogoutURL);
      ServerResponded(result);
      return result;
    }

    /// <summary>
    /// Gets the Session Page.
    /// </summary>
    /// <returns></returns>
    internal string GetSessionPage()
    {
      var result = _webClient.QueryUrlAsAJAXRequest(Configuration.SessionUrl, Configuration.HomePageUrl);
      ServerResponded(result);
      return result;
    }

    /// <summary>
    /// Sends a Json request to a URL
    /// </summary>
    /// <param name="rawInput"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    internal string RawRequest(string rawInput, string url)
    {
      var json = new JsonRequest();
      json.SetValueBypassSerializeObject(rawInput);

      var htmlResult = _webClient.QueryUrlAsJSONRequest(url, json);
      ServerRequestSent(url, json);

      if (!String.IsNullOrEmpty(htmlResult) && _webClient.RequestStatusCode == HttpStatusCode.OK)
      {
        ServerResponded(htmlResult);
      }

      RequestHeaders = _webClient.Headers;
      ResponseHeaders = _webClient.ResponseHeaders;
      return htmlResult;
    }

    internal string GetGamePage(string sessionid)
    {
      var result = _webClient.QueryUrl(Configuration.GameServerUrl + "/index.aspx?sessionId=" + sessionid);
      ServerResponded(result);
      return result;
    }
  }
}