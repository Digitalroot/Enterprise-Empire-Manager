namespace EEM.Common.Protocol
{
  public class NewReportsResponce : Protocol.JsonResponce
  {
    public int u { get; set; } // Number of new reports.
    public int v { get; set; } // Unknown
    public int NumberOfNewReports
    {
      get
      {
        return u;
      }
      private set { }
    }
  }
}
