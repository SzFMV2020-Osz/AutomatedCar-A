namespace AutomatedCar.Models
{
    using Avalonia.Controls.Shapes;

    public class Garage : StaticGameItems
    {
        public Garage(int x, int y, string filename, RotationMatrix rotmatrix, Polygon garageplace) : base(x, y, filename, rotmatrix)
        {
            this.GaragePlace = garageplace;
        }

        public Polygon GaragePlace { get; set; }
    }
}