using System.Collections;
using System.Text;
using Core.Common;
using Core.Common.Contracts;

namespace EEM.Common
{
  public static class Poll
  {
    public static IJsonRequest Request(string sessionId, int requestCount, Hashtable requestList)
    {
      var request = new StringBuilder();

      foreach (string item in requestList.Keys)
      {
        request.Append(item).Append(":").Append(requestList[item]).Append("\f");
      }
      return new JsonRequest(new {session = sessionId, requestid = requestCount, requests = request.ToString()});
    }
  }
}
