using Avalonia.Controls.Shapes;
using System.Collections.Generic;

namespace AutomatedCar.Models
{
    public class GameItem : WorldObject
    {
        public GameItem(int x, int y, string filename, bool iscolliding) : base(x, y, filename)
        {
            this.IsColliding = iscolliding;
        }

        public bool IsColliding { get; set; }

        public List<Polygon> Polygon { get; set; }
    }
}