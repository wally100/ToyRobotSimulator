using System;

namespace ToyRobotSimulator.Events.Exceptions
{
    public class ExceptionEventResult : IEventResult<ExceptionEvent>
    {
        private readonly Exception exception;

        public ExceptionEventResult(Exception exception)
        {
            this.exception = exception;
        }

        public Exception Exception
        {
            get { return exception; }
        }
    } 
}
