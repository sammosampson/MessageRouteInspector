namespace SystemDot.MessageRouteInspector.Server.Specifications.Steps
{
    using System;
    using System.Threading.Tasks;
    using SystemDot.MessageRouteInspector.Server.Messages;
    using Akka.Actor;

    public class MessageLogger
    {
        readonly IActorRef routesProjection;

        public MessageLogger(IActorRef routesProjection)
        {
            this.routesProjection = routesProjection;
        }

        public async Task<int> LogCommandProcessingAsync(string messageName, string machine, int thread, DateTime createdOn)
        {
            throw new NotImplementedException();
        }

        public async Task LogEventProcessingAsync(string messageName, string machine, int thread, DateTime createdOn)
        {
            throw new NotImplementedException();
        }

        public async Task LogMessageProcessingFailureAsync(string failureName, string machine, int thread, DateTime createdOn)
        {
            throw new NotImplementedException();
        }

        public async Task LogMessageProcessedAsync(string machine, int thread)
        {
            throw new NotImplementedException();
        }

        public async Task<Route[]> GetRoutesAsync()
        {
            var response = await routesProjection.Ask<GetRoutesQueryResponse>(new GetRoutesQuery());
            return response.Routes;
        }

        public async Task<Route> GetRouteAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}