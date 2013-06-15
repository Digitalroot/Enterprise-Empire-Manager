namespace EEM.Common.Adapters
{
  public class AdapterConfiguration : IAdapterConfiguration
  {
    /// <summary>
    /// This is the URL that is queried to log into LoU.
    /// </summary>
    public string AuthenticationUrl { get; private set; }

    private string _homePageUrl;

    /// <summary>
    /// This is the URL of the LoU Home Page.
    /// </summary>
    public string HomePageUrl
    {
      get { return _homePageUrl; }
      set
      {
        if (!value.EndsWith("/"))
        {
          value += "/";
        }
        AuthenticationUrl = value.Replace("http:", "https:") + "user/login?destination=%40homepage%3F";
        LogoutURL = value + "user/logout";
        SessionUrl = value + "game";
        _homePageUrl = value;
      }
    }

    /// <summary>
    /// This is the URL of the logout script.
    /// </summary>
    public string LogoutURL { get; private set; }

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
