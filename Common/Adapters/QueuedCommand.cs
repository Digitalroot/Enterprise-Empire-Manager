using System;
using EEM.Common.Protocol;

namespace EEM.Common.Adapters
{
  internal class QueuedCommand
  {
    public JsonRequest JsonRequest { get; private set; }
    public ServerCommand Command { get; private set; }
    public Int32 Id { get; private set; }

    internal QueuedCommand(JsonRequest jsonRequest, ServerCommand command, Int32 id)
    {
      JsonRequest = jsonRequest;
      Command = command;
      Id = id;
    }
  }
}