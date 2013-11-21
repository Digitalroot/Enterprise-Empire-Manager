namespace EEM.Common.Protocol
{
  public class SysResponse : PollResponse<string>
  {
    public string Command
    {
      get { return D; } 
    }
  }
}