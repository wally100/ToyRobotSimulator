using System;

namespace ToyRobotSimulator.Events.Exceptions
{
    public class ExceptionEventHandler : IEventHandler<ExceptionEvent>
    {
        private readonly EventResultHandler<Exception> handler;

        public ExceptionEventHandler(EventResultHandler<Exception> handler)
        {
            this.handler = handler;
        }

        public bool EventResultHandler(object sender, object result)
        {
            return this.handler(sender, ((ExceptionEventResult)result).Exception);
        }
    }


  
}
