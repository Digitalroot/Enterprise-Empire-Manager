using System.Net;
using EEM.Common.Adapters;

namespace EEM.Common.Protocol
{
  public interface ILoUProtocol
  {
    WebHeaderCollection ResponseHeaders { get; }
    WebHeaderCollection RequestHeaders { get; }
    string HtmlResult { get; }
    AdapterConfiguration Configuration { get; set; }
    bool Authenticate(NetworkCredential credential);

    /// <summary>
    /// Get Player Info from LoU. 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    string GetPlayerInfo(JsonRequest json);

    /// <summary>
    /// Get Report from LoU. 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    string GetReport(JsonRequest json);

    /// <summary>
    /// Get Server Info from LoU. 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    string GetServerInfo(JsonRequest json);

    /// <summary>
    /// Standard query used to Poll the server. 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    string Poll(JsonRequest json);

    /// <summary>
    /// Get Report Header Info from LoU. 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    string ReportGetHeader(JsonRequest json);

  }
}