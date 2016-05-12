using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Events.Reporting
{
   
    public class ReportRequestedEventHandler : IEventHandler<ReportRequestedEvent>
    {
        private readonly EventResultHandler<object> handler;

        public ReportRequestedEventHandler(EventResultHandler<object> handler)
        {
            this.handler = handler;
        }

        public bool EventResultHandler(object sender, object result)
        {
            return this.handler(sender, result);
        }
    }
}
