namespace AutomatedCar.Models
{
    using Avalonia.Controls.Shapes;

    public class Tree : StaticGameItems
    {
        public Tree(int x, int y, string filename, bool iscolliding,RotationMatrix rotmatrix, Polygon wood) : base(x, y, filename,iscolliding, rotmatrix)
        {
            this.Wood = wood;
            this.ZIndex = 1;
        }

        public Polygon Wood { get; set; }
    }
}