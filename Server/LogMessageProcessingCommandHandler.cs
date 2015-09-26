namespace SystemDot.MessageRouteInspector.Server
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.EventSourcing;

    public class LogMessageProcessingCommandHandler : IAsyncCommandHandler<LogMessageProcessing>
    {
        readonly IDomainRepository repository;

        public LogMessageProcessingCommandHandler(IDomainRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(LogMessageProcessing message)
        {
            var route = repository.Get<MessageRoute>(new MessageRouteId());
            route.StartMessage(message.MessageName, message.CreatedOn);
            repository.Save(route);

            await Task.FromResult(false);
        }
    }
}