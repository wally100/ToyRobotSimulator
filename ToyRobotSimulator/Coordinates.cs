﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToyRobotSimulator
{
    public class Coordinates
    {
        public Coordinates(int? x, int? y)
        {
            this.X = x;
            this.Y = y;
        }

        public int? X { get; set; }
        public int? Y { get; set; }
    }
}
