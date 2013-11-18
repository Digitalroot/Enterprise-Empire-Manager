using System;
using EEM.Common.Contracts;

namespace EEM.Common.Adapters
{
  public class TimeService : ITimeService
  {
    public Int64 RefrencePoint { get; private set; }
    public int Step { get; private set; }
    public int LocalToServerOffset { get; private set; }
    public int ServerTimeZoneOffset { get; private set; }

    public Int64 CurrentTime
    {
      get
      {
        return Convert.ToInt64(ConversionUtil.ConvertToUnixTimestamp(DateTime.UtcNow) * 1000);
      }
    }

    public void Update(IPollResponse timeResponsesource)
    {
      var timeResponse = (Protocol.TimeResponse) timeResponsesource;
      RefrencePoint = timeResponse.D.Ref;
      Step = timeResponse.D.Step;
      LocalToServerOffset = timeResponse.D.Diff;
      ServerTimeZoneOffset = timeResponse.D.o;
    }
  }
}
