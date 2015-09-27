namespace SystemDot.MessageRouteInspector.Server
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

        public async Task LogCommandProcessingAsync(string messageName, string machine, int thread, DateTime dated)
        {
            await commandBus.SendCommandAsync(new LogMessageProcessing
            {
                MessageName = messageName,
                MessageType = MessageType.Command,
                CreatedOn = dated,
                Machine = machine,
                Thread = thread
            });
        }

        public async Task LogEventProcessingAsync(string messageName, string machine, int thread, DateTime dated)
        {
            await commandBus.SendCommandAsync(new LogMessageProcessing
            {
                MessageName = messageName,
                MessageType = MessageType.Event,
                CreatedOn = dated,
                Machine = machine,
                Thread = thread
            });
        }

        public async Task LogMessageProcessingFailureAsync(string failureName, string machine, int thread, DateTime dated)
        {
            await commandBus.SendCommandAsync(new LogMessageProcessingFailure
            {
                FailureName = failureName,
                CreatedOn = dated,
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
            GetRoutesQueryResponse response =  await getRoutesQueryHandler.Handle(new GetRoutesQuery());
            return response.Routes;
        }

        public async Task<Route> GetRouteAsync(string id)
        {
            var response = await getRouteQueryHandler.Handle(new GetRouteQuery { RouteId = id });
            return response.Route;
        }
    }
}