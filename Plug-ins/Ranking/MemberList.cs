using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;
using EEM.Common.Contracts;
using EEM.Common.Protocol;

namespace EEM.Plugin.Ranking
{
  public partial class MemberList : Form
  {
    private ILoUAdapter LoUAdapter { get; set; }
    private int AllianceId { get; set; }
    private List<IGetPublicAllianceMemberListResponse> ListResponses { get; set; }

    public MemberList(ILoUAdapter loUAdapter, int allianceId)
    {
      LoUAdapter = loUAdapter;
      AllianceId = allianceId;
      InitializeComponent();
    }

    private void MemberListLoad(object sender, EventArgs e)
    {
      ListResponses  = LoUAdapter.GetPublicAllianceMemberList(AllianceId);

      dataGridViewMemberList.Rows.Clear();

      foreach (GetPublicAllianceMemberListResponse allianceMemberListResponse in ListResponses)
      {
        int n = dataGridViewMemberList.Rows.Add();
        dataGridViewMemberList.Rows[n]
          .Cells[MemberListFieldNames.Id.ToString()]
          .Value = allianceMemberListResponse.Id;

        dataGridViewMemberList.Rows[n]
          .Cells[MemberListFieldNames.MemberName.ToString()]
          .Value = allianceMemberListResponse.Name;

        dataGridViewMemberList.Rows[n]
                  .Cells[MemberListFieldNames.Points.ToString()]
                  .Value = allianceMemberListResponse.Points;

        dataGridViewMemberList.Rows[n]
                  .Cells[MemberListFieldNames.Cities.ToString()]
                  .Value = allianceMemberListResponse.Cities;

        dataGridViewMemberList.Rows[n]
                  .Cells[MemberListFieldNames.Rank.ToString()]
                  .Value = allianceMemberListResponse.Rank;
      }

    }

    private void buttonExport_Click(object sender, EventArgs e)
    {
      if (dataGridViewMemberList.Rows.Count > 0)
      {
        string path = Environment.CurrentDirectory;
        if (!path.EndsWith("\\"))
        {
          path = path + "\\";
        }

        using (var writer = new StreamWriter(path + "AllianceMembersExport.csv", false))
        {
          writer.WriteLine("id,name,rank,points,cities");
          foreach (GetPublicAllianceMemberListResponse allianceMemberListResponse in ListResponses)
          {
            StringBuilder data = new StringBuilder()
              .Append(allianceMemberListResponse.Id)
              .Append(",")
              .Append(allianceMemberListResponse.Name)
              .Append(",")
              .Append(allianceMemberListResponse.Rank)
              .Append(",")
              .Append(allianceMemberListResponse.Points)
              .Append(",")
              .Append(allianceMemberListResponse.Cities);
            writer.WriteLine(data);
          }
          writer.Flush();
          writer.Close();
        }
        MessageBox.Show("Export done.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
      }
    }
  }

  internal enum MemberListFieldNames
  {
    Id,
    MemberName,
    Rank,
    Points,
    Cities,
  }
}
