namespace ToyRobotSimulator.Events
{
    public interface IEventBus
    {
        T Register<T>() where T : IEvent;
        void Subscribe<T>(IEventHandler<T> handler) where T : IEvent;
        void UnSubscribe<T>(IEventHandler<T> handler) where T : IEvent;
    }
}
