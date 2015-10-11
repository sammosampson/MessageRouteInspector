namespace SystemDot.MessageRouteInspector.Server.Messages
{
    using System;

    public class MessageBranchCompleted
    {
        public Guid RouteId { get; set; }
        public Guid MessageId { get; set; }
        public string MessageName { get; set; }
        public MessageType MessageType { get; set; }
        public int CloseBranchCount { get; set; }
    }
}