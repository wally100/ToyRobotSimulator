namespace ToyRobotSimulator.Events.Right
{
    public class RightRequestedEventHandler : IEventHandler<RightRequestedEvent>
    {
        private readonly EventResultHandler<object> handler;

        public RightRequestedEventHandler(EventResultHandler<object> handler)
        {
            this.handler = handler;
        }

        public bool EventResultHandler(object sender, object result)
        {
            return this.handler(sender, result);
        }
    }
}
