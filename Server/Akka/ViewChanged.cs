using System;

namespace SystemDot.Akka
{
    public class ViewChanged
    {
        public ViewActor View { get; set; }
        public object Event { get; set; }

        public ViewChanged(ViewActor view, object @event)
        {
            View = view;
            Event = @event;
        }
    }
}