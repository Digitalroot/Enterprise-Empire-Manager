using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class ReportDetails :JsonResponce
  {
    #region Json VArs
    public List<ReportCities> a { get; set; }
    public ReportBonuses b { get; set; } 
    public int cp { get; set; } // Unknown - Something to do with Claiming Power. 
    public int cpo { get; set; } // Unknown - Something to do with Claiming Power. 
    public ReportHeader h { get; set; }
    public List<ReportResources> r { get; set; }
    public int td { get; set; } // Unknown
    #endregion

    public ReportCities FromCity
    {
      get { return a[0]; }
    }

    public ReportCities ToCity
    {
      get { return a[1]; }
    }
  }
}
