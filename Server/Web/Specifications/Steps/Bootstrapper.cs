namespace SystemDot.MessageRouteInspector.Server.Web.Specifications.Steps
{
    using SystemDot.Akka.Testing;
    using SystemDot.Bootstrapping;
    using SystemDot.Environment;
    using SystemDot.Ioc;
    using SystemDot.MessageRouteInspector.Server.Bootstrapping;
    using SystemDot.MessageRouteInspector.Server.Web;

    public static class Bootstrapper
    {
        public static GraphQlExecuter Bootstrap(int limitOfStoredRoutes)
        {
            var iocContainer = new IocContainer();

            SystemDot.Bootstrapping.Bootstrap.Application()
                .ResolveReferencesWith(iocContainer)
                .UseEnvironment()
                .ConfigureRouteInspectorServer()
                    .UsingActorSystemFactory<TestingActorSystemFactory>()
                    .WithRouteLimitOf(limitOfStoredRoutes)
                .Initialise();

            return iocContainer.Resolve<GraphQlExecuter>();
        }
    }
}