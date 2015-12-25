namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.Bootstrapping;
    using SystemDot.MessageRouteInspector.Server.Domain;
    using SystemDot.MessageRouteInspector.Server.Queries;
    using Akka.Actor;

    public class RouteInspectorServerConfiguration : BootstrapBuilderConfiguration
    {
        IActorSystemFactory factory = new ActorSystemFactory();

        public RouteInspectorServerConfiguration(BootstrapBuilderConfiguration @from)
            : base(@from)
        {
        }

        public RouteInspectorServerConfiguration UsingActorSystemFactory<TActorSystemFactory>()
            where TActorSystemFactory : IActorSystemFactory, new()
        {
            factory = new TActorSystemFactory();
            return this;
        }

        public BootstrapBuilderConfiguration WithRouteLimitOf(int limit)
        {
            return RegisterBuildAction(c => 
            {
                ActorSystem system = factory.Create("MessageRouteInspector");
                IActorRef routesView = system.ActorOf(Props.Create(() => new RoutesView()), "routesView");
                IActorRef logger = system.ActorOf(Props.Create(() => new MessageLogger()), "messageLogger");
                c.RegisterInstance(() => new RouteInspectorService(routesView, logger));
            });
        }
    }
}