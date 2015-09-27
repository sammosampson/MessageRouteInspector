namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.EventSourcing;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogMessageProcessingFailureCommandHandler : IAsyncCommandHandler<LogMessageProcessingFailure>
    {
        readonly IDomainRepository repository;
        readonly MessageRouteLookup lookup;

        public LogMessageProcessingFailureCommandHandler(IDomainRepository repository, MessageRouteLookup lookup)
        {
            this.repository = repository;
            this.lookup = lookup;
        }

        public async Task Handle(LogMessageProcessingFailure message)
        {
            if (!RouteExists(message))
            {
                return;
            }

            MessageRoute route = GetRoute(message);
            route.LogMessageProcessingFailure(message.FailureName);
            repository.Save(route);

            await Task.FromResult(false);
        }

        bool RouteExists(LogMessageProcessingFailure message)
        {
            return lookup.MessageRouteExists(message.Machine, message.Thread);
        }

        MessageRoute GetRoute(LogMessageProcessingFailure message)
        {
            return repository.Get<MessageRoute>(lookup.LookupMessageRouteId(message.Machine, message.Thread));
        }
    }
}