namespace AutomatedCar.Models
{
    using Avalonia.Controls.Shapes;

    public class Tree : StaticGameItems
    {
        public Tree(int x, int y, string filename, RotationMatrix rotmatrix, Polygon wood) : base(x, y, filename, rotmatrix)
        {
            this.Wood = wood;
            this.ZIndex = 1;
        }

        public Polygon Wood { get; set; }
    }
}