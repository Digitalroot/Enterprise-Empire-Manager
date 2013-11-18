namespace EEM.Common.Contracts
{
  public interface IMilitaryGrouping
  {
    MilitaryUnits t { get; set; }
    int c { get; set; }
    int tc { get; set; }
    int s { get; set; }
    MilitaryUnits UnitType { get; }
    int UnitsInCity { get; }
    int TotalUnits { get; }
  }
}