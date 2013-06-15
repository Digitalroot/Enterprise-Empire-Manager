using System.Reflection;
using System.Windows.Forms;
using EEM.Common;
using EEM.Common.PluginInterface;

namespace EEM.Plugin.RawInput
{
  public class RawInput : IPlugin
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
    /// EEM calls after it loads to send you a reference to itself and the LoUAdapter.
    /// </summary>
    /// <param name="enterpriseEmpireManager"></param>
    public void Initialize(IEnterpriseEmpireManager enterpriseEmpireManager)
    {
      _enterpriseEmpireManager = enterpriseEmpireManager;
      _enterpriseEmpireManager.AddMenuItem(EEMMenuItems.View, _rawDataViewMenuItem);
    }

    /// <summary>
    /// EEM calls this when unloading your plug-in.
    /// </summary>
    public void Dispose()
    {
      _enterpriseEmpireManager.RemoveMenuItem(EEMMenuItems.View, _rawDataViewMenuItem);
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
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
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

    
    private readonly ToolStripMenuItem _rawDataViewMenuItem = new ToolStripMenuItem();
    private IEnterpriseEmpireManager _enterpriseEmpireManager;

    /// <summary>
    /// Constructor
    /// </summary>
    public RawInput()
    {
      Version = AssemblyVersion;
      Name = AssemblyTitle;
      Author = AssemblyCompany;
      Description = AssemblyDescription;

      _rawDataViewMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
      _rawDataViewMenuItem.Name = "rawDataOptionsMenuItem";
      _rawDataViewMenuItem.ShowShortcutKeys = false;
      _rawDataViewMenuItem.Size = new System.Drawing.Size(107, 22);
      _rawDataViewMenuItem.Text = "Raw Input Screen";
      _rawDataViewMenuItem.Click += _rawDataViewMenuItem_Click;
    }

    void _rawDataViewMenuItem_Click(object sender, System.EventArgs e)
    {
      if (MainInterface == null)
      {
        MainInterface = new RawInputScreen(_enterpriseEmpireManager);
        MainInterface.MdiParent = _enterpriseEmpireManager.GetMdiParent();
      }
      if (MainInterface.MdiParent == null)
      {
        MainInterface = new RawInputScreen(_enterpriseEmpireManager);
        MainInterface.MdiParent = _enterpriseEmpireManager.GetMdiParent();
      }
      MainInterface.Show();
    }

  }
}
