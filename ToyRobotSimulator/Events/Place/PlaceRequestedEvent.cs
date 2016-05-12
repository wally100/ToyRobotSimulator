namespace ToyRobotSimulator.Events.Place
{
    public class PlaceRequestedEvent : BaseEvent
    {
        public bool RaiseEvent(object sender, Report report)
        {
            return base.RaiseEvent(sender, new PlaceRequestedEventResult(report));
        }
    }
}
