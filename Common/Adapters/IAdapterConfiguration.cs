namespace EEM.Common.Adapters
{
  public interface IAdapterConfiguration
  {
    /// <summary>
    /// This is the URL that is queried to log into LoU.
    /// </summary>
    string AuthenticationUrl { get; }

    /// <summary>
    /// This is the URL of the LoU Home Page.
    /// </summary>
    string HomePageUrl { get; }

    /// <summary>
    /// This is the URL of the logout script.
    /// </summary>
    string LogoutUrl { get; }

    /// <summary>
    /// This is the URL that is queried after 
    /// logging into LoU to get the session Id. 
    /// </summary>
    string SessionUrl { get; }

    /// <summary>
    /// This is the URL of the game server itself. 
    /// After logging into the game and getting a 
    /// valid session Id. This is used to interact
    /// with the LoU Game.
    /// </summary>
    string GameServerUrl { get; set; }
  }
}