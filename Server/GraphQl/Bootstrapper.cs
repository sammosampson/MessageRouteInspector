namespace SystemDot.MessageRouteInspector.Server.GraphQl
{
    using SystemDot.Bootstrapping;
    using SystemDot.Domain;
    using SystemDot.Domain.Bootstrapping;
    using SystemDot.Environment;
    using SystemDot.EventSourcing.Bootstrapping;
    using SystemDot.EventSourcing.InMemory.Bootstrapping;
    using SystemDot.Ioc;
    using SystemDot.MessageRouteInspector.Server.Bootstrapping;

    public static class Bootstrapper
    {
        public static GraphQlExecuter Bootstrap(int limitOfStoredRoutes)
        {
            var iocContainer = new IocContainer();

            SystemDot.Bootstrapping.Bootstrap.Application()
                .ResolveReferencesWith(iocContainer)
                .UseEnvironment()
                .UseDomain().WithSimpleMessaging()
                .ConfigureRouteInspectorServer().WithRouteLimitOf(limitOfStoredRoutes)
                .UseEventSourcing().PersistToMemory()
                .Initialise();

            return iocContainer.Resolve<GraphQlExecuter>();
        }
    }
}