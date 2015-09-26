namespace SystemDot.MessageRouteInspector.Server
{
    using System;
    using SystemDot.Domain;

    public class MessageRouteId : MultiSiteId
    {
        public MessageRouteId() : this(Guid.NewGuid().ToString())
        {
        }

        public MessageRouteId(string id) : base(id , "")
        {
        }
    }
}