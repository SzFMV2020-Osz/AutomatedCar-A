namespace AutomatedCar.Models
{
    public class StaticGameItems : GameItem
    {

        public StaticGameItems(int x, int y, string filename, bool iscolliding, RotationMatrix rotmatrix) : base(x, y, filename, iscolliding)
        {
            this.RotMatrix = rotmatrix;
        }

        public RotationMatrix RotMatrix { get; set; }
    }
}