using System;

namespace EEM.Common.Adapters
{
  public class TimeService
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

    public void Update(Protocol.TimeResponse timeResponse)
    {
      RefrencePoint = timeResponse.D.Ref;
      Step = timeResponse.D.Step;
      LocalToServerOffset = timeResponse.D.Diff;
      ServerTimeZoneOffset = timeResponse.D.o;
    }
  }
}
