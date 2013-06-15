using System;

namespace EEM.Common.Protocol
{
  public class ReportResponse : JsonResponce
  {
    #region Json Members
    // ReSharper disable InconsistentNaming
    public long d { get; set; } // TimeStamp
    public int i { get; set; } // Id
    public string l { get; set; } // Message
    public string p { get; set; } // Player Name
    public int r { get; set; } // Read = 1, Unread = 0
    public string t { get; set; } // Report Type
    // ReSharper restore InconsistentNaming
    #endregion

    public DateTime DateTime
    {
      get
      {
        var tmpDataTime = d.ToString();
        return ConversionUtil.ConvertDateTime2AnotherTimezone(ConversionUtil.ConvertJsonDate(Convert.ToInt64(tmpDataTime.Substring(0, tmpDataTime.Length - 3))), -5, -8); // ToDo: TimeZone
      }
    }

    public int Id
    {
      get { return i; }
    }

    public string Message
    {
      get { return l; }

    }

    public string Player
    {
      get { return p; }
    }

    public bool Unread
    {
      get { return r == 0; }
    }

    public ReportDetails Details { get; set; }
  }
}
