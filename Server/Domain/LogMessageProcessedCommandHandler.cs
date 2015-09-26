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
            var route = repository.Get<MessageRoute>(lookup.LookupMessageRouteId(message.Machine, message.Thread));
            route.LogMessageProcessed();
            repository.Save(route);

            await Task.FromResult(false);
        }
    }
}