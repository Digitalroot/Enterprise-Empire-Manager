using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using Core.Common.Contracts;
using EEM.Common.Contracts;

namespace EEM.Common.Adapters
{
  public class PollingService : IPollingService
  {
    public ConnectionState ConnectionState { get; set; }

    /// <summary>
    /// Poll timer
    /// </summary>
    internal readonly Timer Polltimer = new Timer { Interval = 10000 };

    /// <summary>
    /// Items included in the poll request.
    /// </summary>
    internal readonly Hashtable PollRequestItems = new Hashtable();

    /// <summary>
    /// List of Poll request Id's
    /// </summary>
    internal readonly List<int> ListOfPollIds = new List<int>();

    internal ITimeService TimeService { get; private set; }

    public PollingService(ITimeService timeService)
    {
      Polltimer.Tick += PolltimerTick;
      OnPollItemAdd += PollingService_OnPollItemAdd;
      OnPollItemRemoval += PollingService_OnPollItemRemoval;
      OnPollItemValueUpdate += PollingService_OnPollItemValueUpdate;
      TimeService = timeService;
    }

    private static void PollingService_OnPollItemValueUpdate(PollRequestItems pollRequestItem, string value)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("PollingService - Poll Item Updated: {0}, Value: {1}", pollRequestItem, value));
    }

    private static void PollingService_OnPollItemRemoval(PollRequestItems pollRequestItem)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("PollingService - Poll Item Removed: {0}", pollRequestItem));
    }

    private static void PollingService_OnPollItemAdd(PollRequestItems pollRequestItem, string value)
    {
      System.Diagnostics.Debug.WriteLine(String.Format("PollingService - Poll Item Added: {0}, Value: {1}", pollRequestItem, value));
    }

    #region Events
    public delegate void PollItemAddedHandler(PollRequestItems pollRequestItem, string value);
    public event PollItemAddedHandler OnPollItemAdd;
    private void PollItemsAdded(PollRequestItems pollRequestItem, string value)
    {
      if (OnPollItemAdd != null)
      {
        Delegate[] subscribers = OnPollItemAdd.GetInvocationList();
        foreach (PollItemAddedHandler subscriber in subscribers)
        {
          try
          {
            subscriber(pollRequestItem, value);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void PollItemRemovedHandler(PollRequestItems pollRequestItem);
    public event PollItemRemovedHandler OnPollItemRemoval;
    private void PollItemRemoved(PollRequestItems pollRequestItem)
    {
      if (OnPollItemRemoval != null)
      {
        Delegate[] subscribers = OnPollItemRemoval.GetInvocationList();
        foreach (PollItemRemovedHandler subscriber in subscribers)
        {
          try
          {
            subscriber(pollRequestItem);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void PollItemValueUpdateHandler(PollRequestItems pollRequestItem, string value);
    public event PollItemValueUpdateHandler OnPollItemValueUpdate;
    private void PollItemValueUpdated(PollRequestItems pollRequestItem, string value)
    {
      if (OnPollItemValueUpdate != null)
      {
        Delegate[] subscribers = OnPollItemValueUpdate.GetInvocationList();
        foreach (PollItemValueUpdateHandler subscriber in subscribers)
        {
          try
          {
            subscriber(pollRequestItem, value);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }
    #endregion

    /// <summary>
    /// Adds a new value to the poll request items.
    /// If the item already exists then update is called
    /// ToDo: Fix this as sending the value as a string is broken. Should be an array.
    /// </summary>
    /// <param name="pollRequestItems"></param>
    /// <param name="value"></param>
    public void AddPollRequestItems(PollRequestItems[] pollRequestItems, string value)
    {
      foreach (PollRequestItems pollRequestItem in pollRequestItems)
      {
        if (PollRequestItems.ContainsKey(pollRequestItem.ToString()))
        {
          UpdatePollRequestItem(pollRequestItem, value);
        }
        else
        {
          PollRequestItems.Add(pollRequestItem.ToString(), value);
          PollItemsAdded(pollRequestItem, value);
        }
      }

      if (!Polltimer.Enabled && PollRequestItems.Count > 0)
      {
        StartPollTimer();
      }
    }

    /// <summary>
    /// Handles Errors from Delegates.
    /// </summary>
    /// <param name="method"></param>
    /// <param name="exception"></param>
    private static void HandleDelegateError(MethodInfo method, Exception exception)
    {
      Debug.WriteLine("Error: {0}", method);
//      MessageBox.Show(exception.Message, String.Format("Error: {0}", method));
    }

    void PolltimerTick(object sender, EventArgs e)
    {
      if (ConnectionState != ConnectionState.Connected || PollRequestItems.Count == 0)
      {
        StopPollTimer();
        return;
      }
    }

    /// <summary>
    /// Removes a poll request item.
    /// </summary>
    /// <param name="pollRequestItem"></param>
    public void RemovePollRequestItem(PollRequestItems pollRequestItem)
    {
      if (PollRequestItems.ContainsKey(pollRequestItem.ToString()))
      {
        PollRequestItems.Remove(pollRequestItem.ToString());
        PollItemRemoved(pollRequestItem);
      }
      if (Polltimer.Enabled && PollRequestItems.Count == 0)
      {
        StopPollTimer();
      }
    }

    /// <summary>
    /// Starts the Poll timer.
    /// </summary>
    internal void StartPollTimer()
    {
      if (ConnectionState == ConnectionState.Connected && PollRequestItems.Count > 0 && !Polltimer.Enabled)
      {
        Polltimer.Start();
        System.Diagnostics.Debug.WriteLine("PollingService: Poll timer started.");
      }

    }

    /// <summary>
    /// Stops the Poll timer
    /// </summary>
    internal void StopPollTimer()
    {
      if (Polltimer.Enabled)
      {
        Polltimer.Stop();
        System.Diagnostics.Debug.WriteLine("PollingService: Poll timer was stopped.");
      }
    }

    /// <summary>
    /// Updates a value on the poll request items.
    /// if the item does not exist then it is added.
    /// </summary>
    /// <param name="pollRequestItem"></param>
    /// <param name="value"></param>
    public void UpdatePollRequestItem(PollRequestItems pollRequestItem, string value)
    {
      if (PollRequestItems.ContainsKey(pollRequestItem.ToString()))
      {
        PollRequestItems[pollRequestItem.ToString()] = value;
        PollItemValueUpdated(pollRequestItem, value);
      }
      else
      {
        PollRequestItems[] item = { pollRequestItem };
        AddPollRequestItems(item, value);
      }
    }

    public IJsonRequest GetFirstPollRequest(ICity city, string sessionId)
    {
      // {"session":"0000000-6ac8-4623-b814-2efcb086a86d","requestid":"3837","requests":"CAT:1\fSERVER:\fALLIANCE:\fQUEST:\fPLAYER:\fCITY:15204670\fVIS:c:15204670:0:-874:-411:1196:1018\fREPORT:\fMAIL:\fFRIENDINV:\fALL_AT:\fCHAT:\fTIME:1285834121258\fSUBSTITUTION:\fINV:\fRESO:\f"}
      var requestitems = new Hashtable();
      requestitems.Add("CAT", "0");
      requestitems.Add("SERVER", String.Empty);
      requestitems.Add("ALLIANCE", String.Empty);
      requestitems.Add("QUEST", String.Empty);
      requestitems.Add("PLAYER", String.Empty);
      requestitems.Add("CITY", city.Id);
      requestitems.Add("VIS", String.Format((string) "c:{0}:0:-874:-412:1196:1016", (object) city.Id));
      requestitems.Add("REPORT", String.Empty);
      requestitems.Add("MAIL", String.Empty);
      requestitems.Add("FRIENDINV", String.Empty);
      requestitems.Add("ALL_AT", String.Empty);
      requestitems.Add("TIME", TimeService.CurrentTime);
      requestitems.Add("SUBSTITUTION", String.Empty);
      requestitems.Add("INV", String.Empty);

      foreach (string item in PollRequestItems.Keys)
      {
        if (requestitems.ContainsKey(item))
        {
          if (PollRequestItems[item] != null && PollRequestItems[item].ToString() != String.Empty)
          {
            requestitems[item] = PollRequestItems[item];          
          }
        }
        else
        {
          requestitems.Add(item, PollRequestItems[item]);
        }
      }

      var json = Poll.Request(sessionId, 1, requestitems);

      return json;
    }

    public IJsonRequest GetPollRequest(ICity city, string sessionId, int requestCount)
    {
      var json = Poll.Request(sessionId, requestCount, PollRequestItems);
      return json;
    }
  }
}
