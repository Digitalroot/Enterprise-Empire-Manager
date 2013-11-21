using EEM.Common.Contracts;

namespace EEM.Common
{
  public class UnitOrder
  {
    public string TargetCords { get; set; }
    public MilitaryUnits UnitType { get; set; }
    public int UnitCount { get; set; }
    public AttackType AttackType { get; set; }
  }
}
