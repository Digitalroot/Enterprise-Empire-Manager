namespace EEM.Common.Protocol
{
  public class ChatResponseD
  {
    // ReSharper disable InconsistentNaming
    public string c { get; set; }
    public string s { get; set; }
    public string m { get; set; }
    // ReSharper restore InconsistentNaming

    public string Target { get { return c; } }
    public string Who { get { return s.Substring(1); } }
    public string Message { get { return m; } }
  }
}
