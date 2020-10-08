using AutomatedCar.Models;
using Xunit;

namespace AutomatedCarTests.Models
{
    public class CircleTests
    {
        [Theory]
        [InlineData(10, 10, "circle.png", 7, 153.93804002589986868454, true)]
        [InlineData(200, 400, "circle.png", 42, 5541.76944093239527264344, true)]
        public void CalculateAreaTest(int x, int y, string filename, int radius, double expected, bool iscolliding)
        {
            var circle1 = new Circle(x, y, filename, radius, iscolliding);

            Assert.Equal(expected, circle1.CalculateArea(), 6);
        }
    }
}