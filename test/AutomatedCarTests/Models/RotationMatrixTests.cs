using AutomatedCar.Models;
using Xunit;

namespace AutomatedCarTests.Models
{
    public class RotationMatrixTests
    {
        [Theory]
        [InlineData(1,0,0,1)]
        public void CreateRotationMatrix(double n11, double n12, double n21, double n22)
        {
            var rotmatrix1 = new RotationMatrix(n11, n12, n21, n22);
            
            Assert.NotNull(rotmatrix1);
        }
    }
}