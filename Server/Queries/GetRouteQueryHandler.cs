namespace SystemDot.MessageRouteInspector.Server.Queries
{
    using System;
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
            Route route;

            try
            {
                route = allRoutes[message.RouteId];
            }
            catch (Exception)
            {
                route = new Route
                {
                    Root = new Message
                    {
                        Name  = "No Route"
                    },
                    Messages = new[]
                    {
                        new Message
                        {
                            Name = "No Route",
                            CloseBranchCount = 1
                        }
                    }
                };
            }
            
            var getRouteQueryResponse = new GetRouteQueryResponse
            {
                Route = route
            };

            return Task.FromResult(getRouteQueryResponse);
        }
    }
}