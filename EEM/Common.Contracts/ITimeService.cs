using System;

namespace EEM.Common.Contracts
{
  public interface ITimeService
  {
    Int64 RefrencePoint { get; }
    int Step { get; }
    int LocalToServerOffset { get; }
    int ServerTimeZoneOffset { get; }
    Int64 CurrentTime { get; }
    void Update(IPollResponse timeResponse);
  }
}