using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Events;
using ToyRobotSimulator.Events.Exceptions;
using ToyRobotSimulator.Utilities;

namespace ToyRobotSimulator.Commands
{
    public class CommandParserService : ICommandParserService
    {
        private IEventBus eventBus;
        private ExceptionEvent exceptionEvent;
        public CommandParserService(IEventBus eventBus)
        {
            this.eventBus = eventBus;
            exceptionEvent = eventBus.Register<ExceptionEvent>();
        }

        public ICommand ParseCommand(string command)
        {

            ICommand cmd = null;

            try
            {
                var split = command.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var ct = split[0].ToUpper();

                switch (ct)
                {
                    case "PLACE":
                        int? x = split.Length > 1 ? split[1].RemoveNonNumericCharacters().ToInt32() : null;
                        int? y = split.Length > 2 ? split[2].RemoveNonNumericCharacters().ToInt32() : null;
                        var direction = (DirectionList)Enum.Parse(typeof(DirectionList), split.Length > 3 ? split[3] : null, true);
                        var place = new Report(new Coordinates(x, y), direction);
                        cmd = new PlaceCommand(eventBus, place);
                        break;
                    case "MOVE":
                        cmd = new MoveCommand(eventBus);
                        break;
                    case "LEFT":
                        cmd = new LeftCommand(eventBus);
                        break;
                    case "RIGHT":
                        cmd = new RightCommand(eventBus);
                        break;
                    case "REPORT":
                        cmd = new ReportCommand(eventBus);
                        break;
                    default:
                        throw new InvalidOperationException("Command not recognised");
                }

            }
            catch(Exception ex)
            {
                if (!exceptionEvent.RaiseEvent(this, new InvalidOperationException("Invalid Command!", ex)))
                    throw;

            }
                  
            return cmd;
        }

      
    }
}
