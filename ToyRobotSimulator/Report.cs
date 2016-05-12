using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class Report
    {
        private readonly Coordinates coordinates;
        private readonly DirectionList direction;

        public Report(Coordinates coordinates, DirectionList direction)
        {
            this.coordinates = coordinates;
            this.direction = direction;
        }

        public Coordinates Coordinates
        {
            get
            {
                return coordinates;
            }
        }

        public DirectionList Direction
        {
            get
            {
                return direction;
            }
        }

    } 
}
