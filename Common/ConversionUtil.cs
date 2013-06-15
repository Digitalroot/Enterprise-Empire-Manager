using System;

namespace EEM.Common
{
  public static class ConversionUtil
  {

    public static object StringToEnum( Type t, string value )
    {
      foreach ( var fi in t.GetFields() )
        if ( fi.Name == value )
          return fi.GetValue( null );    // We use null because
                                         // enumeration values
                                         // are static

      throw new Exception( string.Format("Can't convert {0} to {1}", value, t) );
    }


    public static AttackType ConvertAttackType(int attackId)
    {
      switch (attackId)
      {
        case 0:
          return AttackType.Unknown;

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

    public static int ConvertAttackType(AttackType attackType)
    {
      switch (attackType)
      {
        case AttackType.Unknown:
          return 0;

        case AttackType.Scout:
          return 1;

        case AttackType.Plunder:
          return 2;

        case AttackType.Assault:
          return 3;

        case AttackType.Support:
          return 4;

        case AttackType.Siege:
          return 5;

        case AttackType.Raid:
          return 8;

        case AttackType.Settle:
          return 100;

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
    [Obsolete("Use the enum values for Resources.")]
    public static Resources ConvertResource(int resourceId)
    {
      switch (resourceId)
      {
        case 0:
          return Resources.Gold;

        case 1:
          return Resources.Wood;

        case 2:
          return Resources.Stone;

        case 3:
          return Resources.Iron;

        case 4:
          return Resources.Food;

        case 5:
          return Resources.Darkwood;

        case 6:
          return Resources.Runestone;

        case 7:
          return Resources.Veritium;

        case 8:
          return Resources.Trueseed;

        default:
          throw new Exception("INVALID_RESOURCE");
      }
    }

    [Obsolete("Use the enum values for Resources.")]
    public static int ConvertResource(Resources resources)
    {
      switch (resources)
      {
        case Resources.Gold:
          return 0;

        case Resources.Wood:
          return 1;

        case Resources.Stone:
          return 2;

        case Resources.Iron:
          return 3;

        case Resources.Food:
          return 4;

        case Resources.Darkwood:
          return 5;

        case Resources.Runestone:
          return 6;

        case Resources.Veritium:
          return 7;

        case Resources.Trueseed:
          return 8;

        default:
          throw new Exception("INVALID_RESOURCE");
      }
    }

    /// <summary>
    /// ToDo: Put this into a database
    /// </summary>
    /// <param name="militaryUnitId"></param>
    /// <returns></returns>
    [Obsolete("Use the enum values for MilitaryUnits.")]
    public static MilitaryUnits ConvertMilitaryUnit(int militaryUnitId)
    {
      switch (militaryUnitId)
      {
        case 1:
          return MilitaryUnits.CityGuard;

        case 2:
          return MilitaryUnits.Ballista;

        case 3:
          return MilitaryUnits.Ranger;
        
        case 4:
          return MilitaryUnits.Guardian;

        case 5:
          return MilitaryUnits.Templar;

        case 6:
          return MilitaryUnits.Berserker;

        case 7:
          return MilitaryUnits.Mage;

        case 8:
          return MilitaryUnits.Scout;

        case 9:
          return MilitaryUnits.Crossbowman;

        case 10:
          return MilitaryUnits.Paladin;

        case 11:
          return MilitaryUnits.Knight;

        case 12:
          return MilitaryUnits.Warlock;

        case 13:
          return MilitaryUnits.Ram;

        case 14:
          return MilitaryUnits.Catapult;

        case 15:
          return MilitaryUnits.Frigate;

        case 16:
          return MilitaryUnits.Sloop;

        case 17:
          return MilitaryUnits.WarGalleon;

        default:
          throw new Exception("INVALID_MilitaryUnit");
      }
    }

    public static DateTime ConvertJsonDate(long jsondate)
    {
      return new DateTime((jsondate * 10000000) + 621355968000000000);
    }

    public static DateTime ConvertFromUnixTimestamp(double timestamp)
    {
      DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
      return origin.AddSeconds(timestamp);
    }


    public static double ConvertToUnixTimestamp(DateTime date)
    {
      DateTime origin = new DateTime(1970, 1, 1, 0, 0, 0, 0);
      TimeSpan diff = date - origin;
      return diff.TotalSeconds;
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

    public static object ConvertBuildingType(BuildingType buildingtype)
    {
      throw new NotImplementedException();
    }

    [Obsolete("Use the enum values for title.")]
    public static Titles ConvertTitle(int titleId)
    {
      switch (titleId)
      {
        case 1:
          return Titles.Sir;

        case 2:
          return Titles.Knight;

        case 3:
          return Titles.Baron;

        case 5:
          return Titles.Earl;

        case 6:
          return Titles.Marquess;

        case 7:
          return Titles.Prince;

        case 8:
          return Titles.Duke;

        case 9:
          return Titles.King;

        case 10:
          return Titles.Emperor;

        default:
          throw new Exception("INVALID_Title");
      }
    }

    [Obsolete("Use the enum values for title.")]
    public static int ConvertTitle(Titles titlename)
    {
      switch (titlename)
      {
        case Titles.Sir:
          return 1;

        case Titles.Knight:
          return 2;

        case Titles.Baron:
          return 3;

        case Titles.Earl:
          return 5;

        case Titles.Marquess:
          return 6;

        case Titles.Prince:
          return 7;

        case Titles.Duke:
          return 8;

        case Titles.King:
          return 9;

        case Titles.Emperor:
          return 10;

        default:
          throw new Exception("INVALID_Title");
      }
    }
  }
}
