using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class CityResponseD
  {
    // ReSharper disable InconsistentNaming
    public int v { get; set; }
    public string n { get; set; }
    public int uc { get; set; }
    public int ul { get; set; }
    public int bc { get; set; }
    public int bl { get; set; }
    public int ol { get; set; }
    public int tb { get; set; }
    public int tr { get; set; }
    public bool sh { get; set; }
    public bool s { get; set; }
    public bool cr { get; set; }
    public int w { get; set; }
    public bool cpr { get; set; }
    public int st { get; set; }
    public int et { get; set; }
    public int bbl { get; set; }
    public int tl { get; set; }
    public int wl { get; set; }
    public int mpl { get; set; }
    public int hrl { get; set; }
    public int mtl { get; set; }
    public int pl { get; set; }
    public double btam { get; set; }
    public double btpm { get; set; }
    public double hs { get; set; }
    public double fc { get; set; } // Food consumption ?
    public double fcs { get; set; }
    public double fcq { get; set; }
    public int pp { get; set; }
    public double g { get; set; }
    public string nr { get; set; }
    public string ns { get; set; }
    public bool ad { get; set; }
    public bool ae { get; set; }
    public int f { get; set; }
    public int at { get; set; }
    public bool k { get; set; }
    public List<int> ts { get; set; }
    public List<object> r { get; set; }
    public int pwr { get; set; }
    public int psr { get; set; }
    public int pd { get; set; }
    public List<object> q { get; set; }
    public List<object> uq { get; set; }
    public List<object> uo { get; set; }
    public List<object> su { get; set; }
    public List<object> iuo { get; set; }
    public List<MilitaryGrouping> u { get; set; } // units
    public List<object> t { get; set; }
    public List<object> to { get; set; } // trade out?
    public List<object> ti { get; set; } // trade in?
    public List<object> tf { get; set; }
    public List<object> rs { get; set; }
    public object mo { get; set; }
    public object ef { get; set; }
    public object tbc { get; set; }
    // ReSharper restore InconsistentNaming

    public string Name { get { return n; } }
    public bool HasCastle { get { return sh; } }
    public bool HasWaterAccess { get { return w == 1; } }
    public string Reference { get { return nr; } }
    public string Note { get { return ns; } }
    public object Carts { get { return t[0]; } }
    public object Ships { get { return t[1]; } }
    public object Resources { get { return r; } }
    public List<MilitaryGrouping> Units { get { return u; } }
    public object UnitOrders { get { return uo; } }
    public int UnitLimit { get { return ul; } }
    public int UnitCount { get { return uc; } }
    public object UnitQueue { get { return uq; } }
    public object BuildingQueue { get { return q; } }
  }
}
