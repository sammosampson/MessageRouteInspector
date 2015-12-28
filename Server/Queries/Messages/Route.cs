using System;

namespace SystemDot.MessageRouteInspector.Server.Queries.Messages
{
    public class Route
    {
        public static Route Empty
        {
            get
            {
                return new Route("0", Message.Empty, new[] {Message.Empty}, DateTime.Now.ToJavaString(), string.Empty);
            }
        }

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