using SystemDot.Akka;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Domain.Limits
{
    using Messages;

    internal class RouteLimitArbitrationProcessManager : ProcessManagerActor
    {
        public RouteLimitArbitrationProcessManager(IActorRef commandProcessor) : base(commandProcessor)
        {
            When<MessageRouteEnded>(@event => 
                Then(new CheckRouteLimit(@event.Id, @event.CreatedOn)));
        }
    }
}