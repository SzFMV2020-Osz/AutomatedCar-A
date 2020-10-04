using AutomatedCar.Models;
using Xunit;

namespace AutomatedCarTests.Models
{
    using System.Collections.Generic;
    using Avalonia;
    using Avalonia.Controls.Shapes;

    public class SignTests
    {
        [Theory]
        [InlineData(10,10,"tree", 1,0,0,1)]
        public void CreateSignTest(int x, int y, string filename,  double n11, double n12, double n21, double n22)
        {
            RotationMatrix rotmat = new RotationMatrix(n11, n12, n21, n22);
            
            Polygon polygon = new Polygon();
            polygon.Points = new List<Point>();
            polygon.Points.Add(new Point(10,10));
            
            var sign1 = new Sign(x, y, filename, rotmat,polygon);
            
            Assert.NotNull(sign1);
        }
    }
}