using System;
using System.Windows.Forms;
using EEM.Properties;

namespace EEM
{
  public partial class OptionsScreen : Form
  {
    public OptionsScreen()
    {
      InitializeComponent();
      textBoxGameServer.Text = Settings.Default.Server;
      checkBoxConnectOnStartUp.Checked = Settings.Default.ConnectOnStartup;
    }

    private void buttonSave_Click(object sender, EventArgs e)
    {
      Settings.Default.Server = textBoxGameServer.Text;
      Settings.Default.ConnectOnStartup = checkBoxConnectOnStartUp.Checked;
      Settings.Default.Save();
      Settings.Default.Reload();
      Close();
    }
  }
}
