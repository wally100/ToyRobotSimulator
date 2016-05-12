namespace ToyRobotSimulator.Events.Reporting
{
    public class ReportRequestedEvent : BaseEvent
    {
        public bool RaiseEvent(object sender)
        {
            return base.RaiseEvent(sender, new ReportRequestedEventResult());
        }
    }
}
