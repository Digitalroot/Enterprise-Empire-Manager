using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class ALLATResponseD
  {
    // ReSharper disable InconsistentNaming
    public int v { get; set; } // List Version
    public List<AllianceAttack> a { get; set; } // Attack List
    // ReSharper restore InconsistentNaming
  }
}
