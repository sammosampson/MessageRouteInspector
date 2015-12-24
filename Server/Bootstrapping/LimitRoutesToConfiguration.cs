using Akka.TestKit;

namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.Bootstrapping;
    using SystemDot.MessageRouteInspector.Server.Domain;
    using SystemDot.MessageRouteInspector.Server.Queries;
    using Akka.Actor;

    public class LimitRoutesToConfiguration : BootstrapBuilderConfiguration
    {
        public LimitRoutesToConfiguration(BootstrapBuilderConfiguration @from)
            : base(@from)
        {
        }

        public BootstrapBuilderConfiguration WithRouteLimitOf(int limit)
        {
            return RegisterBuildAction(c => 
            {
                ActorSystem system = ActorSystem.Create("MessageRouteInspector");
                IActorRef routesView = system.ActorOf(Props.Create(() => new RoutesView()).WithDispatcher(CallingThreadDispatcher.Id));
                IActorRef logger = system.ActorOf(Props.Create(() => new MessageLogger()).WithDispatcher(CallingThreadDispatcher.Id));
                c.RegisterInstance(() => new RouteInspectorService(routesView, logger));
            });
        }
    }
}