using Avalonia.Controls.Shapes;
using System.Collections.Generic;

namespace AutomatedCar.Models
{
    public class GameItem : WorldObject
    {
        public GameItem(int x, int y, string filename, bool iscolliding)
            : base(x, y, filename)
        {
            this.IsColliding = iscolliding;
            this.Polygons = new List<Polygon>();
        }

        public bool IsColliding { get; set; }

        public List<Polygon> Polygons { get; set; }
    }
}