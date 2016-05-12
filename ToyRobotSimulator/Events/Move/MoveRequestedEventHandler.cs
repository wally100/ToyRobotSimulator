namespace ToyRobotSimulator.Events.Move
{
    public class MoveRequestedEventHandler : IEventHandler<MoveRequestedEvent>
    {
        private readonly EventResultHandler<object> handler;

        public MoveRequestedEventHandler(EventResultHandler<object> handler)
        {
            this.handler = handler;
        }

        public bool EventResultHandler(object sender, object result)
        {
            return this.handler(sender, result);
        }
    }
}
