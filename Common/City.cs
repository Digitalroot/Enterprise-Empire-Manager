using System;
using System.Collections.Generic;
using EEM.Common.Protocol;

namespace EEM.Common
{
  public class City
  {
    public int AllianceId { get; set; }
    public string AllianceName { get; set; }
    public object BuildingQueue { get; set; }
    public object Carts { get; set; }
    public int EnlightenmentTimeReference { get; set; }
    public bool HasCastle { get; set; }
    public bool HasWaterAccess { get; set; }
    public int Id { get; set; }
    public string Name { get; set; }
    public string Note { get; set; }
    public int PalaceLevel { get; set; }
    public int PlayerId { get; set; }
    public string PlayerName { get; set; }
    public string Reference { get; set; }
    public object Resources { get; set; }
    public int Score { get; set; }
    public object Ships { get; set; }
    public List<MilitaryGrouping> Units { get; set; }
    public object UnitOrders { get; set; }
    public int UnitLimit { get; set; }
    public int UnitCount { get; set; }
    public object UnitQueue { get; set; }
    public int X { get; set; }
    public int Y { get; set; }

    public City()
    {}

    public City(CityResponseToBeFixed cityResponseToBeFixed)
    {
      Update(cityResponseToBeFixed);
    }

    public City(GetPublicCityInfoResponse cityInfoResponse, int cityId)
    {
      Id = cityId;
      Update(cityInfoResponse);
    }

    public City(CityResponse cityResponse, int cityId)
    {
      Id = cityId;
      Update(cityResponse);
    }

    public void Update(CityResponseToBeFixed cityResponseToBeFixed)
    {
      Id = cityResponseToBeFixed.Id;
      X = cityResponseToBeFixed.x;
      Y = cityResponseToBeFixed.y;
      HasWaterAccess = cityResponseToBeFixed.w == 1;
      HasCastle = cityResponseToBeFixed.s == 1;
      Name = cityResponseToBeFixed.Name;
      Reference = cityResponseToBeFixed.Reference;
    }

    public void Update(GetPublicCityInfoResponse cityInfoResponse)
    {
      AllianceId = cityInfoResponse.AllianceId;
      AllianceName = cityInfoResponse.AllianceName;
      EnlightenmentTimeReference = cityInfoResponse.EnlightenmentTimeReference;
      HasCastle = cityInfoResponse.s == 1;
      HasWaterAccess = cityInfoResponse.w == 1;
      Name = cityInfoResponse.CityName;
      PlayerId = cityInfoResponse.PlayerId;
      PlayerName = cityInfoResponse.PlayerName;
      PalaceLevel = cityInfoResponse.pl;
      Score = cityInfoResponse.Score;
      X = cityInfoResponse.x;
      Y = cityInfoResponse.y;
    }

    public void Update(CityResponse cityResponseToBeFixed)
    {
      Carts = cityResponseToBeFixed.D.Carts; 
      HasCastle = cityResponseToBeFixed.D.HasCastle;
      HasWaterAccess = cityResponseToBeFixed.D.HasWaterAccess;
      Name = cityResponseToBeFixed.D.Name;
      Note = cityResponseToBeFixed.D.Note;
      Reference = cityResponseToBeFixed.D.Reference;
      Resources = cityResponseToBeFixed.D.Resources;
      Ships = cityResponseToBeFixed.D.Ships;
      Units = cityResponseToBeFixed.D.Units;
      UnitOrders = cityResponseToBeFixed.D.UnitOrders;
      UnitLimit = cityResponseToBeFixed.D.UnitLimit;
      UnitCount = cityResponseToBeFixed.D.UnitCount;
      UnitQueue = cityResponseToBeFixed.D.UnitQueue;
    }

    public int Continent
    {
      get
      {
        //$continent = (floor($y/100) . floor($x/100)) * 1
        return Int32.Parse(String.Format("{0}{1}", Y/100, X/100));
      }
    }

    public string Location
    {
      get
      {
        return X + ":" + Y;
      }
    }

    public override string ToString()
    {
      return Name;
    }

    public bool HasPalace()
    {
      return PalaceLevel > 0;
    }
  }
}