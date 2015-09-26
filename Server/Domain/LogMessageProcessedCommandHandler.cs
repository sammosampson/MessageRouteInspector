namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.EventSourcing;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class LogMessageProcessedCommandHandler : IAsyncCommandHandler<LogMessageProcessed>
    {
        readonly IDomainRepository repository;

        public LogMessageProcessedCommandHandler(IDomainRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(LogMessageProcessed message)
        {
            var route = repository.Get<MessageRoute>(new MessageRouteId());
            route.LogMessageProcessed();
            repository.Save(route);

            await Task.FromResult(false);
        }
    }
}