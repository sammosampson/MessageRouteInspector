namespace SystemDot.MessageRouteInspector.Server
{
    using System.Threading.Tasks;
    using SystemDot.Domain;
    using SystemDot.Domain.Commands;
    using SystemDot.EventSourcing;
    using SystemDot.EventSourcing.Aggregation;

    public class LogMessageProcessingCommandHandler : IAsyncCommandHandler<LogMessageProcessing>
    {
        private readonly IDomainRepository repository;

        public LogMessageProcessingCommandHandler(IDomainRepository repository)
        {
            this.repository = repository;
        }

        public async Task Handle(LogMessageProcessing message)
        {
            repository
                .Get<MessageRoute>(new MessageRouteId())
                .AppendMessage(message.MessageName);

            await Task.FromResult(false);
        }
    }

    public class MessageRouteId : MultiSiteId
    {
        public MessageRouteId()
            : base("1", "1")
        {
        }
    }

    public class MessageRoute : AggregateRoot
    {
        public void AppendMessage(string message)
        {
            throw new System.NotImplementedException();
        }
    }
}