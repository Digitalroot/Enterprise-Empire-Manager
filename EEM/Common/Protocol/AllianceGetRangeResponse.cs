using EEM.Common.Contracts;

namespace EEM.Common.Protocol
{
  public class AllianceGetRangeResponse : IAllianceGetRangeResponse
  {
    public int i { get; set; }
    public string n { get; set; }
    public int r { get; set; }
    public int p { get; set; }
    public int m { get; set; }
    public int a { get; set; }
    public int c { get; set; }

    public int Id
    {
      get { return i; }
    }

    public string Name
    {
      get { return n; }
    }

    public int Rank
    {
      get { return r; }
    }

    public int Points
    {
      get { return p; }
    }

    public int Members
    {
      get { return m; }
    }

    public int Avg
    {
      get { return a; }
    }

    public int Cities
    {
      get { return c; }
    }
  }
}
