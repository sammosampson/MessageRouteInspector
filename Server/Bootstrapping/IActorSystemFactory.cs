namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using Akka.Actor;

    public interface IActorSystemFactory
    {
        ActorSystem Create(string name);
    }
}