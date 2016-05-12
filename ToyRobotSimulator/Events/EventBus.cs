using System;
using System.Collections.Generic;
using System.Linq;

namespace ToyRobotSimulator.Events
{
    public class EventBus : IEventBus
    {
        public List<IEvent> events = new List<IEvent>();

        public T Register<T>() where T : IEvent
        {
            return getEvent<T>();
        }

        private T getEvent<T>() where T : IEvent
        {
            T ev;
            lock (events)
            {

                var ievent = events.FirstOrDefault(e => e.GetType() == typeof(T));

                if (ievent == null)
                {
                    ievent = Activator.CreateInstance<T>();
                    events.Add(ievent);
                }

                ev = (T)ievent;

            }

            return ev;

        }

        public void Subscribe<T>(IEventHandler<T> handler) where T : IEvent
        {
            var e = getEvent<T>();
            e.Subscribe(handler);

        }

        public void UnSubscribe<T>(IEventHandler<T> handler) where T : IEvent
        {
            var e = getEvent<T>();
            e.UnSubscribe(handler);
        }

    }

}
