using System;
using System.Collections.Generic;

namespace ToyRobotSimulator.Events
{
    public abstract class BaseEvent : IEvent
    {
        
        public event EventResultHandler<object> OnChange;

        public void Subscribe<T>(IEventHandler<T> handler) where T : IEvent
        {
            OnChange += handler.EventResultHandler;
        }

        public void UnSubscribe<T>(IEventHandler<T> handler) where T : IEvent
        {
            OnChange -= handler.EventResultHandler;
        }

        public bool RaiseEvent<T>(object sender, IEventResult<T> result) where T : IEvent
        {
            var eventRaised = false;
            var onChange = OnChange;
            if (onChange != null)
            {
                var invocationList = OnChange.GetInvocationList();
                foreach (EventResultHandler<object> del in invocationList)
                {
                    if (del.Invoke(sender, result))
                        eventRaised = true;
                }
            }

            return eventRaised;
        }

    }
}
