namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.EventSourcing;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogMessageProcessingCommandHandler : IAsyncCommandHandler<LogMessageProcessing>
    {
        readonly IDomainRepository repository;
        readonly MessageRouteLookup lookup;

        public LogMessageProcessingCommandHandler(IDomainRepository repository, MessageRouteLookup lookup)
        {
            this.repository = repository;
            this.lookup = lookup;
        }

        public async Task Handle(LogMessageProcessing message)
        {
            MessageRoute route = !RouteExists(message) ? StartRoute(message) : GetRoute(message);
            route.LogMessageProcessing(message.MessageName);
            repository.Save(route);

            await Task.FromResult(false);
        }

        bool RouteExists(LogMessageProcessing message)
        {
            return lookup.MessageRouteExists(message.Machine, message.Thread);
        }

        static MessageRoute StartRoute(LogMessageProcessing message)
        {
            return MessageRoute.Start(message.Machine, message.Thread, message.CreatedOn);
        }

        MessageRoute GetRoute(LogMessageProcessing message)
        {
            return repository.Get<MessageRoute>(lookup.LookupMessageRouteId(message.Machine, message.Thread));
        }
    }
}