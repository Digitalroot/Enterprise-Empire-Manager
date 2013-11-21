using System.Collections.Generic;

namespace EEM.Common.Contracts
{
  public interface IGetPublicCityInfoResponse
  {
    int a { get; set; }
    string an { get; set; }
    int et { get; set; }
    int f { get; set; }
    string n { get; set; }
    int p { get; set; }
    int pd { get; set; }
    int pl { get; set; }
    string pn { get; set; }
    int po { get; set; }
    List<object> r { get; set; }
    List<object> ra { get; set; }
    int s { get; set; }
    int st { get; set; }
    bool u { get; set; }
    int w { get; set; }
    int x { get; set; }
    int y { get; set; }
    int AllianceId { get; }
    string AllianceName { get; }
    int EnlightenmentTimeReference { get; }
    string CityName { get; }
    int PlayerId { get; }
    string PlayerName { get; }
    int PalaceLevel { get; }
    bool HasCastle { get; }
    bool HasWaterAccess { get; }
    bool UpgradingPalace { get; }
    int ShrineTypeId { get; }
    int Score { get; }
    string Location { get; }
  }
}