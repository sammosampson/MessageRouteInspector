namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Threading.Tasks;
    using SystemDot.Domain;
    using SystemDot.Domain.Commands;
    using SystemDot.EventSourcing;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogMessageProcessedCommandHandler : IAsyncCommandHandler<LogMessageProcessed>
    {
        readonly IDomainRepository repository;
        readonly MessageRouteLookup lookup;

        public LogMessageProcessedCommandHandler(IDomainRepository repository, MessageRouteLookup lookup)
        {
            this.repository = repository;
            this.lookup = lookup;
        }

        public async Task Handle(LogMessageProcessed message)
        {
            if (!RouteExists(message))
            {
                return;
            }

            MessageRoute route = GetRoute(message);
            route.LogMessageProcessed();
            repository.Save(route);

            await Task.FromResult(false);
        }

        bool RouteExists(LogMessageProcessed message)
        {
            return lookup.MessageRouteExists(message.Machine, message.Thread);
        }

        MessageRoute GetRoute(LogMessageProcessed message)
        {
            return repository.Get<MessageRoute>(lookup.LookupMessageRouteId(message.Machine, message.Thread));
        }
    }
}