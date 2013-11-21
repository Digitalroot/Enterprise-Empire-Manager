using System.Collections.Generic;

namespace EEM.Common.Protocol
{
  public class ChatResponse : PollResponse<List<ChatResponseD>>
  {
    public List<ChatResponseD> Messages 
    { 
      get
      {
        return D;
      }
    }
  }
}