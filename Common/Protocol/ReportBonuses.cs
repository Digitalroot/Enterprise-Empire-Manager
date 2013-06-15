namespace EEM.Common.Protocol
{
  public class ReportBonuses : JsonResponce
  {
    public float m { get; set; } // 1.79673266 = 80% Morale
    public int n { get; set; } // Night Protection
    public int t { get; set; } // Unknown

    public float Morale // ToDo: Change to int and %
    { 
      get { return m; } 
    }

    public int NightProtection
    { 
      get { return n; } 
    }

  }
}