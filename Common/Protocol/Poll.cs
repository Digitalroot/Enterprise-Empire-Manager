using System.Collections;
using System.Text;

namespace EEM.Common.Protocol
{
  public static class Poll
  {
    public static JsonRequest Request(string sessionId, int requestCount, Hashtable requestList)
    {
      StringBuilder request = new StringBuilder();

      foreach (string item in requestList.Keys)
      {
        request.Append(item).Append(":").Append(requestList[item]).Append("\f");
      }
      return new JsonRequest(new {session = sessionId, requestid = requestCount, requests = request.ToString()});
    }
  }
}
