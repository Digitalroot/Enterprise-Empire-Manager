namespace EEM.Common
{
  public class TradeResource
  {
    public int t { get; private set; }
    public int c { get; private set; }

    public TradeResource(Resources resources, int ammount)
    {
      t = ConversionUtil.ConvertResource(resources);
      c = ammount;
    }
  }
}