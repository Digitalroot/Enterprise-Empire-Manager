using System;
using System.Collections;
using System.Windows.Forms;
using Core.Common.Contracts;
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
    void MessageExchangeClientOnServerRequest(string url, IJsonRequest json)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("MessageExchangeClient.OnServerRequest: {0}, URL: {1}", json, url));
      ServerRequestMade(url, json);
    }

    /// <summary>
    /// OnServerResponse Event Handler
    /// </summary>
    /// <param name="result"></param>
    void MessageExchangeClientOnServerResponse(string result)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("MessageExchangeClient.OnServerResponse: {0}", result));
      ServerResponded(result);
    }

    /// <summary>
    /// OnServerResponseToQueuedCommand Event Handler
    /// </summary>
    /// <param name="id"></param>
    /// <param name="result"></param>
    void MessageExchangeClientOnServerResponseToQueuedCommand(int id, string result)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("MessageExchangeClient.OnServerResponseToQueuedCommand, Id: {0}, Result: {1}", id, result));

      if (((PollingService)PollingService).ListOfPollIds.Contains(id))
      {
        ((PollingService)PollingService).ListOfPollIds.Remove(id);
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
      if (((PollingService)PollingService).ListOfPollIds.Count >= 2) return; // Only add a request if we are not already waiting.

      if (CurrentCity == null && Cities.Count > 0)
      {
        CurrentCity = Cities[0];
      }

      if (CurrentCity == null)
      {
        return;
      }
      
      RequestCount++;

      IJsonRequest json;
      if (RequestCount == 1)
      {
        json = PollingService.GetFirstPollRequest(CurrentCity, SessionId);
      }
      else
      {
        json = PollingService.GetPollRequest(CurrentCity, SessionId, RequestCount);        
      }

      var id = MessageExchangeClient.QueueServerCommand(ServerCommand.Poll, json);
      ((PollingService)PollingService).ListOfPollIds.Add(id);
    }

    /// <summary>
    /// Handles System Commands.
    /// </summary>
    /// <param name="response"></param>
    private void LoUAdapter_OnSystemResponse(SysResponse response)
    {
      switch (response.Command)
      {
        case "CLOSED":
          Disconnect();
          break;

        case "KICKED":
          Disconnect();
          MessageBox.Show("You have been kicked from the server.", "Kicked", MessageBoxButtons.OK,
                          MessageBoxIcon.Exclamation);
          break;
      }
    }
  }
}
