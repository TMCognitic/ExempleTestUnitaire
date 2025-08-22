using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperation.Tests
{
    public class Courant_Depot
    {
        private readonly Courant _courant;

        public Courant_Depot()
        {
            _courant = new Courant();
        }

        [Theory]
        //Arrange
        [InlineData(50, 50)]
        [InlineData(150, 150)]
        public void Depot_ValideTest(double montant, double expected)
        {
            //Act
            _courant.Depot(montant);

            //Assert
            Assert.Equal(expected, montant);
        }

        [Fact]
        public void Depot_MultipleDepotTest()
        {
            //Act
            _courant.Depot(50.2);
            _courant.Depot(25.1);

            //Asserts
            Assert.Equal(75.3, _courant.Solde, 0.001); 
        }

        [Fact]
        public void Depot_ExceptionOnNegativeAmount()
        {
            Exception exception = Record.Exception(() => _courant.Depot(-100));

            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal("Le montant doit être positif. (Parameter 'montant')", exception.Message);
        }
    }
}
