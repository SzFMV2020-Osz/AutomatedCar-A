namespace AutomatedCar.Models
{
    using Avalonia.Controls.Shapes;

    public class DynamicGameItem : GameItem
    {
        public DynamicGameItem(int x, int y, string filename, bool iscolliding, Polygon npcshape) : base(x, y, filename, iscolliding)
        {
            this.NPCShape = npcshape;
        }
    }
}