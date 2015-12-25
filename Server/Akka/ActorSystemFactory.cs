namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using Akka.Actor;

    public class ActorSystemFactory : IActorSystemFactory
    {
        public ActorSystem Create(string name)
        {
            ActorSystem system = ActorSystem.Create(name);
            return system;
        }
    }
}