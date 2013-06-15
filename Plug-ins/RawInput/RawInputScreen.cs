using System;
using System.Windows.Forms;
using EEM.Common.Adapters;
using EEM.Common.Exceptions;
using EEM.Common.PluginInterface;

namespace EEM.Plugin.RawInput
{
  public partial class RawInputScreen : Form
  {
    private IEnterpriseEmpireManager EnterpriseEmpireManager { get; set; }
    private LoUAdapter LoUAdapter { get; set; }
    public string RawInput { get; private set; }
    public string Url { get; private set; }

    public RawInputScreen(IEnterpriseEmpireManager enterpriseEmpireManager)
    {
      InitializeComponent();
      EnterpriseEmpireManager = enterpriseEmpireManager;
      LoUAdapter = EnterpriseEmpireManager.LoUAdapter as LoUAdapter;
    }

    private void SendButton_Click(object sender, EventArgs e)
    {
      RawInput = txtInput.Text;
      Url = txtUrl.Text;

      try
      {
        ResultBox.Text = LoUAdapter.SendRawJson(RawInput, Url);
      }
      catch (NotConnected)
      {
        MessageBox.Show("Not Connected", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }
    }
  }
}
