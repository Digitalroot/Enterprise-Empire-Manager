using System.Collections.Specialized;
using System.Net;

namespace Core.Common.Contracts
{
  public interface IJsonWebClient
  {
    HttpStatusCode RequestStatusCode { get; }

    /// <summary>
    /// Does an HTTP Get.
    /// </summary>
    /// <param name="uri">http://www.example.com/login.aspx?mail=joe@example.com&password=mypass</param>
    /// <returns>The response from the web server at a string.</returns>
    string HttpGet(string uri);

    /// <summary>
    /// Does an HTTP Post.
    /// </summary>
    /// <param name="uri">http://www.example.com/login.aspx</param>
    /// <param name="parameters">mail=joe@example.com&password=mypass</param>
    /// <returns>The response from the web server at a string.</returns>
    string HttpPost(string uri, string parameters);

    /// <summary>
    /// Queries a URL without any parameters.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    string QueryUrl(string url);

    /// <summary>
    /// Queries a URL with headers that make it look like an Ajax request.
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    string QueryUrlAsAJAXRequest(string url);

    /// <summary>
    /// Queries a URL with headers that make it look like an Ajax request.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="referer"></param>
    /// <returns></returns>
    string QueryUrlAsAJAXRequest(string url, string referer);

    /// <summary>
    /// Queries a URL with headers that make it look like an Ajax request.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="formData"></param>
    /// <returns></returns>
    string QueryUrlAsAJAXRequest(string url, NameValueCollection formData);

    /// <summary>
    /// Queries a URL with headers that make it look like a JSON request.
    /// </summary>
    /// <param name="url"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    string QueryUrlAsJSONRequest(string url, IJsonRequest json);

    /// <summary>
    /// Queries a URL with headers that make it look like a JSON request.
    /// </summary>
    /// <param name="url">URL to send the request to.</param>
    /// <param name="json">JSON data to send</param>
    /// <param name="referrer">URL of referrer</param>
    /// <returns></returns>
    string QueryUrlAsJSONRequest(string url, IJsonRequest json, string referrer);
  }
}