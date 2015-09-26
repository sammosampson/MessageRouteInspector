namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class MessageBranchCompleted
    {
        public string MessageName { get; set; }
        public int CloseBranchCount { get; set; }
    }
}