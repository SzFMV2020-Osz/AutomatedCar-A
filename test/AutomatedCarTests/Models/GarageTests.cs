using AutomatedCar.Models;
using Xunit;

namespace AutomatedCarTests.Models
{
    using System.Collections.Generic;
    using Avalonia;
    using Avalonia.Controls.Shapes;

    public class GarageTests
    {
        [Theory]
        [InlineData(10,10,"garage",false, 1,0,0,1)]
        public void CreateGarageTest(int x, int y, string filename, bool iscolliding, double n11, double n12, double n21, double n22)
        {
            RotationMatrix rotmat = new RotationMatrix(n11, n12, n21, n22);
            
            Polygon polygon = new Polygon();
            polygon.Points = new List<Point>();
            polygon.Points.Add(new Point(10,10));
            
            var garage1 = new Garage(x, y, filename,iscolliding, rotmat,polygon);
            
            Assert.NotNull(garage1);
        }
    }
}