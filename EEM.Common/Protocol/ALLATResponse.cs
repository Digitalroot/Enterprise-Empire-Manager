using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class ALLATResponse : PollResponse<ALLATResponseD>
  {
    public int Version
    {
      get { return D.v; }
    }

    public List<AllianceAttack> AttackList
    {
      get { return D.a; }
    }  
  }
}