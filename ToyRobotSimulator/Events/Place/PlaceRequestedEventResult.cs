namespace ToyRobotSimulator.Events.Place
{
    public class PlaceRequestedEventResult : IEventResult<PlaceRequestedEvent>
    {
        Report report = null;

        public PlaceRequestedEventResult(Report report)
        {
            this.report = report;
        }

        public Report Value
        {
            get { return report; }
        }
    }
}
