using System;
using System.Collections;
using System.Collections.Generic;
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.AbandonCity, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.CancelBuild, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.CreateMoonStone, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.DemolishBuilding, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.DowngradeBuilding, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.GetBuildingInfo, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.GetBuildingUpgradeInfo, json);
      return result;
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.GetDistance, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.Poll, json);
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
    public string GetOrderTargetInfo(string cityId, string xcord, string ycord)
    {
      var json = new JsonRequest(new
                                   {
                                     session = SessionId,
                                     cityid = cityId,
                                     x = xcord,
                                     y = ycord
                                   });

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.GetOrderTargetInfo, json);
      return result;
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.GetPlayerInfo, json);
      return JsonConvert.DeserializeObject<GetPlayerResponse>(result);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.ReportGetCount, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.GetReport, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.ReportGetHeader, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.GetServerInfo, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.GetUnitProductionInfo, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.RenameCity, json);
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
      _listOfPollIds.Add(MessageExchangeAdapter.QueueServerCommand(ServerCommand.Poll, json));
     
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
      return MessageExchangeAdapter.RawRequest(rawInput, url);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.TradeDirect, json);
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

      var result = MessageExchangeAdapter.ExecuteServerCommand(ServerCommand.UpgradeBuilding, json);
      return result;
    }
  }
}
