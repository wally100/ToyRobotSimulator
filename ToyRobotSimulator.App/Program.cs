using System;
using ToyRobotSimulator.Commands;
using ToyRobotSimulator.Events;
using ToyRobotSimulator.Events.Exceptions;
using ToyRobotSimulator.Events.Reporting;
using ToyRobotSimulator.Utilities;

namespace ToyRobotSimulator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventBus = new EventBus();

            eventBus.Subscribe(new ReportEventHandler((s, r) =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(r.Display);
                Console.ResetColor();
                return true;
            }));

            eventBus.Subscribe(new ExceptionEventHandler((s, ex) =>
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
                return true;
            }));

            var commandBus = new CommandBus();
            var commandParser = new CommandParserService(eventBus);

            var table = new Table(5, 5);

            var toyRobot = new ToyRobot(eventBus, table);
            var simulating = true;
            var helpText = "\nPLACE X,Y,F\nMOVE\nLEFT\nRIGHT\nREPORT";

            Console.WriteLine("Enter EXIT to end simulation, enter HELP for list of commands");

            while (simulating)
            {
                var input = Console.ReadLine().ToUpper();
                switch (input)
                {
                    case "EXIT":
                        simulating = false;
                        break;
                    case "HELP":
                        Console.WriteLine(helpText);
                        break;
                    default:
                        var cmd = commandParser.ParseCommand(input);
                        if (cmd != null)
                            commandBus.ExecuteCommand(cmd);
                         break;                     
                }
            }
        }
    }
}
