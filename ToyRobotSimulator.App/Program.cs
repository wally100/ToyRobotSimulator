using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Commands;
using ToyRobotSimulator.Events;

namespace ToyRobotSimulator.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter table size");
            var tableSize = Console.ReadLine();

            var eventBus = new EventBus();
            var commandBus = new CommandBus();
        }
    }
}
