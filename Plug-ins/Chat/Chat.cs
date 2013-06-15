using System;
using System.Reflection;
using System.Windows.Forms;
using EEM.Common;
using EEM.Common.PluginInterface;
using EEM.Plugin.Chat.Properties;
using Resources = EEM.Plugin.Chat.Properties.Resources;

namespace EEM.Plugin.Chat
{
  public class Chat : IPlugin
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
    /// EEM calls after it loads to send you a reference to itself and the LoUAdapter.
    /// </summary>
    /// <param name="enterpriseEmpireManager"></param>
    public void Initialize(IEnterpriseEmpireManager enterpriseEmpireManager)
    {
      _enterpriseEmpireManager = enterpriseEmpireManager;
      _enterpriseEmpireManager.AddMenuItem(EEMMenuItems.View, _chatViewMenuItem);
      _enterpriseEmpireManager.AddMenuItem(EEMMenuItems.Tools, _chatToolsMenuItem);
      
      if (Settings.Default.OpenChatWindowOnStartUp)
      {
        OpenChatWindow();
      }
    }

    /// <summary>
    /// EEM calls this when unloading your plug-in.
    /// </summary>
    public void Dispose()
    {
      _enterpriseEmpireManager.RemoveMenuItem(EEMMenuItems.View, _chatViewMenuItem);
      _enterpriseEmpireManager.RemoveMenuItem(EEMMenuItems.Tools, _chatToolsMenuItem);
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

    private readonly ToolStripMenuItem _chatViewMenuItem = new ToolStripMenuItem();
    private readonly ToolStripMenuItem _chatToolsMenuItem = new ToolStripMenuItem();
    private IEnterpriseEmpireManager _enterpriseEmpireManager;
    private ChatScreen _chatScreen;

    /// <summary>
    /// Constructor
    /// </summary>
    public Chat()
    {
      Version = AssemblyVersion;
      Name = AssemblyTitle;
      Author = AssemblyCompany;
      Description = AssemblyDescription;

      CheckVersion();

      _chatViewMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
      _chatViewMenuItem.Name = "chatviewMenuItem";
      _chatViewMenuItem.ShowShortcutKeys = false;
      _chatViewMenuItem.Size = new System.Drawing.Size(107, 22);
      _chatViewMenuItem.Text = Resources.Chat_Chat_Chat_Screen;
      _chatViewMenuItem.Click += chatViewMenuItem_Click;

      _chatToolsMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
      _chatToolsMenuItem.Name = "chatOptionsMenuItem";
      _chatToolsMenuItem.ShowShortcutKeys = false;
      _chatToolsMenuItem.Size = new System.Drawing.Size(107, 22);
      _chatToolsMenuItem.Text = Resources.Chat_Chat_Chat_Options;
      _chatToolsMenuItem.Click += chatToolsMenuItem_Click;

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

    // ReSharper disable InconsistentNaming
    private void chatToolsMenuItem_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      if (MainInterface == null)
      {
        MainInterface = new ChatScreen(_enterpriseEmpireManager)
        {
          MdiParent = _enterpriseEmpireManager.GetMdiParent()
        };
        _chatScreen = MainInterface as ChatScreen;
      }
      if (MainInterface.MdiParent == null)
      {
        MainInterface = new ChatScreen(_enterpriseEmpireManager)
        {
          MdiParent = _enterpriseEmpireManager.GetMdiParent()
        };
        _chatScreen = MainInterface as ChatScreen;
      }

      if (_chatScreen != null)
      {
        _chatScreen.ShowOptionsScreen();
      }
    }

    // ReSharper disable InconsistentNaming
    void chatViewMenuItem_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      OpenChatWindow();
    }

    private void OpenChatWindow()
    {
      if (MainInterface == null)
      {
        MainInterface = new ChatScreen(_enterpriseEmpireManager)
        {
          MdiParent = _enterpriseEmpireManager.GetMdiParent()
        };
      }
      if (MainInterface.MdiParent == null)
      {
        MainInterface = new ChatScreen(_enterpriseEmpireManager)
        {
          MdiParent = _enterpriseEmpireManager.GetMdiParent()
        };
      }
      _chatScreen = MainInterface as ChatScreen;
      MainInterface.Show();      
    }
  }
}
