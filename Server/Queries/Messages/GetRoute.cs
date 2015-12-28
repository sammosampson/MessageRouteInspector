namespace SystemDot.MessageRouteInspector.Server.Queries.Messages
{
    public class GetRoute
    {
        public string RouteId { get; }

        public GetRoute(string id)
        {
            RouteId = id;
        }
    }
}