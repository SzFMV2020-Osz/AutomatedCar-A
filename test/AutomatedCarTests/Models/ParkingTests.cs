namespace AutomatedCarTests.Models
{
    using System.Collections.Generic;
    using AutomatedCar.Models;
    using Avalonia;
    using Avalonia.Controls.Shapes;
    using Xunit;

    public class ParkingTests
    {
        [Theory]
        [InlineData(10,10,"parking", 1,0,0,1)]
        public void CreateParkingTest(int x, int y, string filename,  double n11, double n12, double n21, double n22)
        {
            RotationMatrix rotmat = new RotationMatrix(n11, n12, n21, n22);
            
            Polygon polygon1 = new Polygon();
            polygon1.Points = new List<Point>();
            polygon1.Points.Add(new Point(10,10));
            Polygon polygon2 = new Polygon();
            polygon2.Points = new List<Point>();
            polygon2.Points.Add(new Point(20,20));
            
            List<Polygon> poligons = new List<Polygon>();
            poligons.Add(polygon1);
            poligons.Add(polygon2);
            
            var parking1 = new Parking(x, y, filename, rotmat,poligons);
            
            Assert.NotNull(parking1);
        }
    }
}