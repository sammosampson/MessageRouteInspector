namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Threading.Tasks;
    using SystemDot.Domain.Queries;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class GetRouteQueryHandler : IAsyncQueryHandler<GetRouteQuery, GetRouteQueryResponse>
    {
        readonly AllRoutes allRoutes;

        public GetRouteQueryHandler(AllRoutes allRoutes)
        {
            this.allRoutes = allRoutes;
        }

        public Task<GetRouteQueryResponse> Handle(GetRouteQuery message)
        {
            return Task.FromResult(new GetRouteQueryResponse
            {
                Route = allRoutes.ContainsRoute(message.RouteId) ? allRoutes[message.RouteId] : null
            });
        }
    }
}