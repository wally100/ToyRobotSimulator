namespace ToyRobotSimulator.Commands
{
    public interface ICommandBus
    {
        void ExecuteCommand<T>(T command) where T : ICommand;
    }
}
