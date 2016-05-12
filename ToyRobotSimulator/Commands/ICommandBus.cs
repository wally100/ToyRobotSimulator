using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Commands
{
    public interface ICommandBus
    {
        void ExecuteCommand<T>(T command) where T : ICommand;
    }
}
