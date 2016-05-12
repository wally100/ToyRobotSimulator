using System;

namespace ToyRobotSimulator.Events.Reporting
{
    public class ReportEvent : BaseEvent
    {
        public bool RaiseEvent(object sender, Report report)
        {
            return base.RaiseEvent(sender, new ReportEventResult(report));
        }
    }

   
}
