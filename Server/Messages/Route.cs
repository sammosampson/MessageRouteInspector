namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class Route
    {
        public string Id { get; private set; }
        public Message Root { get; set; }
        public Message[] Messages { get; set; }
        public string CreatedOn { get; private set; }
        public string MachineName { get; private set; }

        public Route(string id, Message root, Message[] messages, string createdOn, string machineName)
        {
            Id = id;
            Root = root;
            Messages = messages;
            CreatedOn = createdOn;
            MachineName = machineName;
        }
    }
}