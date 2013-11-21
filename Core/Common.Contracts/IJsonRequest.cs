namespace Core.Common.Contracts
{
  public interface IJsonRequest
  {
    object Value { get; set; }
    void SetValueBypassSerializeObject(string newvalue);
  }
}