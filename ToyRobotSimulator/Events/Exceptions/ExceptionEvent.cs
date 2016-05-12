using System;

namespace ToyRobotSimulator.Events.Exceptions
{
    public class ExceptionEvent : BaseEvent
    {
        public bool RaiseEvent(object sender, Exception exception)
        {
            return base.RaiseEvent(sender, new ExceptionEventResult(exception));
        }
    }

   
}
