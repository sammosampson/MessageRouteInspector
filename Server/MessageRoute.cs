namespace SystemDot.MessageRouteInspector.Server
{
    using SystemDot.EventSourcing.Aggregation;

    public class MessageRoute : AggregateRoot
    {
        public static MessageRoute AppendMessage(string message)
        {
            return new MessageRoute(message);
        }

        MessageRoute(string message) : base(new MessageRouteId())
        {
            AddEvent(new MessageProcessingLogged { MessageName = message });
        }
    }
}