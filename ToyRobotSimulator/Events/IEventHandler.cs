using System;

namespace ToyRobotSimulator.Events
{
    public interface IEventHandler<T> where T : IEvent
    {
        bool EventResultHandler(object sender, object result);
    }
}
