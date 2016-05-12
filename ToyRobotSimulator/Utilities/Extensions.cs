using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator.Utilities
{
    public static class Extensions
    {
        public static int ToInt32(string val)
        {
            var output = 0;
            int.TryParse(val, out output);
            return output;
        }
    }
}
