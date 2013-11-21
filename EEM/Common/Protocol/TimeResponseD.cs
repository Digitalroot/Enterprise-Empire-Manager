using System;

namespace EEM.Common.Protocol
{
  public class TimeResponseD
  {
    // ReSharper disable InconsistentNaming
    public Int64 Ref { get; set; } // Servers reference point
    public int Step { get; set; } // Counter
    public int Diff { get; set; } // Offset between local and server time.
    public int o { get; set; } // Servers time zone offset.
    // ReSharper restore InconsistentNaming
  }
}
