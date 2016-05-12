using System;
using ToyRobotSimulator.Events;
using ToyRobotSimulator.Events.Move;

namespace ToyRobotSimulator.Commands
{
    public class MoveCommand : ICommand
    {      
        MoveRequestedEvent moveRequestedEvent;

        public MoveCommand(IEventBus eventBus)
        {
            moveRequestedEvent = eventBus.Register<MoveRequestedEvent>();
        }

        public void Execute()
        {
            moveRequestedEvent.RaiseEvent(this);
        }
    }
}
