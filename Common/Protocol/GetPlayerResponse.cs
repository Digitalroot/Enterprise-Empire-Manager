using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class GetPlayerResponse : JsonResponce
  {
    public int AllianceId { get; set; }
    public string AllianceName { get; set; }
    public List<CityResponse> Cities { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
  }
}
