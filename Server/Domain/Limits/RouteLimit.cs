namespace SystemDot.MessageRouteInspector.Server.Domain.Limits
{
    internal class RouteLimit
    {
        public static implicit operator int(RouteLimit from)
        {
            return from.value;
        }
        
        readonly int value;

        public RouteLimit(int value)
        {
            this.value = value;
        }
    }
}