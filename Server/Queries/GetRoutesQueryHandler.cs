namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System.Linq;
    using System.Threading.Tasks;
    using SystemDot.Domain;
    using SystemDot.Domain.Queries;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class GetRoutesQueryHandler : IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse>
    {
        readonly InMemoryStore inMemoryStore;

        public GetRoutesQueryHandler(InMemoryStore inMemoryStore)
        {
            this.inMemoryStore = inMemoryStore;
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
            return inMemoryStore.Query<Route>().ToArray();
        }
    }
}