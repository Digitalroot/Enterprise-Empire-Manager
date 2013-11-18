using Core.Common.Contracts;

namespace EEM.Common.Contracts
{
  public interface IPollingService
  {
    ConnectionState ConnectionState { get; set; }

    /// <summary>
    /// Adds a new value to the poll request items.
    /// If the item already exists then update is called
    /// ToDo: Fix this as sending the value as a string is broken. Should be an array.
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

    IJsonRequest GetFirstPollRequest(ICity city, string sessionId);
    IJsonRequest GetPollRequest(ICity city, string sessionId, int requestCount);
  }
}