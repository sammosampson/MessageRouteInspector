namespace SystemDot.MessageRouteInspector.Client
{
    using System;
    using System.Threading.Tasks;

    public interface IMessageLoggingClient
    {
        Task LogCommandProcessingAsync(string name, string machineName, int threadId, DateTime loggedOn);

        Task LogEventProcessingAsync(string name, string machineName, int threadId, DateTime loggedOn);

        Task LogMessageProcessingFailureAsync(string name, string machineName, int threadId, DateTime loggedOn);

        Task LogMessageProcessedAsync(string machineName, int threadId);
    }
}