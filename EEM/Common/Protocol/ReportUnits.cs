using EEM.Common.Contracts;

namespace EEM.Common.Protocol
{
  public class ReportUnits
  {
    public int l { get; set; }
    public int o { get; set; }
    public int t { get; set; }

    public int Survived
    {
      get { return l; }
    }

    public int Ordered
    {
      get { return o; }
    }

    public MilitaryUnits Units
    {
      get { return ConversionUtil.ConvertMilitaryUnit(t); }
    }
  }
}