namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using SystemDot.Core;

    public class ProcessId : Equatable<ProcessId>
    {
        public string MachineName { get; private set; }
        public int Thread { get; private set; }

        public ProcessId(string machineName, int thread)
        {
            MachineName = machineName;
            Thread = thread;
        }

        public override bool Equals(ProcessId other)
        {
            return other.MachineName == MachineName && other.Thread == Thread;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((MachineName != null ? MachineName.GetHashCode() : 0) * 397) ^ Thread;
            }
        }
    }
}