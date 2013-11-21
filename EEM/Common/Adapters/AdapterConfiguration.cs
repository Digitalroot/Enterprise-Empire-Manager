using EEM.Common.Contracts;

namespace EEM.Common.Adapters
{
  public class AdapterConfiguration : IAdapterConfiguration
  {
    public AdapterConfiguration()
    {
      HomePageUrl = "https://www.lordofultima.com/home";
      AuthenticationUrl = "https://www.lordofultima.com/j_security_check";
      SessionUrl = "http://www.lordofultima.com/game/launch/redirect";
      LogoutUrl = "https://www.lordofultima.com/en/user/logout";
    }

    /// <summary>
    /// This is the URL that is queried to log into LoU.
    /// </summary>
    public string AuthenticationUrl { get; private set; }

    /// <summary>
    /// This is the URL of the LoU Home Page.
    /// </summary>
    public string HomePageUrl { get; private set; }

    /// <summary>
    /// This is the URL of the logout script.
    /// </summary>
    public string LogoutUrl { get; private set; }

    /// <summary>
    /// This is the URL that is queried after 
    /// logging into LoU to get the session Id. 
    /// </summary>
    public string SessionUrl { get; private set; }

    /// <summary>
    /// This is the URL of the game server itself. 
    /// After logging into the game and getting a 
    /// valid session Id. This is used to interact
    /// with the LoU Game.
    /// </summary>
    public string GameServerUrl { get; set; }
  }
}
