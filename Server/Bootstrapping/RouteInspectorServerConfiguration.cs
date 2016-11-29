namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.Akka;
    using SystemDot.MessageRouteInspector.Server.Domain.Limits;
    using SystemDot.Bootstrapping;
    using SystemDot.MessageRouteInspector.Server.Domain.WebSockets;
    using Domain;
    using global::Akka.Actor;
    using Queries;

    public class RouteInspectorServerConfiguration : BootstrapBuilderConfiguration
    {
        private IActorSystemFactory factory;
        private IMessageRouteHubClient hubClient;

        public RouteInspectorServerConfiguration(BootstrapBuilderConfiguration @from)
            : base(@from)
        {
            factory = new ActorSystemFactory();
            hubClient = new MessageRouteHubClient();
        }

        public RouteInspectorServerConfiguration UsingActorSystemFactory<TActorSystemFactory>()
            where TActorSystemFactory : IActorSystemFactory
        {
            factory = GetIocContainer().Resolve<TActorSystemFactory>();
            return this;
        }

        public RouteInspectorServerConfiguration UsingRouteHubClient<TRouteHub>()
           where TRouteHub : IMessageRouteHubClient
        {
            hubClient = GetIocContainer().Resolve<TRouteHub>();
            return this;
        }

        public BootstrapBuilderConfiguration WithRouteLimitOf(int limit)
        {
            return RegisterBuildAction(c => 
            {
                ActorSystem system = factory.Create("MessageRouteInspector");

                IActorRef routesView = system.ActorOf(Props.Create(() => new RoutesView()));

                IActorRef routeLimitArbiter = system.ActorOf(Props.Create(() => new RouteLimitArbiter(new RouteLimit(limit))));
                system.ActorOf(Props.Create(() => new RouteLimitArbitrationProcessManager(routeLimitArbiter)));

                IActorRef logger = system.ActorOf(Props.Create(() => new MessageLogger()));
                system.ActorOf(Props.Create(() => new RouteHubBroadcaster(hubClient)));

                c.RegisterInstance(() => new RouteInspectorService(routesView, logger));
            });
        }
    }
}