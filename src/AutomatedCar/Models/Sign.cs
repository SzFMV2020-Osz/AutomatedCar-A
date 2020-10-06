namespace AutomatedCar.Models
{
    using Avalonia.Controls.Shapes;

    public class Sign : StaticGameItems
    {
        public Sign(int x, int y, string filename, bool iscolliding, RotationMatrix rotmatrix, Polygon bollard) : base(x, y, filename,iscolliding, rotmatrix)
        {
            this.Bollard = bollard;
        }
    }
}