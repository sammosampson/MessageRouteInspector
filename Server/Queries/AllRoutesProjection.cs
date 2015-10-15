namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Threading.Tasks;
    using SystemDot.EventSourcing.Projections;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class AllRoutesProjection :
        IProjection<MessageRouteStarted>,
        IProjection<MessageRouteLimitReached>,
        IProjection<MessageBranchCompleted>
    {
        readonly AllRoutes allRoutes;

        public AllRoutesProjection(AllRoutes allRoutes)
        {
            this.allRoutes = allRoutes;
        }

        public Task Handle(MessageRouteStarted message)
        {
            allRoutes.AddRoute(message.Id.ToString(), message.CreatedOn, message.MachineName);
            return Task.FromResult(false);
        }

        public Task Handle(MessageRouteLimitReached message)
        {
            allRoutes.RemoveRoute(message.ToRemove.ToString());
            return Task.FromResult(false);
        }

        public Task Handle(MessageBranchCompleted message)
        {
            allRoutes.AddMessage(message.RouteId.ToString(), message);
            return Task.FromResult(false);
        }
    }
}