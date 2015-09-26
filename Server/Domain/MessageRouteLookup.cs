namespace SystemDot.MessageRouteInspector.Server.Domain
{
    using System.Collections.Generic;

    public class MessageRouteLookup
    {
        readonly Dictionary<ProcessId, MessageRouteId> currentRoutes;

        public MessageRouteLookup()
        {
            currentRoutes = new Dictionary<ProcessId, MessageRouteId>();
        }

        public bool MessageRouteExists(string machine, int thread)
        {
            return currentRoutes.ContainsKey(new ProcessId(machine, thread));
        }

        public MessageRouteId LookupMessageRouteId(string machine, int thread)
        {            
            return currentRoutes[new ProcessId(machine, thread)];
        }

        public void OpenRoute(string machine, int thread, MessageRouteId id)
        {
            currentRoutes.Add(new ProcessId(machine, thread), id);
        }

        public void CloseRoute(string machine, int thread)
        {
            currentRoutes.Remove(new ProcessId(machine, thread));
        }
    }
}