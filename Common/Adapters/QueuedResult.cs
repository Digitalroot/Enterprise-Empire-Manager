using System;

namespace EEM.Common.Adapters
{
  internal class QueuedResult
  {
    public string Result { get; private set; }
    public Int32 Id { get; private set; }

    internal QueuedResult(string result, Int32 id)
    {
      Result = result;
      Id = id;
    }
  }
}