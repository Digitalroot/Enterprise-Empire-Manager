using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class GetPublicCityInfoResponse : JsonResponce
  {
    // ReSharper disable InconsistentNaming
    public int a { get; set; } // Alliance Id
    public string an { get; set; } // Alliance Name
    public int et { get; set; } // Enlightenment Time
    public int f { get; set; } // ?
    public string n { get; set; } // City Name
    public int p { get; set; } // Player Id
    public int pd { get; set; } // ? Palace Damage
    public int pl { get; set; } // Palace Level
    public string pn { get; set; } // Player Name
    public int po { get; set; } // Points
    public List<object> r { get; set; } // Res in City both palace and normal, t==1 = Wood In city/ t==2 = Stone in city / t==3 = Iron in city / t==4 = Food in city
    public List<object> ra { get; set; } // Res in transit, t==1 = Wood Incoming / t==2 = Stone Incoming / t==3 = Iron Incoming / t==4 = Food Incoming
    public int s { get; set; } // Castle - 1 = true
    public int st { get; set; } // Shrine Type
    public bool u { get; set; } // 1 = Palace is building or upgrading.
    public int w { get; set; } // Water - 1 = true
    public int x { get; set; } // x
    public int y { get; set; } // y
    // ReSharper restore InconsistentNaming

    public int AllianceId { get { return a; } }
    public string AllianceName { get { return an; } }
    public int EnlightenmentTimeReference { get { return et; } } // Todo: Connect to TimeService to return DateTime EnlightenmentTimeEnd
    public string CityName { get { return n; } }
    public int PlayerId { get { return p; } }
    public string PlayerName { get { return pn; } }
    public int PalaceLevel { get { return pl; } }
    public bool HasCastle { get { return s == 1; } }
    public bool HasWaterAccess { get { return w == 1; } }
    public bool UpgradingPalace { get { return u; } }
    public int ShrineTypeId { get { return st; } } // ToDo: Create ShrineType
    public int Score { get { return po; } }

    public string Location
    {
      get
      {
        return x + ":" + y;
      }
    }
  }
}
