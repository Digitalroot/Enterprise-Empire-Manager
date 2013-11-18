using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using EEM.Common.Clients;
using EEM.Common.PluginInterface;
using EEM.Plugin.JsonLogger.Properties;

namespace EEM.Plugin.JsonLogger
{
  public class JsonLogger : IPlugin
  {
    #region Implementation of IPlugin

    /// <summary>
    /// Author of the plug-in
    /// </summary>
    public string Author { get; private set; }

    /// <summary>
    /// Description of the plug-in
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// Main interface for your plug-in.
    /// </summary>
    /// <remarks>
    /// If you want a screen for your plug-in then set this to your form and 
    /// call MainInterface.Show() in Initialize(). 
    /// 
    /// If you do not want a screen, (i.e. your writing a plug-in that logs chat to 
    /// a log file and does not need a screen.) do not call MainInterface.Show().
    /// </remarks>
    /// <example>
    ///   MainInterface = new MyPluginScreen();
    ///   MainInterface.MdiParent = enterpriseEmpireManager.GetMdiParent();
    ///   MainInterface.Show();
    /// </example>
    public Form MainInterface { get; private set; }

    /// <summary>
    /// Name of the plug-in
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Current Version of the plug-in
    /// </summary>
    public string Version { get; private set; }

    /// <summary>
    /// EEM calls after it loads to send you a reference to itself.
    /// </summary>
    /// <param name="enterpriseEmpireManager"></param>
    public void Initialize(IEnterpriseEmpireManager enterpriseEmpireManager)
    {
      _enterpriseEmpireManager = enterpriseEmpireManager;

      MessageExchangeClient.Instance.OnServerRequest += LoUAdapter_OnServerRequest;
      MessageExchangeClient.Instance.OnServerResponse += LoUAdapter_OnServerResponse;
      MessageExchangeClient.Instance.OnServerResponseToQueuedCommand += LoUAdapter_OnServerResponseToQueuedCommand;

      //_enterpriseEmpireManager.LoUAdapter.OnServerRequest += LoUAdapter_OnServerRequest;
      //_enterpriseEmpireManager.LoUAdapter.OnServerResponse += LoUAdapter_OnServerResponse;
      //_enterpriseEmpireManager.LoUAdapter.OnServerResponseToQueuedCommand += LoUAdapter_OnServerResponseToQueuedCommand;
    }

    /// <summary>
    /// EEM calls this when unloading your plug-in.
    /// </summary>
    public void Dispose()
    {
      MessageExchangeClient.Instance.OnServerRequest -= LoUAdapter_OnServerRequest;
      MessageExchangeClient.Instance.OnServerResponse -= LoUAdapter_OnServerResponse;
      MessageExchangeClient.Instance.OnServerResponseToQueuedCommand -= LoUAdapter_OnServerResponseToQueuedCommand;
      //_enterpriseEmpireManager.LoUAdapter.OnServerRequest -= LoUAdapter_OnServerRequest;
      //_enterpriseEmpireManager.LoUAdapter.OnServerResponse -= LoUAdapter_OnServerResponse;
      //_enterpriseEmpireManager.LoUAdapter.OnServerResponseToQueuedCommand -= LoUAdapter_OnServerResponseToQueuedCommand;
    }

    #endregion

    #region Assembly Attribute Accessors

    public string AssemblyTitle
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if (attributes.Length > 0)
        {
          var titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if (titleAttribute.Title != "")
          {
            return titleAttribute.Title;
          }
        }
        return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }

    public string AssemblyVersion
    {
      get
      {
        return Assembly.GetExecutingAssembly().GetName().Version.ToString();
      }
    }

    public string AssemblyDescription
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyDescriptionAttribute)attributes[0]).Description;
      }
    }

    public string AssemblyProduct
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyProductAttribute)attributes[0]).Product;
      }
    }

    public string AssemblyCopyright
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
      }
    }

    public string AssemblyCompany
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        if (attributes.Length == 0)
        {
          return "";
        }
        return ((AssemblyCompanyAttribute)attributes[0]).Company;
      }
    }
    #endregion

    private IEnterpriseEmpireManager _enterpriseEmpireManager;

    /// <summary>
    /// Constructor
    /// </summary>
    public JsonLogger()
    {
      Version = AssemblyVersion;
      Name = AssemblyTitle;
      Author = AssemblyCompany;
      Description = AssemblyDescription;

      CheckVersion();
    }

    void LoUAdapter_OnServerResponseToQueuedCommand(int id, string message)
    {
      WriteToLog(String.Format("MessageExchangeClient.OnServerResponseToQueuedCommand: ID: {0}, Result: {1}", id, message));
    }

    void LoUAdapter_OnServerResponse(string message)
    {
      WriteToLog(String.Format("MessageExchangeClient.OnServerResponse: {0}", message));
    }

    void LoUAdapter_OnServerRequest(string url, Common.Protocol.JsonRequest json)
    {
      WriteToLog(String.Format("MessageExchangeClient.OnServerRequest: {0}, URL: {1}", json, url));
    }

    private void WriteToLog(string message)
    {
      using (var logfile = new StreamWriter(".\\JsonLog.log", true))
      {
        logfile.WriteLine(message);
        logfile.Close();
      }
    }

    /// <summary>
    /// Loads settings from old config file if this is a new version.
    /// </summary>
    private static void CheckVersion()
    {
      var a = Assembly.GetExecutingAssembly();
      var appVersion = a.GetName().Version;
      var appVersionString = appVersion.ToString();
      if (Settings.Default.ApplicationVersion != appVersion.ToString())
      {
        Settings.Default.Upgrade();
        Settings.Default.ApplicationVersion = appVersionString;
        Settings.Default.Save();
        Settings.Default.Reload();
      }
    }
  }
}
