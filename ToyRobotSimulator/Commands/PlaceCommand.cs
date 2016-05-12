using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Events;
using ToyRobotSimulator.Events.Place;

namespace ToyRobotSimulator.Commands
{
    public class PlaceCommand : ICommand
    {
        private readonly PlaceRequestedEvent placeRequestedEvent;
        private readonly Report report;

        public PlaceCommand(IEventBus eventBus, Report report)
        {
            this.report = report;
            placeRequestedEvent = eventBus.Register<PlaceRequestedEvent>();
        }

        public void Execute()
        {
            placeRequestedEvent.RaiseEvent(this, report);
        }
    
    }
}
