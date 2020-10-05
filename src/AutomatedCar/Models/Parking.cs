namespace AutomatedCar.Models
{
    using System.Collections.Generic;
    using Avalonia.Controls.Shapes;

    public class Parking : StaticGameItems
    {
        public Parking(int x, int y, string filename, bool iscolliding,RotationMatrix rotmatrix, List<Polygon> parkingplace) : base(x, y, filename,iscolliding, rotmatrix)
        {
            this.ParkingPlace = parkingplace;
        }
        
        public List<Polygon> ParkingPlace { get; set; }
    }
}