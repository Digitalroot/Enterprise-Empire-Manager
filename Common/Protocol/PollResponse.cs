namespace EEM.Common.Protocol
{
  public class PollResponse<T> : JsonResponce, IPollResponse
  {
    public string C { get; set; }
    public T D { get; set; }
  }
}