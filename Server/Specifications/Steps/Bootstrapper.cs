using SystemDot.Akka.Testing;

namespace SystemDot.MessageRouteInspector.Server.Specifications.Steps
{
    using SystemDot.Bootstrapping;
    using Environment;
    using Ioc;
    using Bootstrapping;

    public static class Bootstrapper
    {
        public static RouteInspectorService LimitRoutesTo(int limit)
        {
            var iocContainer = new IocContainer();

            Bootstrap.Application()
                .ResolveReferencesWith(iocContainer)
                .UseEnvironment()
                .ConfigureRouteInspectorServer()
                    .UsingActorSystemFactory<TestingActorSystemFactory>()
                    .WithRouteLimitOf(limit)
                .Initialise();

            return iocContainer.Resolve<RouteInspectorService>();
        }
    }
}