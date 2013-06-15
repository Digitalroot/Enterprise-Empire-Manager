using System;
using System.Windows.Forms;
using EEM.Properties;

namespace EEM
{
  public partial class OptionsScreen : Form
  {
    public bool SaveClicked { get; set; }

    public OptionsScreen()
    {
      InitializeComponent();
      textBoxGameServer.Text = Settings.Default.Server;
      checkBoxConnectOnStartUp.Checked = Settings.Default.ConnectOnStartup;
      checkBoxMinToSysTray.Checked = Settings.Default.MinimizeToSystemTray;
      SaveClicked = false;
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      Settings.Default.Server = textBoxGameServer.Text;
      Settings.Default.ConnectOnStartup = checkBoxConnectOnStartUp.Checked;
      Settings.Default.MinimizeToSystemTray = checkBoxMinToSysTray.Checked;
      Settings.Default.Save();
      Settings.Default.Reload();
      SaveClicked = true;
      Close();
    }
  }
}
