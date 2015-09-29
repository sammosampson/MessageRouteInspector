namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Linq;
    using System.Threading.Tasks;
    using SystemDot.Domain.Queries;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class GetRoutesQueryHandler : IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse>
    {
        readonly AllRoutes allRoutes;

        public GetRoutesQueryHandler(AllRoutes allRoutes)
        {
            this.allRoutes = allRoutes;
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
            return allRoutes.ToArray();
        }
    }
}