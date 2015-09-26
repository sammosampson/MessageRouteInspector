namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Linq;
    using System.Threading.Tasks;
    using SystemDot.Domain.Queries;

    public class GetRoutesQueryHandler : IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse>
    {
        readonly RouteCollection routes;

        public GetRoutesQueryHandler(RouteCollection routes)
        {
            this.routes = routes;
        }

        public Task<GetRoutesQueryResponse> Handle(GetRoutesQuery message)
        {
            return Task.FromResult(new GetRoutesQueryResponse
            {
                Routes = GetRoutes()
            });
        }

        Route[] GetRoutes()
        {
            return routes.ToArray();
        }
    }
}