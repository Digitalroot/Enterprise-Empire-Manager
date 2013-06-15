using System.Windows.Forms;
using EEM.Common.PluginInterface;

namespace EEM.Plugin.PluginTemplateWithScreen
{
  public partial class MyPluginMainScreen : Form
  {
    private readonly IEnterpriseEmpireManager _enterpriseEmpireManager;

    public MyPluginMainScreen(IEnterpriseEmpireManager enterpriseEmpireManager)
    {
      _enterpriseEmpireManager = enterpriseEmpireManager;
      InitializeComponent();
    }
  }
}
