namespace SystemDot.MessageRouteInspector.Server.Queries.Messages
{
    public class Message
    {
        public string Id { get; private set; }

        public string Name { get; private set; }

        public int CloseBranchCount { get; private set; }

        public int Type { get; private set; }

        public static Message Empty
        {
            get { return new Message("0", "No route", 0, MessageType.Command); }
        }

        public Message(string id, string name, int closeBranchCount, int type)
        {
            Id = id;
            Name = name;
            CloseBranchCount = closeBranchCount;
            Type = type;
        }
    }
}