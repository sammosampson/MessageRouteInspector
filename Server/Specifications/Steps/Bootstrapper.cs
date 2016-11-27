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
                    .UsingRouteHubLocator<TestingRouteHubLocator>()
                    .WithRouteLimitOf(limit)
                .Initialise();

            return iocContainer.Resolve<RouteInspectorService>();
        }
    }

    public class TestingRouteHubLocator : IMessageRouteHubLocator
    {
        public IMessageRouteHub Locate()
        {
            return new TestingMessageRouteHub();
        }
    }

    public class TestingMessageRouteHub : IMessageRouteHub
    {
        public void MessageRouteStarted(Guid id, DateTime createdOn, string machineName, int thread)
        {
        }

        public void MessageRouteEnded(Guid id, DateTime createdOn)
        {
        }

        public void MessageBranchCompleted(Guid routeId, Guid messageId, string messageName, MessageType messageType, int closeBranchCount)
        {
        }
    }
}