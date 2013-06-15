using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
