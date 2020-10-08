namespace AutomatedCar.Models
{
    using Avalonia.Controls.Shapes;

    public class Garage : StaticGameItems
    {
        public Garage(int x, int y, string filename, bool iscolliding, RotationMatrix rotmatrix, Polygon garageplace)
            : base(x, y, filename, iscolliding, rotmatrix)
        {
            this.Polygons.Add(garageplace);
            this.IsColliding = iscolliding;
        }
    }
}