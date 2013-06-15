using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  // {"cdpt":3600,"ch":100,"cspt":3600,"cw":100,"dmwt":86400,"dmwtb":86400,
  // "ms":[{"c":50000,"t":0},{"c":50000,"t":4},{"c":50000,"t":3},{"c":50000,"t":2},{"c":50000,"t":1}],
  // "n":"World  5 (USA East Coast)",
  //"nc":[{"c":25000,"t":4},{"c":25000,"t":3},{"c":100000,"t":2},{"c":100000,"t":1}],
  // "rbdf":1,"s":0,"tlc":1000,"tsc":10000,"tsl":600,"tspt":3600,"tss":300}
  public class ServerInfoResponse
  {
    public int cdpt { get; set; }
    public int ch { get; set; }
    public int cw { get; set; }
    public int dmwt { get; set; }
    public int dmwtb { get; set; }
    public List<ServerInfoResponseMS> ms { get; set; }
    public string n { get; set; }
    public List<ServerInfoResponseNC> nc { get; set; }
    public int rbdf { get; set; }
    public int s { get; set; }
    public int tlc { get; set; }
    public int tsc { get; set; }
    public int tsl { get; set; }
    public int tspt { get; set; }
    public int tss { get; set; }

    public string ServerName
    {
      get { return n; }
    }
    
  }

  public class ServerInfoResponseMS 
  {
    public int c { get; set; }
    public int t { get; set; }
  }

  public class ServerInfoResponseNC
  {
    public int c { get; set; }
    public int t { get; set; }
  }
}
