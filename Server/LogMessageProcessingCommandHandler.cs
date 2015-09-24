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
            repository.Save(MessageRoute.AppendMessage(message.MessageName));
            await Task.FromResult(false);
        }
    }
}