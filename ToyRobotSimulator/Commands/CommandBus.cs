using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToyRobotSimulator.Commands;

namespace ToyRobotSimulator.Commands
{
    public class CommandBus : ICommandBus
    {

        private readonly object locker = new object();

        public void ExecuteCommand<T>(T command) where T : ICommand
        {
            lock (locker)
            {
                try
                {
                    command.Execute();
                }
                catch (InvalidOperationException ex)
                {
                    //todo raise exception event               
                }                
            }
        }

       
    }
}
