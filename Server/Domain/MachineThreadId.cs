using SystemDot.Core;

namespace SystemDot.MessageRouteInspector.Server.Domain
{
    public class MachineThreadId : Equatable<MachineThreadId>
    {
        public string MachineName { get; private set; }
        public int Thread { get; private set; }

        public static MachineThreadId Parse(string machine, int thread)
        {
            return new MachineThreadId(machine, thread);
        }
        private MachineThreadId(string machine, int thread)
        {
            MachineName = machine;
            Thread = thread;
        }

        public override bool Equals(MachineThreadId other)
        {
            return other.MachineName == MachineName && other.Thread == Thread;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Thread.GetHashCode()*397) ^ (MachineName.GetHashCode());
            }
        }
    }
}