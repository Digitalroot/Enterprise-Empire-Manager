namespace EEM.Common.Protocol
{
  public class OpenSessionResponse : JsonResponce
  {
    public string i { get; set; }
    public bool r { get; set; }

    public string SessionId 
    {
      get { return i; }
    }
  }
}