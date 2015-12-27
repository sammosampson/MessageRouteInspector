using SystemDot.Core;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class RouteKey : Equatable<RouteKey>
    {
        private readonly string machine;
        private readonly int thread;

        public static RouteKey Parse(string machine, int thread)
        {
            return new RouteKey(machine, thread);
        }
        private RouteKey(string machine, int thread)
        {
            this.machine = machine;
            this.thread = thread;
        }

        public override bool Equals(RouteKey other)
        {
            return other.machine == machine && other.thread == thread;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (thread.GetHashCode()*397) ^ (machine ?.GetHashCode() ?? 0);
            }
        }
    }
}