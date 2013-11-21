namespace EEM.Common.Contracts
{
  public interface ICityResponseToBeFixed
  {
    int i { get; set; }
    string n { get; set; }
    string r { get; set; }
    int x { get; set; }
    int y { get; set; }
    int w { get; set; }
    int h { get; set; }
    int p { get; set; }
    int s { get; set; }
    int Id { get; }
    string Location { get; }
    string Name { get; }
    bool HasCastle { get; }
    bool HasWaterAccess { get; }
    string Reference { get; }
  }
}