namespace EEM.Common.Contracts
{
  public interface IGetPublicAllianceMemberListResponse
  {
    int c { get; set; }
    int i { get; set; }
    string n { get; set; }
    int p { get; set; }
    int r { get; set; }
    int Cities { get; }
    int Id { get; }
    string Name { get; }
    int Points { get; }
    int Rank { get; }
  }
}