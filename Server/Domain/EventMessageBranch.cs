namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class EventMessageBranch : MessageBranch
    {
        public EventMessageBranch(string name) : base(MessageType.Event, name)
        {

        }
    }
}