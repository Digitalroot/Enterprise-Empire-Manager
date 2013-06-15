namespace EEM.Common
{
  public class TradeResource
  {
    public int t { get; private set; }
    public int c { get; private set; }

    public TradeResource(ResourceType resourceType, int ammount)
    {
      t = ConversionUtil.ConvertResource(resourceType);
      c = ammount;
    }
  }
}