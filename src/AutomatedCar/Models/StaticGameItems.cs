namespace AutomatedCar.Models
{
    public class StaticGameItems : WorldObject
    {
        public StaticGameItems(int x, int y, string filename, RotationMatrix rotmatrix)
            : base(x, y, filename)
        {
            this.RotMatrix = rotmatrix;
        }

        public RotationMatrix RotMatrix { get; set; }
    }
}