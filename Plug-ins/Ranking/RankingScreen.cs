using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EEM.Common.PluginInterface;
using EEM.Common.Protocol;

namespace EEM.Plugin.Ranking
{
  public partial class RankingScreen : Form
  {
    private IEnterpriseEmpireManager EnterpriseEmpireManager { get; set; }
    private List<AllianceGetRangeResponse> AllianceGetRangeResponses { get; set; }

    public RankingScreen(IEnterpriseEmpireManager enterpriseEmpireManager)
    {
      EnterpriseEmpireManager = enterpriseEmpireManager;
      InitializeComponent();
      dataGridViewAllianceRanks.CellContentClick += dataGridViewAllianceRanks_CellContentClick;
    }

    void dataGridViewAllianceRanks_CellContentClick(object sender, DataGridViewCellEventArgs e)
    {
      if (e.ColumnIndex != 7) return;

      int allianceid = (int) dataGridViewAllianceRanks.Rows[e.RowIndex].Cells["Id"].Value;
      var memberList = new MemberList(EnterpriseEmpireManager.LoUAdapter, allianceid)
                         {
                           MdiParent = EnterpriseEmpireManager.GetMdiParent()
                         };
      memberList.Show();
    }

    private bool CheckConnection()
    {
      if (EnterpriseEmpireManager.LoUAdapter.ConnectionState == Common.ConnectionState.Disconnected)
      {
        MessageBox.Show("You must connect first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return false;
      }
      return true;
    }

    private void ButtonGetAllianceRanksClick(object sender, System.EventArgs e)
    {
      if (!CheckConnection())
      {
        return;
      }

      AllianceGetRangeResponses = EnterpriseEmpireManager.LoUAdapter.GetListOfAlliances();

      dataGridViewAllianceRanks.Rows.Clear();

      foreach (var allianceGetRangeResponse in AllianceGetRangeResponses)
      {
        if (allianceGetRangeResponse.Points == 0 || allianceGetRangeResponse.Rank > 100) return;

        int n = dataGridViewAllianceRanks.Rows.Add();
        dataGridViewAllianceRanks.Rows[n]
          .Cells[AllianceRanksFieldNames.Id.ToString()]
          .Value = allianceGetRangeResponse.Id;

        dataGridViewAllianceRanks.Rows[n]
          .Cells[AllianceRanksFieldNames.AllianceName.ToString()]
          .Value = allianceGetRangeResponse.Name;

        dataGridViewAllianceRanks.Rows[n]
          .Cells[AllianceRanksFieldNames.Rank.ToString()]
          .Value = allianceGetRangeResponse.Rank;

        dataGridViewAllianceRanks.Rows[n]
          .Cells[AllianceRanksFieldNames.Points.ToString()]
          .Value = allianceGetRangeResponse.Points;

        dataGridViewAllianceRanks.Rows[n]
          .Cells[AllianceRanksFieldNames.Members.ToString()]
          .Value = allianceGetRangeResponse.Members;

        dataGridViewAllianceRanks.Rows[n]
          .Cells[AllianceRanksFieldNames.Avg.ToString()]
          .Value = allianceGetRangeResponse.Avg;

        dataGridViewAllianceRanks.Rows[n]
          .Cells[AllianceRanksFieldNames.Cities.ToString()]
          .Value = allianceGetRangeResponse.Cities;
      }
    }

    private void buttonExport_Click(object sender, System.EventArgs e)
    {
      if (dataGridViewAllianceRanks.Rows.Count > 0)
      {
        string path = System.Environment.CurrentDirectory;
        if (!path.EndsWith("\\"))
        {
          path = path + "\\";
        }

        using (var writer = new StreamWriter(path + "AllianceRankingExport.csv", false))
        {
          writer.WriteLine("id,name,rank,points,members,avg,cities");
          foreach (var allianceGetRangeResponse in AllianceGetRangeResponses)
          {
            StringBuilder data = new StringBuilder()
                                 .Append(allianceGetRangeResponse.Id)
                                 .Append(",")
                                 .Append(allianceGetRangeResponse.Name)
                                 .Append(",")
                                 .Append(allianceGetRangeResponse.Rank)
                                 .Append(",")
                                 .Append(allianceGetRangeResponse.Points)
                                 .Append(",")
                                 .Append(allianceGetRangeResponse.Members)
                                 .Append(",")
                                 .Append(allianceGetRangeResponse.Avg)
                                 .Append(",")
                                 .Append(allianceGetRangeResponse.Cities);
            writer.WriteLine(data);
          }
          writer.Flush();
          writer.Close();
        }
        MessageBox.Show("Export done.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
      else
      {
        MessageBox.Show("You must first load the alliance list by clicking the Get Alliance Ranks buttion", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
      }
    }
  }

  internal enum AllianceRanksFieldNames
  {
    Id,
    AllianceName,
    Rank,
    Points,
    Members,
    Avg,
    Cities,
  }
}
