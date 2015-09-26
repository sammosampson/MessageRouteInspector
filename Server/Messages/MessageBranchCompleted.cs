namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class MessageBranchCompleted
    {
        public string RouteId { get; set; }
        public string MessageName { get; set; }
        public int CloseBranchCount { get; set; }
    }
}