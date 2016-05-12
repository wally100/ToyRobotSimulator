namespace ToyRobotSimulator.Events.Move
{
    public class MoveRequestedEvent : BaseEvent
    {
        public bool RaiseEvent(object sender)
        {
            return base.RaiseEvent(sender, new MoveRequestedEventResult());
        }
    }
}
