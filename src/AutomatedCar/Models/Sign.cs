namespace AutomatedCar.Models
{
    using Avalonia.Controls.Shapes;

    public class Sign : StaticGameItems
    {
        public Sign(int x, int y, string filename, RotationMatrix rotmatrix, Polygon bollard) : base(x, y, filename, rotmatrix)
        {
            this.Bollard = bollard;
        }
        
        public Polygon Bollard { get; set; }
    }
}