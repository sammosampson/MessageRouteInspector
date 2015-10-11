namespace SystemDot.MessageRouteInspector.Server
{
    public static class Bootstrapper
    {
        public static LimitRoutesToConfiguration LimitRoutesTo(int limit)
        {
            return new LimitRoutesToConfiguration(limit);
        }
    }
}