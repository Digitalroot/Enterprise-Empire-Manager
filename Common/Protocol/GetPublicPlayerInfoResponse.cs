using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class  GetPublicPlayerInfoResponse : JsonResponce
  {
    // ReSharper disable InconsistentNaming
    public int a { get; set; } // Alliance Id
    public string an { get; set; } // Alliance Name
    public List<CityResponseToBeFixed> c { get; set; } // Array of cities;
    // ReSharper restore InconsistentNaming

    public int AllianceId { get { return a; } }
    public string AllianceName { get { return an; } }
    public List<CityResponseToBeFixed> CitiesList { get { return c; } }
  }
}