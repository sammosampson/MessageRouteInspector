namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using SystemDot.Domain;
    using SystemDot.EventSourcing.Projections;
    using SystemDot.MessageRouteInspector.Server.Messages;

    [HydrateProjectionAtStartup]
    public class AllRoutesProjection :
        IProjection<MessageRouteStarted>,
        IProjection<MessageBranchCompleted>

    {
        readonly InMemoryStore inMemoryStore;

        public AllRoutesProjection(InMemoryStore inMemoryStore)
        {
            this.inMemoryStore = inMemoryStore;
        }

        public Task Handle(MessageRouteStarted message)
        {
            inMemoryStore.Add(new Route
            {
                CreatedOn = message.CreatedOn,
                Messages = new Message[0]
            });

            return Task.FromResult(false);
        }

        public Task Handle(MessageBranchCompleted message)
        {
            Route route = inMemoryStore.Query<Route>().First();
            route.Messages = new List<Message>(route.Messages) { AddMessage(message) }.ToArray();
            SetRootToFirstMessage(route);

            return Task.FromResult(false);
        }

        static void SetRootToFirstMessage(Route route)
        {
            if (route.Messages.Count() == 1)
            {
                route.Root = route.Messages.First();
            }
        }

        static Message AddMessage(MessageBranchCompleted message)
        {
            return new Message
            {
                Name = message.MessageName,
                CloseBranchCount = message.CloseBranchCount
            };
        }
    }
}