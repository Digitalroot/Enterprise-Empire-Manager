namespace EEM.Common.Protocol
{
  public class CityResponseToBeFixed : JsonResponce
  {
    // {"i":17105326,"n":"* Penny 24007","p":9884,"s":0,"w":1,"x":430,"y":261}
    // ReSharper disable InconsistentNaming
    public int i { get; set; }
    public string n { get; set; } 
    public string r { get; set; }
    public int x { get; set; }
    public int y { get; set; }
    public int w { get; set; } // Water - 1 = true
    public int h { get; set; }
    public int p { get; set; } // unknown, Palace?
    public int s { get; set; } // Castle - 1 = true
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

    public bool HasCastle { get { return s == 1; } }
    public bool HasWaterAccess { get { return w == 1; } }

    public string Reference
    {
      get
      {
        return r;
      }
    }
  }
}
