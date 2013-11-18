using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class PlayerResponse : PollResponse<PlayerResponseD>
  {
    public List<CityResponseToBeFixed> Cities
    {
      get { return D.c; }
    }

    public int Rank
    {
      get { return D.r; }
    }

    public int Score
    {
      get { return D.p; }
    }

    public Titles Title
    {
      get { return ConversionUtil.ConvertTitle(D.t); }
    }

  }
}