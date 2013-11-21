using System.Collections.Generic;

namespace EEM.Common.Contracts
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
    ICity CurrentCity { get; }

    /// <summary>
    /// List of a players Cities
    /// </summary>
    List<ICity> Cities { get; }

    /// <summary>
    /// Used for adding and removing items from Poll requests.
    /// </summary>
    IPollingService PollingService { get; }

    /// <summary>
    /// This is the reference timestamp sent by the server.
    /// </summary>
    ITimeService TimeService { get; }

    /// <summary>
    /// Sends a chat message to the server.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    void SendChat(string message);

    /// <summary>
    /// Gets a list of alliances on the server.
    /// </summary>
    List<IAllianceGetRangeResponse> GetListOfAlliances();

    /// <summary>
    /// Gets the total number of alliances.
    /// </summary>
    /// <returns></returns>
    int AllianceGetCountAndIndex();

    List<IGetPublicAllianceMemberListResponse> GetPublicAllianceMemberList(int allianceId);

    /// <summary>
    /// Gets info about a city. 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    IGetPublicCityInfoResponse GetPublicCityInfo(int cityId);

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
    IGetPublicPlayerInfoResponse GetPublicPlayerInfo(int playerId);

    /// <summary>
    /// Gets info about a city. 
    /// </summary>
    /// <param name="cityId"></param>
    /// <returns></returns>
    int QueueGetPublicCityInfo(int cityId);

    IPollResponse GetCityDetails(int cityId);
  }
}