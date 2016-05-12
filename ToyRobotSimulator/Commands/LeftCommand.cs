using ToyRobotSimulator.Events;
using ToyRobotSimulator.Events.Left;

namespace ToyRobotSimulator.Commands
{
    public class LeftCommand : ICommand
    {
        LeftRequestedEvent leftRequestedEvent;

        public LeftCommand(IEventBus eventBus)
        {
            leftRequestedEvent = eventBus.Register<LeftRequestedEvent>();
        }

        public void Execute()
        {
            leftRequestedEvent.RaiseEvent(this);
        }
    }
}
