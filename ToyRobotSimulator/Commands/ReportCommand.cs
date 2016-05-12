using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Events;
using ToyRobotSimulator.Events.Reporting;

namespace ToyRobotSimulator.Commands
{
    public class ReportCommand : ICommand
    {

        ReportRequestedEvent reportRequestedEvent;

        public ReportCommand(IEventBus eventBus)
        {
            reportRequestedEvent = eventBus.Register<ReportRequestedEvent>();
        }

        public void Execute()
        {
            reportRequestedEvent.RaiseEvent(this);
        }
    }


}
