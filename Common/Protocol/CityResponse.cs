namespace EEM.Common.Protocol
{
  public class CityResponse : JsonResponce
  {
    // ReSharper disable InconsistentNaming
    public int i;
    public string n;
    public string r;
    public int x;
    public int y;
    public int w;
    public int h;
    // ReSharper restore InconsistentNaming

    public int Id
    {
      get
      {
        return i;
      }
    }

    public string Location
    {
      get
      {
        return x + ":" + y;
      }
    }

    public string Name
    {
      get
      {
        return n;
      }
    }

    public string Reference
    {
      get
      {
        return r;
      }
    }
  }
}
