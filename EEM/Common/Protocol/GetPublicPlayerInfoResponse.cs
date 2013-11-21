using System.Collections.Generic;
using EEM.Common.Contracts;

namespace EEM.Common.Protocol
{
  public class  GetPublicPlayerInfoResponse : JsonResponce, IGetPublicPlayerInfoResponse
  {
    // ReSharper disable InconsistentNaming
    public int a { get; set; } // Alliance Id
    public string an { get; set; } // Alliance Name
    public List<ICityResponseToBeFixed> c { get; set; } // Array of cities;
    // ReSharper restore InconsistentNaming

    public int AllianceId { get { return a; } }
    public string AllianceName { get { return an; } }
    public List<ICityResponseToBeFixed> CitiesList { get { return c; } }
  }
}