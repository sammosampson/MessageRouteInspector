using Akka.Actor;
namespace SystemDot.MessageRouteInspector.Server
{
    using System;
    using System.Threading.Tasks;
    using Messages;
    
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
            logger.Tell(new LogCommandProcessing(messageName, createdOn, machine, thread));
            return await Task.FromResult(1);
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

        public Task<Route> GetRouteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}