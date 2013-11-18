using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EEM.Common.Protocol;
using Newtonsoft.Json;

namespace EEM.Common.Adapters
{
  public partial class LoUAdapter
  {
    /// <summary>
    /// Abandons a city.
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    public string AbandonCity(string cityId)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        cityid = cityId
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.AbandonCity, json);
      return result;
    }

    /// <summary>
    /// Cancels a build or an upgrade of a building.
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="buildingId"></param>
    /// <param name="queueId"></param>
    /// <returns></returns>
    public string CancelBuild(string cityId, int buildingId, int queueId)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        cityid = cityId,
        queueid = queueId
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.CancelBuild, json);
      return result;
    }

    /// <summary>
    /// Creates a moon stone
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public string CreateMoonStone(string cityId, int buildingId)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        cityid = cityId,
        buildingid = buildingId
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.CreateMoonStone, json);
      return result;
    }

    /// <summary>
    /// Demolish a Building
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public string DemolishBuilding(string cityId, int buildingId)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        cityid = cityId,
        buildingid = buildingId
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.DemolishBuilding, json);
      return result;
    }

    /// <summary>
    /// Downgrades a building
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="buildingId"></param>
    /// <param name="buildingtype"></param>
    /// <returns></returns>
    public string DowngradeBuilding(string cityId, int buildingId, BuildingType buildingtype)
    {
      //{"session":"25ee3b74-a4ee-42d4-b827-2bd438764ffa","cityid":"20381930","buildingid":68360,"buildingType":7}
      var json = new JsonRequest(new
      {
        session = SessionId,
        cityid = cityId,
        buildingid = buildingId,
        buildingType = ConversionUtil.ConvertBuildingType(buildingtype)
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.DowngradeBuilding, json);
      return result;
    }

    /// <summary>
    /// Gets info about a building in a city.
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="buildingId"></param>
    /// <returns></returns>
    public string GetBuildingInfo(string cityId, int buildingId)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     cityid = cityId,
                                     buildingid = buildingId
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetBuildingInfo, json);
      return result;
    }

    /// <summary>
    /// Gets info about upgrading a building.
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="buildingplace"></param>
    /// <returns></returns>
    public string GetBuildingUpgradeInfo(string cityId, int buildingplace)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     cityid = cityId,
                                     buildingPlace = buildingplace
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetBuildingUpgradeInfo, json);
      return result;
    }

    public CityResponse GetCityDetails(int cityId)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        requestid = ++RequestCount,
        requests = String.Format("CITY:{0}\f", cityId)
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.Poll, json);
      var jsonArray = JsonConvert.DeserializeObject<ArrayList>(result);
      CityResponse cityResponse = null;

      if (jsonArray != null)
      {
        foreach (var response in jsonArray)
        {
          var deserializeObject = JsonConvert.DeserializeObject<PollResponse<object>>(response.ToString());
          if (deserializeObject.C == "CITY")
          {
            cityResponse = JsonConvert.DeserializeObject<CityResponse>(response.ToString());
          }
        }
      }

      return cityResponse;
    }

    /// <summary>
    /// Gets the distance from the current city to the target city.
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    public GetDistanceResponse GetDistance(string cityId)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     target = cityId
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetDistance, json);
      return JsonConvert.DeserializeObject<GetDistanceResponse>(result);
    }

    /// <summary>
    /// Query LoU server for the number of new reports. 
    /// </summary>
    /// <returns></returns>
    public int GetNumberOfNewReports()
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     requestid = ++RequestCount,
                                     requests = "REPORT:\f"
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.Poll, json);
      var jsonArray = JsonConvert.DeserializeObject<ArrayList>(result);
      var deserializedNewReportsJsonResponse = JsonConvert.DeserializeObject<PollResponse<NewReportsResponce>>(jsonArray[0].ToString());
      return deserializedNewReportsJsonResponse.D.NumberOfNewReports;
    }

    /// <summary>
    /// This is used when the send army button is click to send units to another city. I think it gets target into and distance/time.
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="xcord"></param>
    /// <param name="ycord"></param>
    /// <returns></returns>
    public GetOrderTargetInfoResponse GetOrderTargetInfo(int cityId, string xcord, string ycord)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     cityid = cityId,
                                     x = xcord,
                                     y = ycord
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetOrderTargetInfo, json);
      return JsonConvert.DeserializeObject<GetOrderTargetInfoResponse>(result);
    }

    /// <summary>
    /// Query LoU server for a player object for the current player.
    /// </summary>
    /// <returns></returns>
    public GetPlayerResponse GetPlayerInfo()
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetPlayerInfo, json);
      return JsonConvert.DeserializeObject<GetPlayerResponse>(result);
    }

    /// <summary>
    /// Gets info about a city. 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    public GetPublicCityInfoResponse GetPublicCityInfo(int cityId)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        id = cityId,
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetPublicCityInfo, json);
      return JsonConvert.DeserializeObject<GetPublicCityInfoResponse>(result);      
    }

    /// <summary>
    /// Gets info about a city. 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    public int QueueGetPublicCityInfo(int cityId)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        id = cityId,
      });

      return MessageExchangeClient.QueueServerCommand(ServerCommand.GetPublicCityInfo, json);
    }

    /// <summary>
    /// Gets info about a player. 
    /// </summary>
    /// <param name="playerId"></param>
    /// <returns></returns>
    public GetPublicPlayerInfoResponse GetPublicPlayerInfo(int playerId)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        id = playerId,
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetPublicPlayerInfo, json);
      return JsonConvert.DeserializeObject<GetPublicPlayerInfoResponse>(result);
    }

    /// <summary>
    /// Get a count of reports. 
    /// </summary>
    /// <param name="reportFolder">defaults to 0</param>
    /// <param name="cityid">defaults to -1</param>
    /// <returns></returns>
    public int GetReportCount(int reportFolder = 0, int cityid = -1)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     folder = reportFolder, 
                                     city = cityid
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.ReportGetCount, json);
      return Int32.Parse(result);
    }

    /// <summary>
    /// Gets the details of a report.
    /// </summary>
    /// <param name="reportId">Report Id to get details of.</param>
    /// <returns></returns>
    public ReportDetails GetReportDetails(int reportId)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     id = reportId
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetReport, json);
      return JsonConvert.DeserializeObject<ReportDetails>(result);
    }

    /// <summary>
    /// Query LoU server for a range of headers for reports. 
    /// </summary>
    /// <param name="startAt">Start, i.e. 0</param>
    /// <param name="endAt">End, i.e. 100</param>
    /// <param name="cityid">defaults to -1</param>
    /// <param name="sortby">defaults to 1</param>
    /// <param name="asc">defaults to false</param>
    /// <returns>List of Report Objects.</returns>
    public List<ReportResponse> GetReportHeaders(int startAt, int endAt, int cityid = -1, int sortby = 1, bool asc = false)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     folder = 0,
                                     city = cityid,
                                     start = startAt,
                                     end = endAt,
                                     sort = sortby,
                                     ascending = asc
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.ReportGetHeader, json);
      return JsonConvert.DeserializeObject<List<ReportResponse>>(result);
    }

    /// <summary>
    /// Query LoU server for the headers of reports. 
    /// </summary>
    /// <param name="count">Number of Reports you want returned</param>
    /// <returns></returns>
    public List<ReportResponse> GetReportHeaders(int count)
    {
      return GetReportHeaders(0, --count);
    }

    /// <summary>
    /// Query LoU server for a player object for the current player.
    /// </summary>
    /// <returns></returns>
    public ServerInfoResponse GetServerInfo()
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetServerInfo, json);
      return JsonConvert.DeserializeObject<ServerInfoResponse>(result);
    }

    /// <summary>
    /// Gets info about what units are in queue and what a city can build.
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    public string GetUnitProductionInfo(string cityId)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     cityid = cityId
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetUnitProductionInfo, json);
      return result;
    }

    /// <summary>
    /// Resets and Opens a session.
    /// </summary>
    /// <param name="sessionId"></param>
    /// <returns></returns>
    public OpenSessionResponse OpenSession(string sessionId)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        reset = true
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.OpenSession, json);
      return JsonConvert.DeserializeObject<OpenSessionResponse>(result); ;
    }

    /// <summary>
    /// Orders Units.
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="unitTypeAndCount"></param>
    /// <param name="cords"></param>
    /// <param name="attackType"></param>
    /// <param name="whenToSend"></param>
    /// <param name="sendNow"></param>
    /// <returns></returns>
    public string OrdersUnit(int cityId, Units[] unitTypeAndCount, string cords, AttackType attackType, DateTime? whenToSend)
    {
      // {"session":"00000000-a4ee-42d4-b827-2bd438764ffa","cityid":"20971776","units":[{"t":"10","c":2748}],"targetPlayer":"Dienekes","targetCity":"254:321","order":4,"transport":1,"timeReferenceType":1,"referenceTimeUTCMillis":0}

      // Remove all the null values. ToDo: Clean this up.
      int counter = unitTypeAndCount.Count(unitTandC => unitTandC != null);
      Units[] cleanUnitTypeAndCount = new Units[counter];
      int transportType = 1;

      counter = 0;
      foreach (Units unitse in unitTypeAndCount)
      {
        if (unitse != null)
        {
          cleanUnitTypeAndCount[counter++] = unitse;

          // If a ship is in the order send by ship. 
          if (unitse.t == MilitaryUnits.WarGalleon || unitse.t == MilitaryUnits.Sloop || unitse.t == MilitaryUnits.Frigate)
          {
            transportType = 2;
          }
        }
      }

      int timeReferenceTypeValue = 0;
      double referenceTimeUTCMillisValue = 0;

      if (whenToSend == null)
      {
        timeReferenceTypeValue = 1;
        referenceTimeUTCMillisValue = 0;
      }
      else
      {
        timeReferenceTypeValue = 3;
        var tempDateTime = (DateTime) whenToSend;
        referenceTimeUTCMillisValue = (int) ConversionUtil.ConvertToUnixTimestamp(tempDateTime.AddHours(TimeService.ServerTimeZoneOffset * -1));
      }

      string[] cordxy = cords.Split(Convert.ToChar(":"));

      var json = new JsonRequest(new
      {
        session = SessionId,
        cityid = cityId,
        units = cleanUnitTypeAndCount,
        targetPlayer = GetOrderTargetInfo(cityId, cordxy[0], cordxy[1]).PlayerName,
        targetCity = cords,
        order = attackType,
        transport = transportType,
        timeReferenceType = timeReferenceTypeValue, // 1 = Now, 2 = Departure Time, 3 = Arrival Time
        referenceTimeUTCMillis = referenceTimeUTCMillisValue + "500",
        raidTimeReferenceType = 0,
        raidReferenceTimeUTCMillis = 0
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.OrderUnits, json);
      return result;
    }

    /// <summary>
    /// Renames a City
    /// </summary>
    /// <remarks>Use this to rename a cityId.</remarks>
    /// <param name="cityId">Id of a city.</param>
    /// <param name="newName">New name to rename the city to.</param>
    /// <returns>True on Success</returns>
    public bool RenameCity(string cityId, string newName)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     cityid = cityId,
                                     name = newName
                                   });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.RenameCity, json);
      return result == "true";
    }

    /// <summary>
    /// Sends a chat message to the server.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    public void SendChat(string message)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId, 
                                     requestid = ++RequestCount, 
                                     requests = String.Format("CHAT:{0}\f", message)
                                   });

      PollingService.ListOfPollIds.Add(MessageExchangeClient.QueueServerCommand(ServerCommand.Poll, json));
    }

    /// <summary>
    /// Send an In Game Mail
    /// </summary>
    /// <param name="to">Who to send the mail to.</param>
    /// <param name="subjectLine">Subject</param>
    /// <param name="bodytext">Body</param>
    /// <returns></returns>
    public bool SendMail(string to, string subjectLine, string bodytext)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        target = to,
        subject = subjectLine,
        body = bodytext
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.IGMSendMsg, json);
      return result == "true";
    }

    /// <summary>
    /// Send an In Game Mail to more then one person.
    /// </summary>
    /// <param name="toList">Who to send the mail to.</param>
    /// <param name="subjectLine">Subject</param>
    /// <param name="bodytext">Body</param>
    /// <returns>An Array of results. Index matches the toList index. If the value = 0 then the mail worked without error.</returns>
    public List<string> SendBulkMail(List<string> toList, string subjectLine, string bodytext)
    {
      var to = new StringBuilder();
      foreach (string name in toList)
      {
        to.Append(name).Append("; ");
      }

      var json = new JsonRequest(new
      {
        session = SessionId,
        targets = to.ToString().TrimEnd(' ').TrimEnd(';'),
        subject = subjectLine,
        body = bodytext
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.IGMBulkSendMsg, json);
      return JsonConvert.DeserializeObject<List<string>>(result);
    }

    public List<GetPublicAllianceMemberListResponse> GetPublicAllianceMemberList(int allianceId)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        id = allianceId
      });


      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.GetPublicAllianceMemberList, json);
      return JsonConvert.DeserializeObject<List<GetPublicAllianceMemberListResponse>>(result);
    }

    /// <summary>
    /// ToDo: change this to first request the total number of alliance on a server and then use that as the end value.
    /// </summary>
    /// <returns></returns>
    public List<AllianceGetRangeResponse> GetListOfAlliances()
    {

      int numberOfAlliances = AllianceGetCountAndIndex();

      var json = new JsonRequest(new {
                                       session = SessionId,
                                       start = 0,
                                       end = --numberOfAlliances,
                                       continent = -1,
                                       sort = 0,
                                       ascending = true
                                     });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.AllianceGetRange, json);
      return JsonConvert.DeserializeObject<List<AllianceGetRangeResponse>>(result);
    }

    public int AllianceGetCountAndIndex()
    {
      var json = new JsonRequest(new {
                                       session = SessionId,
                                       continent = -1,
                                       sort = 0,
                                       ascending = true
                                     });
      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.AllianceGetCountAndIndex, json); // [3126,0]
      result = result.TrimStart('[').TrimEnd(']');
      string[] split = result.Split(',');


      return Int32.Parse(split[0]);
    }

    /// <summary>
    /// Sends a raw request to the server. This bypasses rules for json formatting and should not be used unless you know what you are doing.
    /// </summary>
    /// <param name="rawInput"></param>
    /// <param name="url"></param>
    /// <returns></returns>
    public string SendRawJson(string rawInput, string url)
    {
      ErrorIfNotConnected();
      return MessageExchangeClient.RawRequest(rawInput, url);
    }

    /// <summary>
    /// Sends resources to a city.
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="resources"></param>
    /// <param name="transportType"></param>
    /// <param name="toPlayer"></param>
    /// <param name="toCityX"></param>
    /// <param name="toCityY"></param>
    /// <returns></returns>
    public int TradeDirect(string cityId, List<TradeResource> resources, TradeTransportType transportType, string toPlayer, string toCityX, string toCityY)
    {
      ErrorIfNotConnected();
      return TradeDirect(cityId, resources, transportType, toPlayer, toCityX + ":" + toCityY);
    }

    /// <summary>
    /// Sends resources to a city.
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="resources"></param>
    /// <param name="transportType"></param>
    /// <param name="toPlayer"></param>
    /// <param name="toCityByXandYCords"></param>
    /// <returns></returns>
    public int TradeDirect(string cityId, List<TradeResource> resources, TradeTransportType transportType, string toPlayer, string toCityByXandYCords)
    {
      // {"session":"00000000-c12d-4a29-a2f3-a6682c9c9470","cityid":"10485779","res":[{"t":1,"c":308645},{"t":3,"c":228064},{"t":4,"c":50384}],"tradeTransportType":2,"targetPlayer":"MyName","targetCity":"20:160"}
      // {"session":"00000000-c12d-4a29-a2f3-a6682c9c9470","cityid":"10485779","res":[{"t":1,"c":225000},{"t":2,"c":575000}],"tradeTransportType":1,"targetPlayer":"MyName","targetCity":"20:160"}

      var json = new JsonRequest(new
      {
        session = SessionId,
        cityid = cityId,
        res = resources,
        tradeTransportType = ConversionUtil.ConvertTradeTransportType(transportType),
        targetPlayer = toPlayer,
        targetCity = toCityByXandYCords
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.TradeDirect, json);
      return Int32.Parse(result);
    }

    /// <summary>
    /// Upgrades a building.
    /// </summary>
    /// <param name="cityId"></param>
    /// <param name="buildingId"></param>
    /// <param name="buildingtype"></param>
    /// <param name="ispaid"></param>
    /// <returns></returns>
    public string UpgradeBuilding(string cityId, int buildingId, BuildingType buildingtype, bool ispaid)
    {
      var json = new JsonRequest(new
      {
        session = SessionId,
        cityid = cityId,
        buildingid = buildingId,
        buildingType = ConversionUtil.ConvertBuildingType(buildingtype),
        isPaid = ispaid
      });

      var result = MessageExchangeClient.ExecuteServerCommand(ServerCommand.UpgradeBuilding, json);
      return result;
    }
  }
}
