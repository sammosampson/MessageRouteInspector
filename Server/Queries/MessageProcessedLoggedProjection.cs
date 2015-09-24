namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Threading.Tasks;
    using SystemDot.Domain;
    using SystemDot.EventSourcing.Projections;

    [HydrateProjectionAtStartup]
    public class MessageProcessedLoggedProjection : IProjection<MessageProcessedLogged>
    {
        readonly InMemoryStore inMemoryStore;

        public MessageProcessedLoggedProjection(InMemoryStore inMemoryStore)
        {
            this.inMemoryStore = inMemoryStore;
        }

        public Task Handle(MessageProcessedLogged message)
        {
            inMemoryStore.Add(new Route
            {
                Root = new Message
                {
                    Name = message.MessageName
                },
                CreatedOn = message.CreatedOn
            });

            return Task.FromResult(false);
        }
    }
}