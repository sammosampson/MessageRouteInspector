namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Threading.Tasks;
    using SystemDot.EventSourcing.Projections;
    using SystemDot.MessageRouteInspector.Server.Messages;

    [HydrateProjectionAtStartup]
    public class AllRoutesProjection :
        IProjection<MessageRouteStarted>,
        IProjection<MessageBranchCompleted>
    {
        readonly AllRoutes allRoutes;

        public AllRoutesProjection(AllRoutes allRoutes)
        {
            this.allRoutes = allRoutes;
        }

        public Task Handle(MessageRouteStarted message)
        {
            allRoutes.AddRoute(message.Id, message.CreatedOn);
            return Task.FromResult(false);
        }

        public Task Handle(MessageBranchCompleted message)
        {
            allRoutes.AddMessage(message.RouteId, message);
            return Task.FromResult(false);
        }
    }
}