namespace EEM.Common.Protocol
{
  public class VersionResponse : PollResponse<string>
  {
    public string Version
    {
      get { return D; } 
    }
  }
}