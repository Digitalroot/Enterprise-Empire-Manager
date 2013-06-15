using System.Collections.Generic;

namespace EEM.Common.Adapters
{
  public interface ILoUAdapter
  {
    /// <summary>
    /// Current Connection State.
    /// </summary>
    ConnectionState ConnectionState { get; }

    City CurrentCity { get; }

    /// <summary>
    /// List of a players Cities
    /// </summary>
    List<City> Cities { get; }

    event LoUAdapter.ChatResponseHandler OnChatResponse;
    event LoUAdapter.SystemResponseHandler OnSystemResponse;
    event LoUAdapter.VersionResponseHandler OnVersionResponse;
    event LoUAdapter.AuthenticationFailedHandler OnAuthenticationFailed;
    event LoUAdapter.ConnectionStateChangeHandler OnConnectionStateChange;
    event LoUAdapter.ServerResponseToQueuedCommandHandler OnServerResponseToQueuedCommand;
    event LoUAdapter.ServerResponseHandler OnServerResponse;
    event LoUAdapter.AllianceResponseHandler OnAllianceResponse;
    event LoUAdapter.CityResponseHandler OnCityResponse;
    event LoUAdapter.PlayerResponseHandler OnPlayerResponse;
    event LoUAdapter.ReportResponseHandler OnReportResponse;

    /// <summary>
    /// Sends a chat message to the server.
    /// </summary>
    /// <param name="message"></param>
    /// <returns></returns>
    void SendChat(string message);

    /// <summary>
    /// Adds a new value to the poll request items.
    /// If the item already exists then update is called
    /// </summary>
    /// <param name="pollRequestItems"></param>
    /// <param name="value"></param>
    void AddPollRequestItems(PollRequestItems[] pollRequestItems, string value);

    /// <summary>
    /// Removes a poll request item.
    /// </summary>
    /// <param name="pollRequestItem"></param>
    void RemovePollRequestItem(PollRequestItems pollRequestItem);

    /// <summary>
    /// Updates a value on the poll request items.
    /// if the item does not exist then it is added.
    /// </summary>
    /// <param name="pollRequestItem"></param>
    /// <param name="value"></param>
    void UpdatePollRequestItem(PollRequestItems pollRequestItem, string value);

  }
}