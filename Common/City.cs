namespace EEM.Common
{
  public class City
  {
    // ReSharper disable InconsistentNaming
    public int X { get; private set; }
    public int Y { get; private set; }
    
    public int Id { get; private set; }

    public string Location
    {
      get
      {
        return X + ":" + Y;
      }
    }

    public string Name { get; private set; }

    public string Reference { get; private set; }

    public City(Protocol.CityResponse cityResponse)
    {
      Id = cityResponse.Id;
      X = cityResponse.x;
      Y = cityResponse.y;
      Name = cityResponse.Name;
      Reference = cityResponse.Reference;
    }
  }
}