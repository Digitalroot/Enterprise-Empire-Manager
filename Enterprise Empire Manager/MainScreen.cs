using System;
using System.Net;
using System.Windows.Forms;
using EEM.Common;
using EEM.Common.Adapters;
using EEM.Common.PluginInterface;
using EEM.Properties;

namespace EEM
{
  public partial class MainScreen : Form, IEnterpriseEmpireManager
  {
    /// <summary>
    /// Username and password used to log into LoU
    /// </summary>
    private NetworkCredential _credentials = new NetworkCredential(Settings.Default.Username, Settings.Default.Password);
    
    /// <summary>
    /// Adapter used to send commands to LoU
    /// </summary>
    private readonly LoUAdapter _loUAdapter;

    /// <summary>
    /// Holds a list of loaded plug-ins.
    /// </summary>
    protected PluginServices Plugins;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="plugins"></param>
    public MainScreen(PluginServices plugins)
    {
      InitializeComponent();

      // Load the configuration for the LouAdapter
      var config = new AdapterConfiguration
      {
        GameServerUrl = Settings.Default.Server,
        HomePageUrl = Settings.Default.LoUUrl,
      };
      _loUAdapter = Common.Adapters.LoUAdapter.Instance;
      _loUAdapter.OnConnectionStateChange += _loUAdapter_OnConnectionStateChange;
      _loUAdapter.OnAuthenticationFailed += _loUAdapter_OnAuthenticationFailed;
      _loUAdapter.Configuration = config;
      _loUAdapter.SetCredentials(_credentials);
      
      LoUAdapter = _loUAdapter;

      Plugins = plugins; // Get a ref to the plug-ins service.
      Plugins.FindPlugins(); // Find and load plug-ins in the "plug-in" directory.
      plugins.InitializePlugins(this);

      if (Settings.Default.ConnectOnStartup)
      {
        connectToolStripMenuItem_Click(null, null);
      }
    }

    /// <summary>
    /// File -> Connect
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    private void connectToolStripMenuItem_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      switch (_loUAdapter.ConnectionState)
      {
        case ConnectionState.Disconnected:
          if (String.IsNullOrEmpty(_credentials.UserName) || String.IsNullOrEmpty(_credentials.Password))
          {
            var loginInfoScreen = new EditLoginInfoScreen();
            loginInfoScreen.OnSaveLogin += loginInfoScreen_OnSaveLogin;
            loginInfoScreen.ShowDialog(this);
            if (String.IsNullOrEmpty(_credentials.UserName) || String.IsNullOrEmpty(_credentials.Password))
            {
              return;
            }
          }

          toolStripStatusLabel.Text = Resources.MainScreen_connectToolStripMenuItem_Click_Logging_into_LoU;
          connectionIconStripStatusLabel.Image = Resources.icon_yellowdot;
          statusStrip.Refresh();

          System.Diagnostics.Debug.WriteLine(String.Format("loUClient.ConnectionState = {0}",
                                                           _loUAdapter.ConnectionState));

          if (_loUAdapter.ConnectionState != ConnectionState.Connected)
          {
            _loUAdapter.Connect();
          }
          System.Diagnostics.Debug.WriteLine(String.Format("loUClient.ConnectionState = {0}",
                                                           _loUAdapter.ConnectionState));
          break;

        case ConnectionState.Connected:
          _loUAdapter.Disconnect();
          System.Diagnostics.Debug.WriteLine(String.Format("loUClient.ConnectionState = {0}",
                                                           _loUAdapter.ConnectionState));
          break;
      }
    }

    #region Event Handlers

