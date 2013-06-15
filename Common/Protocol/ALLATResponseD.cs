using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
