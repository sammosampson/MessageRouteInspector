namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class Route
    {
        public string Id { get; private set; }
        public Message Root { get; private set; }
        public Message[] Messages { get; private set; }
        public string CreatedOn { get; private set; }
        public string MachineName { get; private set; }

        public Route()
        {
            Messages = new Message[0];
        }
    }
}