using ToyRobotSimulator.Events;
using ToyRobotSimulator.Events.Right;

namespace ToyRobotSimulator.Commands
{
    public class RightCommand : ICommand
    {
        RightRequestedEvent rightRequestedEvent;

        public RightCommand(IEventBus eventBus)
        {
            rightRequestedEvent = eventBus.Register<RightRequestedEvent>();
        }

        public void Execute()
        {
            rightRequestedEvent.RaiseEvent(this);
        }
    }
}
