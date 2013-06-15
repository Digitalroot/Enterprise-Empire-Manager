using System;
using System.Collections;
using EEM.Common.Protocol;
using Newtonsoft.Json;

namespace EEM.Common.Adapters
{
  public partial class LoUAdapter
  {
    /// <summary>
    /// Handles Player Response
    /// </summary>
    /// <param name="response"></param>
    void LoUAdapter_OnPlayerResponse(PlayerResponse response)
    {
      SetCities(response.Cities);
    }

    /// <summary>
    /// OnServerRequest Event Handler
    /// </summary>
    /// <param name="url"></param>
    /// <param name="json"></param>
    static void MessageExchangeAdapter_OnServerRequest(string url, JsonRequest json)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("MessageExchangeClient.OnServerRequest: {0}, URL: {1}", json, url));
    }

    /// <summary>
    /// OnServerResponse Event Handler
    /// </summary>
    /// <param name="result"></param>
    void MessageExchangeAdapter_OnServerResponse(string result)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("MessageExchangeClient.OnServerResponse: {0}", result));
      ServerResponded(result);
    }

    /// <summary>
    /// OnServerResponseToQueuedCommand Event Handler
    /// </summary>
    /// <param name="id"></param>
    /// <param name="result"></param>
    void MessageExchangeAdapter_OnServerResponseToQueuedCommand(int id, string result)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("MessageExchangeClient.OnServerResponseToQueuedCommand, Id: {0}, Result: {1}", id, result));

      if (_listOfPollIds.Contains(id))
      {
        _listOfPollIds.Remove(id);
        ArrayList jsonArray = null;
        try
        {
          if (result.StartsWith("[") && result.EndsWith("]"))
          {
            jsonArray = JsonConvert.DeserializeObject<ArrayList>(result);
          }
        }
        catch (Exception)
        {
          System.Diagnostics.Debug.WriteLine("*** Not a JsonResponse. Skipping ***");
        }

        if (jsonArray != null)
        {
          foreach (var response in jsonArray)
          {
            HandlePollResponse(response);
          }
        }
      }
      else
      {
        ServerRespondedToQueuedCommand(id, result);
      }
    }

    /// <summary>
    /// Queues a command if there are items to send.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    // ReSharper disable InconsistentNaming
    void polltimer_Tick(object sender, EventArgs e)
    // ReSharper restore InconsistentNaming
    {
      if (ConnectionState != ConnectionState.Connected || _pollRequestItems.Count == 0)
      {
        StopPollTimer();
        return;
      }

      JsonRequest json;
      if (RequestCount == 0)
      {
        // {"session":"0000000-6ac8-4623-b814-2efcb086a86d","requestid":"3837","requests":"CAT:1\fSERVER:\fALLIANCE:\fQUEST:\fPLAYER:\fCITY:15204670\fVIS:c:15204670:0:-874:-411:1196:1018\fREPORT:\fMAIL:\fFRIENDINV:\fALL_AT:\fCHAT:\fTIME:1285834121258\fSUBSTITUTION:\fINV:\fRESO:\f"}
        var requestitems = new Hashtable();
        requestitems.Add("CAT", "0");
        requestitems.Add("SERVER", String.Empty);
        requestitems.Add("ALLIANCE", String.Empty);
        requestitems.Add("QUEST", String.Empty);
        requestitems.Add("PLAYER", "0");
        requestitems.Add("CITY", CurrentCity.Id);
        requestitems.Add("VIS", String.Format("c:{0}:0:-874:-412:1196:1016", CurrentCity.Id));
        requestitems.Add("REPORT", String.Empty);
        requestitems.Add("MAIL", String.Empty);
        requestitems.Add("FRIENDINV", String.Empty);
        requestitems.Add("ALL_AT", String.Empty);
        requestitems.Add("TIME", "1285834121258");
        requestitems.Add("SUBSTITUTION", String.Empty);
        requestitems.Add("INV", String.Empty);
        
        foreach (string item in _pollRequestItems.Keys)
        {
          if (requestitems.ContainsKey(item))
          {
            requestitems[item] = _pollRequestItems[item];
          }
          else
          {
            requestitems.Add(item, _pollRequestItems[item]);
          }
        }

        json = Poll.Request(
                            SessionId,
                            ++RequestCount,
                            requestitems
                           );
      }
      else
      {
        json = Poll.Request(
                            SessionId,
                            ++RequestCount,
                            _pollRequestItems
                           );
      }
      
      var id = MessageExchangeAdapter.QueueServerCommand(ServerCommand.Poll, json);
      _listOfPollIds.Add(id);
    }
  }
}
