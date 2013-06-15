using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EEM.Common.PluginInterface;

namespace EEM.Plugin.CityInfo
{
  public partial class CityInfoScreen : Form
  {
    private readonly IEnterpriseEmpireManager _enterpriseEmpireManager;
    public BannerUser BannerUser { get; private set; }
    public CityInfoScreen(IEnterpriseEmpireManager enterpriseEmpireManager)
    {
      InitializeComponent();
      BannerUser = new BannerUser();
      _enterpriseEmpireManager = enterpriseEmpireManager;
      _enterpriseEmpireManager.LoUAdapter.OnPlayerResponse += LoUAdapter_OnPlayerResponse;
    }

    ~CityInfoScreen()
    {
      _enterpriseEmpireManager.LoUAdapter.OnPlayerResponse -= LoUAdapter_OnPlayerResponse;
    }

    private void CityInfoScreen_Load(object sender, EventArgs e)
    {
      Banner.Controls.Add(BannerUser);
    }

    void LoUAdapter_OnPlayerResponse(Common.Protocol.PlayerResponse response)
    {
      BannerUser.labelScoreValue.Text = response.Score.ToString();
      BannerUser.labelRankValue.Text = response.Rank.ToString();
      BannerUser.labelTitleValue.Text = response.Title.ToString();
    }

  }
}
