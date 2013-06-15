namespace EEM.Common
{
  public class MilitaryGrouping
  {
    #region Json Vars
    public MilitaryUnits t { get; set; } // Unit Type
    public int c { get; set; } // Units In City
    public int tc { get; set; } // Total Units
    public int s { get; set; } // Unknown
    #endregion

    public MilitaryUnits UnitType
    {
      get { return t; }
    }

    public int UnitsInCity
    {
      get { return c; }
    }

    public int TotalUnits
    {
      get { return tc; }
    }
  }
}
