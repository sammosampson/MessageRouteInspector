namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.Bootstrapping;
    using Akka.Actor;

    public static class BuilderConfigurationExtensions
    {
        public static LimitRoutesToConfiguration ConfigureRouteInspectorServer(this BootstrapBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.Resolve<MessageRouteInpsectorActorSystem>().Initialise(), BuildOrder.Late);
            return new LimitRoutesToConfiguration(config);
        }
    }

    public class MessageRouteInpsectorActorSystem
    {
        public void Initialise()
        {
            var system = ActorSystem.Create("MessageRouteInspector");
        }
    }
}