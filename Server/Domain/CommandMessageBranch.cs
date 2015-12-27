namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class CommandMessageBranch : MessageBranch
    {
        public CommandMessageBranch(string name) : base(MessageType.Command, name)
        {

        }
    }
}