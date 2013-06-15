using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class PlayerResponseD
  {
    // ReSharper disable InconsistentNaming
    public int v { get; set; } // Unknown
    public int a { get; set; } // Unknown
    public PlayerResponseG g { get; set; } // Unknown
    public PlayerResponseM m { get; set; } // Unknown
    public int d { get; set; } // Unknown
    public int t { get; set; } // Unknown
    public int p { get; set; } // Unknown
    public int r { get; set; } // Unknown
    public int ms { get; set; } // Unknown
    public int b { get; set; } // Unknown
    public int bi { get; set; } // Unknown
    public int bq { get; set; } // Unknown
    public int bqs { get; set; } // Unknown
    public int uqs { get; set; } // Unknown
    public int sos { get; set; } // Unknown
    public bool mbp { get; set; } // Unknown
    public int mbe { get; set; } // Unknown
    public bool mdp { get; set; } // Unknown
    public int mde { get; set; } // Unknown
    public bool mmp { get; set; } // Unknown
    public int mme { get; set; } // Unknown
    public bool mtp { get; set; } // Unknown
    public int mte { get; set; } // Unknown
    public List<CityResponse> c { get; set; } //  Cities
    public object pt { get; set; } // Unknown
    public object os { get; set; } // Unknown
    // ReSharper restore InconsistentNaming
  }
}