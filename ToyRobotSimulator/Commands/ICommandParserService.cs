namespace ToyRobotSimulator.Commands
{
    public interface ICommandParserService
    {
        ICommand ParseCommand(string command);      
    }
}
