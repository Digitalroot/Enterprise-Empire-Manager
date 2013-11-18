using System.Net;
using Core.Common.Contracts;

namespace EEM.Common.Contracts
{
  public interface ILoUProtocol
  {
    WebHeaderCollection ResponseHeaders { get; }
    WebHeaderCollection RequestHeaders { get; }
    string HtmlResult { get; }
    IAdapterConfiguration Configuration { get; set; }
    bool Authenticate(NetworkCredential credential);

    /// <summary>
    /// Get Player Info from LoU. 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    string GetPlayerInfo(IJsonRequest json);

    /// <summary>
    /// Get Report from LoU. 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    string GetReport(IJsonRequest json);

    /// <summary>
    /// Get Server Info from LoU. 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    string GetServerInfo(IJsonRequest json);

    /// <summary>
    /// Standard query used to Poll the server. 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    string Poll(IJsonRequest json);

    /// <summary>
    /// Get Report Header Info from LoU. 
    /// </summary>
    /// <param name="json"></param>
    /// <returns></returns>
    string ReportGetHeader(IJsonRequest json);

  }
}