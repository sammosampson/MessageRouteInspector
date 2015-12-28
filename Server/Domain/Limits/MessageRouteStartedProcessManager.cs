using SystemDot.Akka;
using Akka.Actor;

namespace SystemDot.MessageRouteInspector.Server.Domain.Limits
{
    using Messages;

    public class MessageRouteStartedProcessManager : ProcessManagerActor
    {
        public MessageRouteStartedProcessManager(IActorRef commandProcessor) : base(commandProcessor)
        {
            When<MessageRouteStarted>(@event => 
                Then(new CheckRouteLimit
                {
                    RouteId = @event.Id,
                    CreatedOn = @event.CreatedOn
                }));
        }
    }
}