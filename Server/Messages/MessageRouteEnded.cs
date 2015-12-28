namespace SystemDot.MessageRouteInspector.Server.Messages
{
    public class MessageRouteEnded
    {
        public string MachineName { get; private set; }

        public int Thread { get; private set; }

        public MessageRouteEnded(string machineName, int thread)
        {
            MachineName = machineName;
            Thread = thread;
        }
    }
}