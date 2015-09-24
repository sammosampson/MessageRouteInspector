namespace SystemDot.MessageRouteInspector.Server.Queries
{
    public class Route
    {
        public int Id { get; set; }
        public Message Root { get; set; }
        public Message[] Messages { get; set; }
    }
}