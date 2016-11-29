using SystemDot.Akka.Testing;

namespace SystemDot.MessageRouteInspector.Server.Specifications.Steps
{
    using System;
    using SystemDot.Bootstrapping;
    using SystemDot.MessageRouteInspector.Server.Domain.WebSockets;
    using Environment;
    using Ioc;
    using Bootstrapping;

    public static class Bootstrapper
    {
        public static RouteInspectorService Bootstrap(int limit, ViewChangeWatcherContext viewChangeWatcherContext)
        {
            var iocContainer = new IocContainer();
            iocContainer.RegisterInstance(() => viewChangeWatcherContext);
            
            SystemDot.Bootstrapping.Bootstrap.Application()
                .ResolveReferencesWith(iocContainer)
                .UseEnvironment()
                .ConfigureRouteInspectorServer()
                    .UsingActorSystemFactory<TestingActorSystemFactory>()
                    .UsingRouteHubClient<TestingRouteHubClient>()
                    .WithRouteLimitOf(limit)
                .Initialise();

            return iocContainer.Resolve<RouteInspectorService>();
        }
    }

    public class TestingRouteHubClient : IMessageRouteHubClient
    {
        public void MessageRouteStarted(string id, long createdOn, string machineName, int thread)
        {
        }

        public void MessageRouteEnded(string id, long createdOn)
        {
        }

        public void MessageBranchCompleted(string routeId, string messageId, string messageName, int messageType, int closeBranchCount)
        {
        }
    }
}