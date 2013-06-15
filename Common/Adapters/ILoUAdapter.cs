using System.Collections.Generic;
using EEM.Common.Protocol;

namespace EEM.Common.Adapters
{
  public interface ILoUAdapter
  {
    /// <summary>
    /// Current Connection State.
    /// </summary>
    ConnectionState ConnectionState { get; }

    /// <summary>
    /// Current City
    /// </summary>
    City CurrentCity { get; }

    /// <summary>
    /// List of a players Cities
    /// </summary>
    List<City> Cities { get; }

    /// <summary>
    /// Used for adding and removing items from Poll requests.
    /// </summary>
    PollingService PollingService { get; }

    /// <summary>
    /// This is the reference timestamp sent by the server.
    /// </summary>
    TimeService TimeService { get; }

    /// <summary>
    /// Sends a chat message to the server.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    void SendChat(string message);

    #region Events

    /// <summary>
    /// Raises when the server responds with a ALL_AT block on a Poll request.
    /// </summary>
    event LoUAdapter.ALLATResponseHandler OnALLATResponse;

    /// <summary>
    /// Raises when the server responds with a Chat block on a Poll request.
    /// </summary>
    event LoUAdapter.ChatResponseHandler OnChatResponse;

    /// <summary>
    /// Raises when the server responds with a Sys block on a Poll request.
    /// </summary>
    event LoUAdapter.SystemResponseHandler OnSystemResponse;

    /// <summary>
    /// Raises when the server responds with a Version block on a Poll request.
    /// </summary>
    event LoUAdapter.VersionResponseHandler OnVersionResponse;

    /// <summary>
    /// Raises when the LoUAdapter fails to log into the LoU Server.
    /// </summary>
    event LoUAdapter.AuthenticationFailedHandler OnAuthenticationFailed;

    /// <summary>
    /// Raises when the LoUAdapter Connects or Disconnects from the server.
    /// </summary>
    event LoUAdapter.ConnectionStateChangeHandler OnConnectionStateChange;

    /// <summary>
    /// Raises when the server responds to a queued command.
    /// </summary>
    event LoUAdapter.ServerResponseToQueuedCommandHandler OnServerResponseToQueuedCommand;

    /// <summary>
    /// Raises when the server responds.
    /// </summary>
    event LoUAdapter.ServerResponseHandler OnServerResponse;

    /// <summary>
    /// Raises when the server responds with an Alliance block on a Poll request.
    /// </summary>
    event LoUAdapter.AllianceResponseHandler OnAllianceResponse;

    /// <summary>
    /// Raises when the server responds with a City block on a Poll request.
    /// </summary>
    event LoUAdapter.CityResponseHandler OnCityResponse;

    /// <summary>
    /// Raises when the server responds with a Player block on a Poll request.
    /// </summary>
    event LoUAdapter.PlayerResponseHandler OnPlayerResponse;

    /// <summary>
    /// Raises when the server responds with a Report block on a Poll request.
    /// </summary>
    event LoUAdapter.ReportResponseHandler OnReportResponse;

    /// <summary>
    /// Raises when the current selected city changes.
    /// </summary>
    event LoUAdapter.CurrentCityChangeHandler OnCurrentCityChange;
    #endregion

    /// <summary>
    /// Gets a list of alliances on the server.
    /// </summary>
    List<AllianceGetRangeResponse> GetListOfAlliances();

    /// <summary>
    /// Gets the total number of alliances.
    /// </summary>
    /// <returns></returns>
    int AllianceGetCountAndIndex();

    List<GetPublicAllianceMemberListResponse> GetPublicAllianceMemberList(int allianceId);

    /// <summary>
    /// Gets info about a city. 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    GetPublicCityInfoResponse GetPublicCityInfo(int cityId);

    /// <summary>
    /// Send an In Game Mail
    /// </summary>
    /// <param name="to">Who to send the mail to.</param>
    /// <param name="subjectLine">Subject</param>
    /// <param name="bodytext">Body</param>
    /// <returns>True|False</returns>
    bool SendMail(string to, string subjectLine, string bodytext);

    /// <summary>
    /// Send an In Game Mail to more then one person.
    /// </summary>
    /// <param name="toList">Who to send the mail to.</param>
    /// <param name="subjectLine">Subject</param>
    /// <param name="bodytext">Body</param>
    /// <returns>An Array of results. Index matches the toList index. If the value = 0 then the mail worked without error.</returns>
    List<string> SendBulkMail(List<string> toList, string subjectLine, string bodytext);

    /// <summary>
    /// Gets info about a player. 
    /// </summary>
    /// <param name="playerId"></param>
    /// <returns></returns>
    GetPublicPlayerInfoResponse GetPublicPlayerInfo(int playerId);

    /// <summary>
    /// Gets info about a city. 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    int QueueGetPublicCityInfo(int cityId);

    event LoUAdapter.ServerRequestHandler OnServerRequest;
    CityResponse GetCityDetails(int cityId);
  }
}