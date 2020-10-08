namespace AutomatedCar.Models
{
    using Avalonia.Controls.Shapes;

    public class DynamicGameItem : WorldObject
    {
        public DynamicGameItem(int x, int y, string filename, bool iscolliding, Polygon npcshape)
            : base(x, y, filename)
        {
            this.Polygons.Add(npcshape);
        }
    }
}