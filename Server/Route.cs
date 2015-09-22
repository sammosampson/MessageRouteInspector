namespace SystemDot.MessageRouteInspector.Server
{
    public class Route
    {
        public int Id { get; set; }
        public Message Root { get; set; }
        public Message[] Messages { get; set; }
    }
}