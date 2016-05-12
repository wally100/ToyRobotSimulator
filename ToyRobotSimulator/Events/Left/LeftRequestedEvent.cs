namespace ToyRobotSimulator.Events.Left
{
    public class LeftRequestedEvent : BaseEvent
    {
        public bool RaiseEvent(object sender)
        {
            return base.RaiseEvent(sender, new LeftRequestedEventResult());
        }
    }
}
