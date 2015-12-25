namespace SystemDot.MessageRouteInspector.Server.Specifications.Steps
{
    using SystemDot.MessageRouteInspector.Server.Bootstrapping;
    using Akka.Actor;
    using Akka.TestKit;

    public class TestingActorSystemFactory : IActorSystemFactory
    {
        public ActorSystem Create(string name)
        {
            ActorSystem system = ActorSystem.Create(name);
            system.Dispatchers.RegisterConfigurator(CallingThreadDispatcher.Id, new CallingThreadDispatcherConfigurator(system.Settings.Config, system.Dispatchers.Prerequisites));
            return system;
        }
    }
}