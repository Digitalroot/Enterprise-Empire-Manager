using System;
using System.Reflection;
using System.Windows.Forms;
using EEM.Properties;

namespace EEM
{
  static class Program
  {
    public static PluginServices Plugins;

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
      Plugins = new PluginServices();
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      CheckVersion();
      Application.Run(new MainScreen(Plugins));
    }

    /// <summary>
    /// Loads settings from old configuration file if this is a new version.
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
