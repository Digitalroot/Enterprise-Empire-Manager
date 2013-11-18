using System;
using Core.Common.Contracts;

namespace EEM.Common.Adapters
{
  internal class QueuedCommand
  {
    public IJsonRequest JsonRequest { get; private set; }
    public ServerCommand Command { get; private set; }
    public Int32 Id { get; private set; }

    internal QueuedCommand(IJsonRequest jsonRequest, ServerCommand command, Int32 id)
    {
      JsonRequest = jsonRequest;
      Command = command;
      Id = id;
    }
  }
}