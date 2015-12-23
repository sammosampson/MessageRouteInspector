namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using SystemDot.MessageRouteInspector.Server.Messages;
    using Akka.Actor;

    public class MessageLogger : ReceiveActor
    {
        public MessageLogger()
        {
            Receive<LogCommandProcessing>(command => Context.System.EventStream.Publish(new MessageRouteStarted()));
        }
    }
}