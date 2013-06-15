using System;   
using System.Windows.Forms;

namespace EEM
{
  public partial class EditLoginInfoScreen : Form
  {
    public EditLoginInfoScreen()
    {
      InitializeComponent();
      txtUsername.Text = Properties.Settings.Default.Username;
      txtPassword.Text = Properties.Settings.Default.Password;
      cbxSavePass.Checked = Properties.Settings.Default.SavePassword;
    }

    public delegate void SaveLoginHandler(string username, string password, bool savePass);

    public event SaveLoginHandler OnSaveLogin;

    protected void SaveLogin(string username, string password, bool savePass)
    {
      if (OnSaveLogin != null)
      {
        OnSaveLogin(username, password, savePass);
      }
    }

    // ReSharper disable InconsistentNaming
    private void btnSave_Click(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      SaveLogin(txtUsername.Text, txtPassword.Text, cbxSavePass.Checked);
      Close();
    }
  }
}
