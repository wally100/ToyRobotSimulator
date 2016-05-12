namespace ToyRobotSimulator.Events.Right
{
    public class RightRequestedEvent : BaseEvent
    {
        public bool RaiseEvent(object sender)
        {
            return base.RaiseEvent(sender, new RightRequestedEventResult());
        }
    }
}
