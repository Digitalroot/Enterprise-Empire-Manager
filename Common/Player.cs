using EEM.Common.Protocol;

namespace EEM.Common
{
  public class Player
  {
    public int AllianceId { get; private set; }
    public string AllianceName { get; private set; }
    public string Name { get; private set; }
    public int Id { get; private set; }
  
    public Player(GetPlayerResponse response)
    {
      AllianceId = response.AllianceId;
      AllianceName = response.AllianceName;
      Name = response.Name;
      Id = response.Id;
    }
  }
}
