using System;

namespace ToyRobotSimulator.Events.Reporting
{
    public class ReportEventHandler : IEventHandler<ReportEvent>
    {
        private readonly EventResultHandler<Report> handler;

        public ReportEventHandler(EventResultHandler<Report> handler)
        {
            this.handler = handler;
        }

        public bool EventResultHandler(object sender, object result)
        {
            return this.handler(sender, ((ReportEventResult)result).Value);
        }
    }


  
}
