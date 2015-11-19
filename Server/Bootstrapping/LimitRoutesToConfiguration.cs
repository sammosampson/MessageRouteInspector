namespace SystemDot.MessageRouteInspector.Server.Bootstrapping
{
    using SystemDot.Bootstrapping;
    using SystemDot.MessageRouteInspector.Server.Domain.Limits;

    public class LimitRoutesToConfiguration : BootstrapBuilderConfiguration
    {
        readonly int routeLimit;

        public LimitRoutesToConfiguration(BootstrapBuilderConfiguration @from)
            : base(@from)
        {
        }

        public BootstrapBuilderConfiguration WithRouteLimitOf(int limit)
        {
            return RegisterBuildAction(c => c.RegisterInstance(() => new RouteLimit(limit)));
        }
    }
}