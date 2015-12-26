using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystemDot.Akka.Testing
{
    public class ViewChangeWatcherContext
    {
        private readonly List<ViewChanged> events;
        private readonly TaskCompletionSource<bool> expectedViewChangeOccurred = new TaskCompletionSource<bool>();
        private Predicate<ViewChanged> isExpectedChange;

        public ViewChangeWatcherContext()
        {
            events = new List<ViewChanged>();
            isExpectedChange = changed => false;
        }

        public void AddViewChangedEvent(ViewChanged toAdd)
        {
            events.Add(toAdd);
            NotifyIfChangeIsExpected(toAdd);
        }

        private void NotifyIfChangeIsExpected(ViewChanged toAdd)
        {
            if (isExpectedChange(toAdd))
            {
                expectedViewChangeOccurred.SetResult(true);
            }
        }

        private void ExpectChange(Predicate<ViewChanged> toExpect)
        {
            isExpectedChange = toExpect;
            events.ForEach(NotifyIfChangeIsExpected);
        }

        public void WaitForChange(Predicate<ViewChanged> toExpect)
        {
            ExpectChange(toExpect);
            expectedViewChangeOccurred.Task.Wait(TimeSpan.FromSeconds(5));
        }

        public void WaitForChange<TExpectedView, TExpectedEvent>()
        {
            WaitForChange(vc => vc.View is TExpectedView && vc.Event is TExpectedEvent);
        }
    }
}