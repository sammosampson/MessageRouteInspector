namespace SystemDot.MessageRouteInspector.Client
{
    using System;
    using System.Threading.Tasks;

    public class MessageLoggingClient : IMessageLoggingClient
    {
        private readonly IGraphQlServer server;
        private readonly GraphQlServerUri uri;

        public MessageLoggingClient(IGraphQlServer server, GraphQlServerUri uri)
        {
            this.server = server;
            this.uri = uri;
        }

        public async Task LogCommandProcessingAsync(string name, string machineName, int threadId, DateTime loggedOn)
        {
            await server.SendAsync(
                uri, 
                GraphQlMutation
                    .Named("logCommandProcessing")
                    .WithArgument("name", name)
                    .WithArgument("machine", machineName)
                    .WithArgument("thread", threadId)
                    .WithArgument("createdOn", loggedOn.Ticks.ToString()));
        }
        
        public async Task LogEventProcessingAsync(string name, string machineName, int threadId, DateTime loggedOn)
        {
            await server.SendAsync(
                uri,
                GraphQlMutation
                    .Named("logEventProcessing")
                    .WithArgument("name", name)
                    .WithArgument("machine", machineName)
                    .WithArgument("thread", threadId)
                    .WithArgument("createdOn", loggedOn.Ticks.ToString()));
        }

        public async Task LogMessageProcessingFailureAsync(string name, string machineName, int threadId, DateTime loggedOn)
        {
            await server.SendAsync(
                uri,
                GraphQlMutation
                    .Named("logMessageProcessingFailure")
                    .WithArgument("name", name)
                    .WithArgument("machine", machineName)
                    .WithArgument("thread", threadId)
                    .WithArgument("createdOn", loggedOn.Ticks.ToString()));
        }

        public async Task LogMessageProcessedAsync(string machineName, int threadId)
        {
            await server.SendAsync(
               uri,
               GraphQlMutation
                   .Named("logMessageProcessed")
                   .WithArgument("machine", machineName)
                   .WithArgument("thread", threadId));
        }
    }
}