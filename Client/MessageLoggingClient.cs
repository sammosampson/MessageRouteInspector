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
            var graphQl = string.Format(
                "mutation logCommandProcessing {{ logCommandProcessing(name: \"{0}\", machine: \"{1}\", thread: {2}, createdOn: \"{3}\") }}",
                name,
                machineName,
                threadId,
                loggedOn.Ticks);

            await server.SendAsync(uri, graphQl);
        }
        
        public async Task LogEventProcessingAsync(string name, string machineName, int threadId, DateTime loggedOn)
        {
            var graphQl = string.Format(
                "mutation logEventProcessing {{ logEventProcessing(name: \"{0}\", machine: \"{1}\", thread: {2}, createdOn: \"{3}\") }}",
                name,
                machineName,
                threadId,
                loggedOn.Ticks);

            await server.SendAsync(uri, graphQl);
        }

        public async Task LogMessageProcessingFailureAsync(string name, string machineName, int threadId, DateTime loggedOn)
        {
            var graphQl = string.Format(
                "mutation logMessageProcessingFailure {{ logMessageProcessingFailure(name: \"{0}\", machine: \"{1}\", thread: {2}, createdOn: \"{3}\") }}",
                name,
                machineName,
                threadId,
                loggedOn.Ticks);

            await server.SendAsync(uri, graphQl);
        }

        public async Task LogMessageProcessedAsync(string machineName, int threadId)
        {
            var graphQl = string.Format(
                "mutation logMessageProcessed {{ logMessageProcessed(machine: \"{0}\", thread: {1}) }}",
                machineName,
                threadId);

            await server.SendAsync(uri, graphQl);
        }
    }
}