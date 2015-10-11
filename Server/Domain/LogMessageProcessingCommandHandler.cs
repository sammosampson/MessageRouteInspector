namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogMessageProcessingCommandHandler : IAsyncCommandHandler<LogMessageProcessing>
    {
        readonly MessageRouteLookup lookup;

        public LogMessageProcessingCommandHandler(MessageRouteLookup lookup)
        {
            this.lookup = lookup;
        }

        public async Task Handle(LogMessageProcessing message)
        {
            MessageRoute route = lookup.MessageRouteExists(message.Machine, message.Thread) 
                ? lookup.LookupMessageRoute(message.Machine, message.Thread)
                : lookup.OpenRoute(message.Machine, message.Thread, message.CreatedOn);

            route.LogMessageProcessing(message.MessageName, message.MessageType);

            await Task.FromResult(false);
        }
    }
}