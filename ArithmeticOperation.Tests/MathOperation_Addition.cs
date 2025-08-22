using System.Diagnostics;
using System.Threading.Channels;

namespace ArithmeticOperation.Tests
{
    public class MathOperation_Addition
    {
        [Fact]
        public void TestAddition_Simple1()
        {
            //Arrange (Préparation du Test)            
            int x = 5, y = 3;

            //Act (Appel de la fonctionnalité)
            int result = MathOperation.Addition(x, y);

            //Assert (Vérification des résultats)
            Assert.Equal(8, result);
        }

        [Theory]
        //Arrange (Préparation du Test)            
        [InlineData(5, 3, 8)]
        [InlineData(-5, 3, -2)]
        [InlineData(5, -3, 2)]
        [InlineData(4096, 24, 4120)]
        public void TestAddition_Simple2(in int x, in int y, in int result)
        {
            //Act (Appel de la fonctionnalité)
            int local_result = MathOperation.Addition(x, y);

            //Assert (Vérification des résultats)
            Assert.Equal(result, local_result);
        }

        [Theory]
        //Arrange
        [InlineData(int.MaxValue, 1)]
        [InlineData(int.MinValue, -1)]
        public void TestAddition_LimitOverflowUnderFlow(int x, int y)
        {
            //Act
            Exception e = Record.Exception(() => MathOperation.Addition(x, y));

            //Assert
            Assert.IsType<OverflowException>(e);
            Assert.Equal("Arithmetic operation resulted in an overflow.", e.Message);
        }
    }
}