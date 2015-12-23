namespace SystemDot.MessageRouteInspector.Server
{
    using System;
    using System.Threading.Tasks;
    using SystemDot.MessageRouteInspector.Server.Messages;
    using Akka.Actor;

    public class RouteInspectorService
    {
        readonly IActorRef routesView;
        private readonly IActorRef logger;

        public RouteInspectorService(IActorRef routesView, IActorRef logger)
        {
            this.routesView = routesView;
            this.logger = logger;
        }

        public async Task<int> LogCommandProcessingAsync(string messageName, string machine, int thread, DateTime createdOn)
        {
            logger.Tell(new LogCommandProcessing());
            return await Task.FromResult(0);
        }

        public async Task LogEventProcessingAsync(string messageName, string machine, int thread, DateTime createdOn)
        {
            await Task.FromResult(false);
        }

        public async Task LogMessageProcessingFailureAsync(string failureName, string machine, int thread, DateTime createdOn)
        {
            await Task.FromResult(false);
        }

        public async Task LogMessageProcessedAsync(string machine, int thread)
        {
            await Task.FromResult(false);
        }

        public async Task<Route[]> GetRoutesAsync()
        {
            return await routesView.Ask<Route[]>(new GetRoutes());
        }

        public async Task<Route> GetRouteAsync(string id)
        {
            return await Task.FromResult(new Route());
        }
    }
}