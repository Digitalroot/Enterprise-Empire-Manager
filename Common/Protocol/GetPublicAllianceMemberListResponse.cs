namespace EEM.Common.Protocol
{
  public class GetPublicAllianceMemberListResponse
  {
    public int c { get; set; }
    public int i { get; set; }
    public string n { get; set; }
    public int p { get; set; }
    public int r { get; set; }
    
    public int Cities
    {
      get { return c; }
    }

    public int Id
    {
      get { return i; }
    }

    public string Name
    {
      get { return n; }
    }

    public int Points
    {
      get { return p; }
    }

    public int Rank
    {
      get { return r; }
    }
  }
}
