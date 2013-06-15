namespace EEM.Common.Protocol
{
  public class GetOrderTargetInfoResponse : PollResponse<string>
  {
    // {"a":871,"an":"Guardians","c":13894092,"cn":"Milky Way","d":5.09901953,"dw":-1,"et":0,"p":10778,"pn":"KandyShop",
    // "pp":0,"pte":0,"ptps":0,"pts":0,"s":false,"t":0}

    // ReSharper disable InconsistentNaming
    public int a { get; set; } // Alliance
    public string an { get; set; } // Alliance Name
    public int c { get; set; } // City Id
    public string cn { get; set; } // City Name
    public double d { get; set; }
    public int dw { get; set; }
    public int et { get; set; }
    public int p { get; set; } // Player Id ?
    public string pn { get; set; } // Player Name
    public int pp { get; set; }
    public int pte { get; set; }
    public int ptps { get; set; }
    public int pts { get; set; }
    public bool s { get; set; }
    public int t { get; set; }
    // ReSharper restore InconsistentNaming

    public int AllianceId { get { return a; } }
    public string AllianceName { get { return an; } }
    public int CityId { get { return c; } }
    public string CityName { get { return cn; } }
    public int PlayerId { get { return p; } }
    public string PlayerName { get { return pn; } }
  }
}