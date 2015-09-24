namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Threading.Tasks;
    using SystemDot.Domain;
    using SystemDot.EventSourcing.Projections;

    [HydrateProjectionAtStartup]
    public class SetHirePurchaseTermsProjection : IProjection<MessageProcessingLogged>
    {
        readonly InMemoryStore inMemoryStore;

        public SetHirePurchaseTermsProjection(InMemoryStore inMemoryStore)
        {
            this.inMemoryStore = inMemoryStore;
        }

        public Task Handle(MessageProcessingLogged message)
        {
            inMemoryStore.Add(new Route
            {
                Root = new Message
                {
                    Name = message.MessageName
                }
            });

            return Task.FromResult(false);
        }
    }
}