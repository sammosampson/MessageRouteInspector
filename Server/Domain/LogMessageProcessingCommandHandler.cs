namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Threading.Tasks;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public abstract class LogMessageProcessingCommandHandler<TCommand> where TCommand : LogMessageProcessing
    {
        readonly MessageRouteLookup lookup;

        protected LogMessageProcessingCommandHandler(MessageRouteLookup lookup)
        {
            this.lookup = lookup;
        }

        public async Task Handle(TCommand message)
        {
            MessageRoute route = lookup.MessageRouteExists(message.Machine, message.Thread) 
                ? lookup.LookupMessageRoute(message.Machine, message.Thread)
                : lookup.OpenRoute(message.Machine, message.Thread, message.CreatedOn);

            route.LogMessageProcessing(message.MessageName, MessageType);

            await Task.FromResult(false);
        }

        protected abstract MessageType MessageType{ get; }
    }
}