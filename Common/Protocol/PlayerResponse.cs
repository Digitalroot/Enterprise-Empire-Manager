using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class PlayerResponse : PollResponse<PlayerResponseD>
  {
    public List<CityResponse> Cities
    {
      get { return D.c; }
    }  
  }
}