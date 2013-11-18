using System.Collections.Generic;

namespace EEM.Common.Contracts
{
  public interface IGetPublicPlayerInfoResponse
  {
    int a { get; set; }
    string an { get; set; }
    List<ICityResponseToBeFixed> c { get; set; }
    int AllianceId { get; }
    string AllianceName { get; }
    List<ICityResponseToBeFixed> CitiesList { get; }
  }
}