using System;
using System.Windows.Forms;

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
      Application.Run(new MainScreen(Plugins));
    }
  }
}
