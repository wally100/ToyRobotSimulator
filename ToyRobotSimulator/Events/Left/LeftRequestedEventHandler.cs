namespace ToyRobotSimulator.Events.Left
{
    public class LeftRequestedEventHandler : IEventHandler<LeftRequestedEvent>
    {
        private readonly EventResultHandler<object> handler;

        public LeftRequestedEventHandler(EventResultHandler<object> handler)
        {
            this.handler = handler;
        }

        public bool EventResultHandler(object sender, object result)
        {
            return this.handler(sender, result);
        }
    }
}
