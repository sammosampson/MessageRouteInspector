namespace SystemDot.MessageRouteInspector.Server.Specifications.Steps
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
        public static RouteInspectorService LimitRoutesTo(int limit)
        {
            var iocContainer = new IocContainer();

            Bootstrap.Application()
                .ResolveReferencesWith(iocContainer)
                .UseEnvironment()
                .UseDomain().WithSimpleMessaging()
                .ConfigureRouteInspectorServer().WithRouteLimitOf(limit)
                .UseEventSourcing().PersistToMemory()
                .Initialise();

            return iocContainer.Resolve<RouteInspectorService>();
        }
    }
}