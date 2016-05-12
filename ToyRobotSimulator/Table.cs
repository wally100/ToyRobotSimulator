using System;

namespace ToyRobotSimulator
{
    public class Table
    {

        private readonly Coordinates tableCoordinates;
        public Table(int width, int height)
        {
            tableCoordinates = new Coordinates(width, height);
        }

        public bool ValidateCoordinates(Coordinates coordinates)
        {
            var tableWidth = tableCoordinates.X;
            var x = coordinates.X;

            var tableHeight = tableCoordinates.Y;
            var y = coordinates.Y;

            //0, 0 are valid coordinates zero based
            if (!x.HasValue || !y.HasValue || x < 0 || x >= tableWidth || y < 0 || y >= tableHeight)
                throw new InvalidOperationException("Coordinates not on table!");

            return true;

        }

        public Coordinates Move(Coordinates currentPos, DirectionList direction)
        {
            return getRequestedCoordinates(currentPos, direction);
        }

        private Coordinates getRequestedCoordinates(Coordinates currentPos, DirectionList direction)
        {
            var x = 0;
            var y = 0;

            switch (direction)
            {
                case DirectionList.NORTH:
                    y = 1;
                    break;
                case DirectionList.EAST:
                    x = 1;
                    break;
                case DirectionList.SOUTH:
                    y = -1;
                    break;
                case DirectionList.WEST:
                    x = -1;
                    break; 
            }

            x += currentPos.X.GetValueOrDefault();
            y += currentPos.Y.GetValueOrDefault();

            var newCoordinates = new Coordinates(x, y);
            ValidateCoordinates(newCoordinates);
            return newCoordinates;

        }       
    }
}
