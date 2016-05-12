namespace ToyRobotSimulator.Events.Place
{
    public class PlaceRequestedEventHandler : IEventHandler<PlaceRequestedEvent>
    {
        private readonly EventResultHandler<Report> handler;

        public PlaceRequestedEventHandler(EventResultHandler<Report> handler)
        {
            this.handler = handler;
        }

        public bool EventResultHandler(object sender, object result)
        {
            return this.handler(sender, ((PlaceRequestedEventResult)result).Value);
        }
    }
}
