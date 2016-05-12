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

        public string XDisplay
        {
            get { return X.HasValue ? X.Value.ToString() : "Null"; }
        }

        public string YDisplay
        {
            get { return Y.HasValue ? Y.Value.ToString() : "Null"; }
        }

    }
}
