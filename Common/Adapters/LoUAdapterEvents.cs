using System;
using System.Collections;
using EEM.Common.Protocol;

namespace EEM.Common.Adapters
{
  public partial class LoUAdapter
  {

    public delegate void AllianceResponseHandler(AllianceResponse response);
    public event AllianceResponseHandler OnAllianceResponse;
    private void AllianceResponse(AllianceResponse response)
    {
      if (OnAllianceResponse != null)
      {
        Delegate[] subscribers = OnAllianceResponse.GetInvocationList();
        foreach (AllianceResponseHandler subscriber in subscribers)
        {
          try
          {
            subscriber(response);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void AuthenticationFailedHandler(ArrayList error);
    public event AuthenticationFailedHandler OnAuthenticationFailed;
    private void AuthenticationFailed(ArrayList errors)
    {
      if (OnAuthenticationFailed != null)
      {
        Delegate[] subscribers = OnAuthenticationFailed.GetInvocationList();
        foreach (AuthenticationFailedHandler subscriber in subscribers)
        {
          try
          {
            subscriber(errors);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void ChatResponseHandler(ChatResponse response);
    public event ChatResponseHandler OnChatResponse;
    private void ChatResponse(ChatResponse response)
    {
      if (OnChatResponse != null)
      {
        Delegate[] subscribers = OnChatResponse.GetInvocationList();
        foreach (ChatResponseHandler subscriber in subscribers)
        {
          try
          {
            subscriber(response);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void CityResponseHandler(CityResponse response);
    public event CityResponseHandler OnCityResponse;
    private void CityResponse(CityResponse response)
    {
      if (OnCityResponse != null)
      {
        Delegate[] subscribers = OnCityResponse.GetInvocationList();
        foreach (CityResponseHandler subscriber in subscribers)
        {
          try
          {
            subscriber(response);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void ConnectionStateChangeHandler(ConnectionState state);
    public event ConnectionStateChangeHandler OnConnectionStateChange;
    private void ConnectionStateChanged(ConnectionState state)
    {
      if (OnConnectionStateChange != null)
      {
        Delegate[] subscribers = OnConnectionStateChange.GetInvocationList();
        foreach (ConnectionStateChangeHandler subscriber in subscribers)
        {
          try
          {
            subscriber(state);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void PlayerResponseHandler(PlayerResponse response);
    public event PlayerResponseHandler OnPlayerResponse;
    private void PlayerResponse(PlayerResponse response)
    {
      if (OnPlayerResponse != null)
      {
        Delegate[] subscribers = OnPlayerResponse.GetInvocationList();
        foreach (PlayerResponseHandler subscriber in subscribers)
        {
          try
          {
            subscriber(response);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void ReportResponseHandler(ReportResponse response);
    public event ReportResponseHandler OnReportResponse;
    private void ReportResponse(ReportResponse response)
    {
      if (OnReportResponse != null)
      {
        Delegate[] subscribers = OnReportResponse.GetInvocationList();
        foreach (ReportResponseHandler subscriber in subscribers)
        {
          try
          {
            subscriber(response);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }
    
    public delegate void ServerResponseHandler(string message);
    public event ServerResponseHandler OnServerResponse;
    private void ServerResponded(string message)
    {
      if (OnServerResponse != null)
      {
        Delegate[] subscribers = OnServerResponse.GetInvocationList();
        foreach (ServerResponseHandler subscriber in subscribers)
        {
          try
          {
            subscriber(message);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void ServerResponseToQueuedCommandHandler(Int32 id, string message);
    public event ServerResponseToQueuedCommandHandler OnServerResponseToQueuedCommand;
    private void ServerRespondedToQueuedCommand(Int32 id, string result)
    {
      if (OnServerResponseToQueuedCommand != null)
      {
        Delegate[] subscribers = OnServerResponseToQueuedCommand.GetInvocationList();
        foreach (ServerResponseToQueuedCommandHandler subscriber in subscribers)
        {
          try
          {
            subscriber(id, result);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void SystemResponseHandler(SysResponse response);
    public event SystemResponseHandler OnSystemResponse;
    private void SystemResponse(SysResponse response)
    {
      if (OnSystemResponse != null)
      {
        Delegate[] subscribers = OnSystemResponse.GetInvocationList();
        foreach (SystemResponseHandler subscriber in subscribers)
        {
          try
          {
            subscriber(response);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }

    public delegate void VersionResponseHandler(VersionResponse response);
    public event VersionResponseHandler OnVersionResponse;
    private void VersionResponse(VersionResponse response)
    {
      if (OnVersionResponse != null)
      {
        Delegate[] subscribers = OnVersionResponse.GetInvocationList();
        foreach (VersionResponseHandler subscriber in subscribers)
        {
          try
          {
            subscriber(response);
          }
          catch (Exception e)
          {
            HandleDelegateError(subscriber.Method, e);
          }
        }
      }
    }
  }
}
