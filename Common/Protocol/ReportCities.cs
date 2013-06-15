using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class ReportCities
  {

    #region Json Vars
    public string a { get; set; } // Alliance Name
    public int ai { get; set; } // Alliance Id
    public int c { get; set; } // Unknown
    public string cn { get; set; } // City Name
    public int co { get; set; } // Unknown
    public int p { get; set; } // Player Id
    public string pn { get; set; } // Player Name
    public int r { get; set; } // Unknown
    public List<ReportUnits> u { get; set; } // Array of Units
    #endregion

    public string AllianceName
    {
      get { return a; }
    }
 
    public int AllianceId
    {
      get { return ai; }
    }

    public string CityName
    {
      get { return cn; }
    }

    public int PlayerId 
    {
      get { return p; } 
    }

    public string PlayerName
    {
      get { return pn; }
    }

  }
}