using System;
using System.Windows.Forms;
using EEM.Common;
using EEM.Common.PluginInterface;
using EEM.Common.Protocol;

namespace EEM.Plugin.Notifications
{
  public class Notifications : IPlugin
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
    /// Name of the plug-in
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// Current Version of the plug-in
    /// </summary>
    public string Version { get; private set; }
    
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
    /// EEM calls after it loads to send you a reference to itself.
    /// </summary>
    /// <param name="enterpriseEmpireManager"></param>
    public void Initialize(IEnterpriseEmpireManager enterpriseEmpireManager)
    {
      _enterpriseEmpireManager = enterpriseEmpireManager;
      _enterpriseEmpireManager.AddMenuItem(EEMMenuItems.View, _myPluginViewMenuItem);
      _enterpriseEmpireManager.LoUAdapter.OnConnectionStateChange += LoUAdapter_OnConnectionStateChange;
    }

    /// <summary>
    /// EEM calls this when unloading your plug-in.
    /// </summary>
    public void Dispose()
    {
      _enterpriseEmpireManager.LoUAdapter.OnConnectionStateChange -= LoUAdapter_OnConnectionStateChange;
      _enterpriseEmpireManager.LoUAdapter.OnALLATResponse -= LoUAdapter_OnALLATResponse;
    }

    #endregion

    private readonly ToolStripMenuItem _myPluginViewMenuItem = new ToolStripMenuItem();
    private IEnterpriseEmpireManager _enterpriseEmpireManager;
    private MainScreen _mainScreen;

    /// <summary>
    /// Constructor
    /// </summary>
    public Notifications()
    {
      Version = "1.0.1";
      Name = "Notifications";
      Author = "pstuart";
      Description = "A plug-in that does xyz.";

      _myPluginViewMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
      _myPluginViewMenuItem.Name = "myPluginViewMenuItem";
      _myPluginViewMenuItem.ShowShortcutKeys = false;
      _myPluginViewMenuItem.Size = new System.Drawing.Size(107, 22);
      _myPluginViewMenuItem.Text = "Notifications Screen";
      _myPluginViewMenuItem.Click += myPluginViewMenuItem_Click;
      Logger.Log("Plugin Started");
    }

    /// <summary>
    /// Handles Connected and Disconnected Events.
    /// </summary>
    /// <param name="connectionState"></param>
    void LoUAdapter_OnConnectionStateChange(ConnectionState connectionState)
    {
      switch (connectionState)
      {
        case ConnectionState.Connected:
          /**
           * Do stuff here to start my plug-in once we are connected.
           */
          _enterpriseEmpireManager.LoUAdapter.OnALLATResponse += LoUAdapter_OnALLATResponse;
          _enterpriseEmpireManager.LoUAdapter.OnPlayerResponse += LoUAdapter_OnPlayerResponse;
              
          PollRequestItems[] item = { PollRequestItems.ALL_AT, PollRequestItems.PLAYER, PollRequestItems.TIME };
          _enterpriseEmpireManager.LoUAdapter.PollingService.AddPollRequestItems(item, String.Empty);
          break;

        case ConnectionState.Disconnected:
          /**
           * Do stuff here to stop my plug-in when we are no longer connected.
           */
          break;
      }
    }

    void LoUAdapter_OnPlayerResponse(Common.Protocol.PlayerResponse response)
    {
        if (_mainScreen != null && _mainScreen.Visible)
        {
            _mainScreen.UpdatePlayerList(response);
        }
        _enterpriseEmpireManager.LoUAdapter.PollingService.RemovePollRequestItem(PollRequestItems.PLAYER);
        _enterpriseEmpireManager.LoUAdapter.PollingService.RemovePollRequestItem(PollRequestItems.TIME);
    }

    void LoUAdapter_OnALLATResponse(Common.Protocol.ALLATResponse response)
    {
      if (_mainScreen != null && _mainScreen.Visible)
      {
        _mainScreen.UpdateAttackList(response);  
      }

    }

    /// <summary>
    /// Handles Click event when a user clicks on "Show MyPlugin Screen" from the view menu.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void myPluginViewMenuItem_Click(object sender, EventArgs e)
    {
      if (MainInterface == null)
      {
        MainInterface = new MainScreen(_enterpriseEmpireManager)
        {
          MdiParent = _enterpriseEmpireManager.GetMdiParent()
        };
      }
      if (MainInterface.MdiParent == null)
      {
        MainInterface = new MainScreen(_enterpriseEmpireManager)
        {
          MdiParent = _enterpriseEmpireManager.GetMdiParent()
        };
      }
      _mainScreen = MainInterface as MainScreen;
      MainInterface.Show();
    }
  }
}
