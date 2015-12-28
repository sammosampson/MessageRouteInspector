using SystemDot.Akka;
using SystemDot.MessageRouteInspector.Server.Domain.Limits;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.Bootstrapping;
    using Domain;
    using Queries;

    public class RouteInspectorServerConfiguration : BootstrapBuilderConfiguration
    {
        IActorSystemFactory factory = new ActorSystemFactory();

        public RouteInspectorServerConfiguration(BootstrapBuilderConfiguration @from)
            : base(@from)
        {
        }

        public RouteInspectorServerConfiguration UsingActorSystemFactory<TActorSystemFactory>()
            where TActorSystemFactory : IActorSystemFactory
        {
            factory = GetIocContainer().Resolve<TActorSystemFactory>();
            return this;
        }

        public BootstrapBuilderConfiguration WithRouteLimitOf(int limit)
        {
            return RegisterBuildAction(c => 
            {
                ActorSystem system = factory.Create("MessageRouteInspector");

                IActorRef routesView = system.ActorOf(Props.Create(() => new RoutesView()));

                IActorRef routeLimitArbiter = system.ActorOf(Props.Create(() => new RouteLimitArbiter(new RouteLimit(limit))));
                system.ActorOf(Props.Create(() => new MessageRouteStartedProcessManager(routeLimitArbiter)));

                IActorRef logger = system.ActorOf(Props.Create(() => new MessageLogger()));
                c.RegisterInstance(() => new RouteInspectorService(routesView, logger));
            });
        }
    }
}