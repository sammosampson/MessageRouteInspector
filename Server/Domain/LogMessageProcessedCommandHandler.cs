namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.Domain.Events;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogMessageProcessedCommandHandler : IAsyncCommandHandler<LogMessageProcessed>
    {
        readonly IEventBus bus;
        readonly MessageRouteLookup lookup;

        public LogMessageProcessedCommandHandler(IEventBus bus, MessageRouteLookup lookup)
        {
            this.bus = bus;
            this.lookup = lookup;
        }

        public async Task Handle(LogMessageProcessed message)
        {
            if (lookup.MessageRouteExists(message.Machine, message.Thread))
            {
                lookup.LookupMessageRoute(message.Machine, message.Thread).LogMessageProcessed();
            }

            await Task.FromResult(false);
        }
    }
}