    /// <summary>
    /// Handles Authentication failure
    /// </summary>
    /// <param name="errors"></param>
    void _loUAdapter_OnAuthenticationFailed(System.Collections.ArrayList errors)
    {
      toolStripStatusLabel.Text = Resources.MainScreen_connectToolStripMenuItem_Click_Login_Failed;
      connectionIconStripStatusLabel.Image = Resources.icon_reddot;  
      foreach (string error in errors)
      {
        MessageBox.Show(error, Resources.MainScreen__loUAdapter_OnAuthenticationFailed_Error, MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }

    /// <summary>
    /// Handles changes in the connection state.
    /// </summary>
    /// <param name="state"></param>
    void _loUAdapter_OnConnectionStateChange(ConnectionState state)
    {
      var filemenu = MainMenuStrip.Items["fileMenu"] as ToolStripMenuItem;

      switch (state)
      {
        case ConnectionState.Connected:
          toolStripStatusLabel.Text = Resources.MainScreen_Connect_Online;
          connectionIconStripStatusLabel.Image = Resources.icon_greendot;
          Text = Text + " - " + _loUAdapter.ServerName;

          // Change Menu
          if (filemenu != null)
          {
            filemenu.DropDownItems["connectToolStripMenuItem"].Text = "&Disconnect";
          }
          break;

        case ConnectionState.Disconnected:
          toolStripStatusLabel.Text = Resources.MainScreen_Connect_Offline;
          connectionIconStripStatusLabel.Image = Resources.icon_reddot;
          Text = "Enterprise Empire Manager";

          // Change Menu
          if (filemenu != null)
          {
            filemenu.DropDownItems["connectToolStripMenuItem"].Text = "&Connect";
          }
          break;
      }
    }

    // ReSharper disable InconsistentNaming
    private void changeLoginToolStripMenuItem_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      var loginInfoScreen = new EditLoginInfoScreen();
      loginInfoScreen.OnSaveLogin += loginInfoScreen_OnSaveLogin;
      loginInfoScreen.ShowDialog(this);
    }

    // ReSharper disable MemberCanBeMadeStatic.Local
    void loginInfoScreen_OnSaveLogin(string username, string password, bool savePass)
    // ReSharper restore MemberCanBeMadeStatic.Local
    {
      Settings.Default.Username = username;
      Settings.Default.SavePassword = savePass;

      if (savePass)
      {
        Settings.Default.Password = password;
      }

      // Save and Reload
      Settings.Default.Save();
      Settings.Default.Reload();

      _credentials = new NetworkCredential(username, password);

      if (_loUAdapter.ConnectionState == ConnectionState.Connected)
      {
        _loUAdapter.Disconnect();
      }
      _loUAdapter.SetCredentials(_credentials);
    }

    // ReSharper disable InconsistentNaming
    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      new OptionsScreen().ShowDialog(this);
      var config = new AdapterConfiguration
      {
        GameServerUrl = Settings.Default.Server,
        HomePageUrl = Settings.Default.LoUUrl,
      };

      if (_loUAdapter.ConnectionState == ConnectionState.Connected)
      {
        MessageBox.Show(Resources.MainScreen_optionsToolStripMenuItem_Click_Changes_to_game_server_settings_require_you_to_disconnect_and_reconnect, Resources.MainScreen_optionsToolStripMenuItem_Click_Warning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        _loUAdapter.Disconnect();
      }
      _loUAdapter.Configuration = config;

    }

    #endregion

    #region Implementation of IEnterpriseEmpireManager

    /// <summary>
    /// Adapter used to send commands to LoU
    /// </summary>
    public ILoUAdapter LoUAdapter { get; private set; }

    /// <summary>
    /// Get the Mdi Parent
    /// </summary>
    /// <returns></returns>
    public Form GetMdiParent()
    {
      return this;
    }

    /// <summary>
    /// Adds an item to a menu.
    /// </summary>
    public void AddMenuItem(EEMMenuItems menuItem , ToolStripMenuItem toolStripMenuItem)
    {
      switch (menuItem)
      {
        case EEMMenuItems.File:
          fileMenu.DropDownItems.Add(toolStripMenuItem);
          break;
        case EEMMenuItems.Edit:
          editMenu.DropDownItems.Add(toolStripMenuItem);
          break;
        case EEMMenuItems.View:
          viewMenu.DropDownItems.Add(toolStripMenuItem);
          break;
        case EEMMenuItems.Tools:
          toolsMenu.DropDownItems.Add(toolStripMenuItem);
          break;
        case EEMMenuItems.Windows:
          windowsMenu.DropDownItems.Add(toolStripMenuItem);
          break;
        case EEMMenuItems.Help:
          helpMenu.DropDownItems.Add(toolStripMenuItem);
          break;
      }
    }

    /// <summary>
    /// Removes an item from a menu.
    /// </summary>
    /// <param name="menuItem"></param>
    /// <param name="toolStripMenuItem"></param>
    public void RemoveMenuItem(EEMMenuItems menuItem, ToolStripMenuItem toolStripMenuItem)
    {
      switch (menuItem)
      {
        case EEMMenuItems.File:
          fileMenu.DropDownItems.Remove(toolStripMenuItem);
          break;
        case EEMMenuItems.Edit:
          editMenu.DropDownItems.Remove(toolStripMenuItem);
          break;
        case EEMMenuItems.View:
          viewMenu.DropDownItems.Remove(toolStripMenuItem);
          break;
        case EEMMenuItems.Tools:
          toolsMenu.DropDownItems.Remove(toolStripMenuItem);
          break;
        case EEMMenuItems.Windows:
          windowsMenu.DropDownItems.Remove(toolStripMenuItem);
          break;
        case EEMMenuItems.Help:
          helpMenu.DropDownItems.Remove(toolStripMenuItem);
          break;
      }
    }

    #endregion
  }
}
