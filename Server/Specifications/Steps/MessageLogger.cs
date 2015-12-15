namespace SystemDot.MessageRouteInspector.Server.Specifications.Steps
{
    using System;
    using System.Threading.Tasks;
    using SystemDot.Domain.Commands;
    using SystemDot.Domain.Queries;
    using SystemDot.MessageRouteInspector.Server.Messages;

    public class MessageLogger
    {
        private readonly CommandBus commandBus;
        readonly IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse> getRoutesQueryHandler;
        readonly IAsyncQueryHandler<GetRouteQuery, GetRouteQueryResponse> getRouteQueryHandler;
        
        public MessageLogger(
            CommandBus commandBus, 
            IAsyncQueryHandler<GetRoutesQuery, GetRoutesQueryResponse> getRoutesQueryHandler, 
            IAsyncQueryHandler<GetRouteQuery, GetRouteQueryResponse> getRouteQueryHandler)
        {
            this.commandBus = commandBus;
            this.getRoutesQueryHandler = getRoutesQueryHandler;
            this.getRouteQueryHandler = getRouteQueryHandler;
        }

        public async Task<int> LogCommandProcessingAsync(string messageName, string machine, int thread, DateTime createdOn)
        {
            await commandBus.SendCommandAsync(new LogCommandProcessing
            {
                MessageName = messageName,
                CreatedOn = createdOn,
                Machine = machine,
                Thread = thread
            });

            return 1;
        }

        public async Task LogEventProcessingAsync(string messageName, string machine, int thread, DateTime createdOn)
        {
            await commandBus.SendCommandAsync(new LogEventProcessing
            {
                MessageName = messageName,
                CreatedOn = createdOn,
                Machine = machine,
                Thread = thread
            });
        }

        public async Task LogMessageProcessingFailureAsync(string failureName, string machine, int thread, DateTime createdOn)
        {
            await commandBus.SendCommandAsync(new LogMessageProcessingFailure
            {
                FailureName = failureName,
                CreatedOn = createdOn,
                Machine = machine,
                Thread = thread
            });
        }

        public async Task LogMessageProcessedAsync(string machine, int thread)
        {
            await commandBus.SendCommandAsync(new LogMessageProcessed
            {
                Machine = machine, 
                Thread = thread
            });
        }

        public async Task<Route[]> GetRoutesAsync()
        {
            GetRoutesQueryResponse response = await getRoutesQueryHandler.Handle(new GetRoutesQuery());
            return response.Routes;
        }

        public async Task<Route> GetRouteAsync(string id)
        {
            var response = await getRouteQueryHandler.Handle(new GetRouteQuery { RouteId = id });
            return response.Route;
        }
    }
}