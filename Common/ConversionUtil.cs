using System;

namespace EEM.Common
{
  public static class ConversionUtil
  {

    public static AttackType ConvertAttackType(int attackId)
    {
      switch (attackId)
      {
        case 1:
          return AttackType.Scout;

        case 2:
          return AttackType.Plunder;

        case 3:
          return AttackType.Assault;

        case 4:
          return AttackType.Support;

        case 5:
          return AttackType.Siege;

        case 8:
          return AttackType.Raid;

        case 100:
          return AttackType.Settle;

        default:
          throw new Exception("INVALID_AttackType");
      }
    }

    /// <summary>
    /// Used to convert the report id value into something readable.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public static ReportType ConvertReportType(string id)
    {
      switch (id)
      {
        case "1011":
          return ReportType.Scout;
        case "1115":
          return ReportType.Sieged_by;
        case "2040":
          return ReportType.Resources_send_by;
        case "1114":
          return ReportType.Support_arrived_from;
        case "1112":
          return ReportType.Assaulted_by;
        case "1111":
          return ReportType.Scouted_by;
        case "1144":
          return ReportType.Support_sent_by;
        case "1135":
          return ReportType.Siege_canceled_by;
        case "1018":
          return ReportType.Raided;
        case "2010":
          return ReportType.Goods_Arrived_from;
        case "2110":
          return ReportType.Goods_Arrived_at;
        case "3010":
          return ReportType.Troops_starved_at;
        case "1015":
          return ReportType.Siege;
        case "1035":
          return ReportType.Support_sent_from;
        case "1034":
          return ReportType.Support_sent_home_from;
        case "1075":
          return ReportType.Reinforcement_joins_seige_from;
        case "1069":
          return ReportType.Settle_Cancel_to_late_at;
        case "1013":
          return ReportType.Assault;
        case "1055":
          return ReportType.Siege_conquered;
        default:
          return ReportType.Unknown;
      }      
    }

    public static TradeTransportType ConvertTradeTransportType(int id)
    {
      switch (id)
      {
        case 1:
          return TradeTransportType.Cart;
        case 2:
          return TradeTransportType.Ship;
        default:
          throw new Exception("INVALID_TRANSPORT_TYPE");
      }
    }

    public static int ConvertTradeTransportType(TradeTransportType tradeTransportType)
    {
      switch (tradeTransportType)
      {
        case TradeTransportType.Cart:
          return 1;
        case TradeTransportType.Ship:
          return 2;
        default:
          throw new Exception("INVALID_TRANSPORT_TYPE");
      }
    }

    /// <summary>
    /// ToDo: Put this into a database
    /// </summary>
    /// <param name="resourceId"></param>
    /// <returns></returns>
    public static ResourceType ConvertResource(int resourceId)
    {
      switch (resourceId)
      {
        case 0:
          return ResourceType.Gold;

        case 1:
          return ResourceType.Wood;

        case 2:
          return ResourceType.Stone;

        case 3:
          return ResourceType.Iron;

        case 4:
          return ResourceType.Food;

        case -34:
          return ResourceType.PlatinumToolkit;

        default:
          throw new Exception("INVALID_RESOURCE");
      }
    }

    public static int ConvertResource(ResourceType resourceType)
    {
      switch (resourceType)
      {
        case ResourceType.Gold:
          return 0;

        case ResourceType.Wood:
          return 1;

        case ResourceType.Stone:
          return 2;

        case ResourceType.Iron:
          return 3;

        case ResourceType.Food:
          return 4;

        case ResourceType.PlatinumToolkit:
          return -34;

        default:
          throw new Exception("INVALID_RESOURCE");
      }
    }

    /// <summary>
    /// ToDo: Put this into a database
    /// </summary>
    /// <param name="militaryUnitId"></param>
    /// <returns></returns>
    public static MilitaryUnitType ConvertMilitaryUnit(int militaryUnitId)
    {
      switch (militaryUnitId)
      {

        case 2:
          return MilitaryUnitType.Ballista;

        case 3:
          return MilitaryUnitType.Ranger;
        
        case 4:
          return MilitaryUnitType.Guardian;

        case 5:
          return MilitaryUnitType.Templar;

        case 6:
          return MilitaryUnitType.Berserker;

        case 7:
          return MilitaryUnitType.Mage;

        case 8:
          return MilitaryUnitType.Scout;

        case 9:
          return MilitaryUnitType.Crossbowman;

        case 10:
          return MilitaryUnitType.Paladin;

        case 11:
          return MilitaryUnitType.Knight;

        case 12:
          return MilitaryUnitType.Warlock;

        case 13:
          return MilitaryUnitType.Ram;

        case 14:
          return MilitaryUnitType.Catapult;

        case 15:
          return MilitaryUnitType.Frigate;

        case 16:
          return MilitaryUnitType.Sloop;

        case 17:
          return MilitaryUnitType.WarGalleon;

        case 48:
          return MilitaryUnitType.Dragon;

        default:
          throw new Exception("INVALID_MilitaryUnit");
      }
    }

    public static DateTime ConvertJsonDate(long jsondate)
    {
      return new DateTime((jsondate * 10000000) + 621355968000000000);
    }

    /// <summary>
    /// Converts a date that is assumed to be have an offset from UTC of sourceUtcOffset to an offset from UTC of targetUtcOffset
    /// </summary>
    /// <param name="sourceDate">The date and time that needs to be converted</param>
    /// <param name="sourceUtcOffset">The offset from UTC of the sourceDate</param>
    /// <param name="targetUtcOffset">The offset from UTC of the timezone that the DateTime should be converted to.</param>
    /// <returns>A DateTime that has been adjusted to the offset from UTC of targetUtcOffset</returns>
    public static DateTime ConvertDateTime2AnotherTimezone(DateTime sourceDate, int sourceUtcOffset, int targetUtcOffset)
    {
      DateTime asUtcDateTime = sourceDate.AddHours(sourceUtcOffset * -1);
      DateTime targetDateTime = asUtcDateTime.AddHours(targetUtcOffset);
      return targetDateTime;
    }

    internal static object ConvertBuildingType(BuildingType buildingtype)
    {
      throw new NotImplementedException();
    }
  }
}
