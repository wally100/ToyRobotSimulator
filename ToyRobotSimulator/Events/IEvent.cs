using System;

namespace ToyRobotSimulator.Events
{
    public interface IEvent
    {
        void Subscribe<T>(IEventHandler<T> handler) where T : IEvent;
        void UnSubscribe<T>(IEventHandler<T> handler) where T : IEvent;
        bool RaiseEvent<T>(object sender, IEventResult<T> result) where T : IEvent;
    }
}
