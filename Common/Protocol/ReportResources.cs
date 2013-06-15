namespace EEM.Common.Protocol
{
  public class ReportResources
  {
    public int t { get; set; }
    public int v { get; set; }
    
    public ResourceType Resource 
    {
      get { return ConversionUtil.ConvertResource(t); }
    }
    public int Value
    { 
      get { return v; } 
    }
  }
}