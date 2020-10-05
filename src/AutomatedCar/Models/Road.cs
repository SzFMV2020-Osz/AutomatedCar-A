namespace AutomatedCar.Models
{
    using System.Collections.Generic;
    using Avalonia.Controls.Shapes;

    public class Road : StaticGameItems
    {
        public Road(int x, int y, string filename, bool iscolliding,RotationMatrix rotmatrix, List<Polygon>  roadplace) : base(x, y, filename,iscolliding, rotmatrix)
        {
            this.RoadPlace = roadplace;
        }
        
        public List<Polygon> RoadPlace { get; set; }
    }
}