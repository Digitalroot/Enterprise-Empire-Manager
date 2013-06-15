using System;
using System.Reflection;
using System.Windows.Forms;
using EEM.Common;
using EEM.Common.PluginInterface;

namespace EEM.Plugin.Ranking
{
  public class Ranking : IPlugin
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
      _enterpriseEmpireManager.AddMenuItem(EEMMenuItems.View, _myPluginViewMenuItem);
      _enterpriseEmpireManager.LoUAdapter.OnConnectionStateChange += LoUAdapter_OnConnectionStateChange;
    }

    /// <summary>
    /// EEM calls this when unloading your plug-in.
    /// </summary>
    public void Dispose()
    {
      _enterpriseEmpireManager.RemoveMenuItem(EEMMenuItems.View, _myPluginViewMenuItem);
      _enterpriseEmpireManager.LoUAdapter.OnConnectionStateChange -= LoUAdapter_OnConnectionStateChange;
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

    private readonly ToolStripMenuItem _myPluginViewMenuItem = new ToolStripMenuItem();
    private IEnterpriseEmpireManager _enterpriseEmpireManager;
    private RankingScreen _mainScreen;

    /// <summary>
    /// Constructor
    /// </summary>
    public Ranking()
    {
      Version = AssemblyVersion;
      Name = AssemblyTitle;
      Author = AssemblyCompany;
      Description = AssemblyDescription;

      _myPluginViewMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
      _myPluginViewMenuItem.Name = "RankingViewMenuItem";
      _myPluginViewMenuItem.ShowShortcutKeys = false;
      _myPluginViewMenuItem.Size = new System.Drawing.Size(107, 22);
      _myPluginViewMenuItem.Text = "Ranking";
      _myPluginViewMenuItem.Click += myPluginViewMenuItem_Click;
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
          break;

        case ConnectionState.Disconnected:
          /**
           * Do stuff here to stop my plug-in when we are no longer connected.
           */
          break;
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
        MainInterface = new RankingScreen(_enterpriseEmpireManager)
        {
          MdiParent = _enterpriseEmpireManager.GetMdiParent()
        };
      }
      if (MainInterface.MdiParent == null)
      {
        MainInterface = new RankingScreen(_enterpriseEmpireManager)
        {
          MdiParent = _enterpriseEmpireManager.GetMdiParent()
        };
      }
      _mainScreen = MainInterface as RankingScreen;
      MainInterface.Show();
    }
  }
}
