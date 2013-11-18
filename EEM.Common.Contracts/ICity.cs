using System.Collections.Generic;

namespace EEM.Common.Contracts
{
  public interface ICity
  {
    int AllianceId { get; set; }
    string AllianceName { get; set; }
    object BuildingQueue { get; set; }
    object Carts { get; set; }
    int EnlightenmentTimeReference { get; set; }
    bool HasCastle { get; set; }
    bool HasWaterAccess { get; set; }
    int Id { get; set; }
    string Name { get; set; }
    string Note { get; set; }
    int PalaceLevel { get; set; }
    int PlayerId { get; set; }
    string PlayerName { get; set; }
    string Reference { get; set; }
    object Resources { get; set; }
    int Score { get; set; }
    object Ships { get; set; }
    List<IMilitaryGrouping> Units { get; set; }
    object UnitOrders { get; set; }
    int UnitLimit { get; set; }
    int UnitCount { get; set; }
    object UnitQueue { get; set; }
    int X { get; set; }
    int Y { get; set; }
    int Continent { get; }
    string Location { get; }
    void Update(ICityResponseToBeFixed cityResponseToBeFixed);
    void Update(IGetPublicCityInfoResponse cityInfoResponse);
    void Update(IPollResponse cityResponseToBeFixed);
    string ToString();
    bool HasPalace();
  }
}