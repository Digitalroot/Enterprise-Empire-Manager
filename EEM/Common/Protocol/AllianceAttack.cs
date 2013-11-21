namespace EEM.Common.Protocol
{
  public class AllianceAttack
  {
    public int i { get; set; } // Attack Id?
    public int t { get; set; } // Attack Type
    public int ss { get; set; }
    public int es { get; set; } // Seconds from a ref point until attack. 
    public int s { get; set; }
    public int c { get; set; } // City id
    public string cn { get; set; } // City Name
    public int p { get; set; } // Player id
    public string pn { get; set; } // Player name
    public int a { get; set; } // Alliance id
    public string an { get; set; } // Alliance name
    public int tc { get; set; } //  Target city id
    public string tcn { get; set; } // Target City Name
    public int tp { get; set; } // Target Player id
    public string tpn { get; set; } // Target Player Name

    public int AttackingCityId { get { return c; } }
    public string AttackingCityName { get { return cn; } }

    public int AttackingPlayerId { get { return p; } }
    public string AttackingPlayerName { get { return pn; } }

    public int AttackingAllianceId { get { return a; } }
    public string AttackingAllianceName { get { return an; } }

    public int TargetCityId { get { return tc; } }
    public string TargetCityName { get { return tcn; } }

    public int TargetPlayerId { get { return tp; } }
    public string TargetPlayerName { get { return tpn; } }

    public AttackType AttackType { get { return ConversionUtil.ConvertAttackType(t); } }

    public int SecondsFromRefUntilAttack { get { return es; } }
  }
}
