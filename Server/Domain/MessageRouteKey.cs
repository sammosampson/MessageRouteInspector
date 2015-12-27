using SystemDot.Core;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class MessageRouteKey : Equatable<MessageRouteKey>
    {
        private readonly string machine;
        private readonly int thread;

        public static MessageRouteKey Parse(string machine, int thread)
        {
            return new MessageRouteKey(machine, thread);
        }
        private MessageRouteKey(string machine, int thread)
        {
            this.machine = machine;
            this.thread = thread;
        }

        public override bool Equals(MessageRouteKey other)
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