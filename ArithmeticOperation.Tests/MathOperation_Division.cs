using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperation.Tests
{
    public class MathOperation_Division
    {
        [Theory]
        [InlineData(5, 2, 2)]
        [InlineData(5, -2, -2)]
        [InlineData(-5, -2, 2)]
        [InlineData(2, 3, 0)]
        public void TestDivision(in int x, in int y, in int result)
        {            
            int division = MathOperation.Division(x, y);

            Assert.Equal(result, division);
        }

        [Fact]
        public void TestDivisionError()
        {
            //Arrange
            int x = 5, y = 0;

            //Act
            Exception e = Record.Exception(() => MathOperation.Division(x, y));

            //Asserts
            Assert.IsType<DivideByZeroException>(e);
            Assert.Equal("Attempted to divide by zero.", e.Message);
        }
    }
}
