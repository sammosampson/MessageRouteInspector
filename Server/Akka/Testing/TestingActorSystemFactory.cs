using Akka.Actor;
using Akka.TestKit;

namespace SystemDot.Akka.Testing
{
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