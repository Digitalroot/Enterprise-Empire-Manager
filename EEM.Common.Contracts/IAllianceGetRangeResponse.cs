namespace EEM.Common.Contracts
{
  public interface IAllianceGetRangeResponse
  {
    int i { get; set; }
    string n { get; set; }
    int r { get; set; }
    int p { get; set; }
    int m { get; set; }
    int a { get; set; }
    int c { get; set; }
    int Id { get; }
    string Name { get; }
    int Rank { get; }
    int Points { get; }
    int Members { get; }
    int Avg { get; }
    int Cities { get; }
  }
}