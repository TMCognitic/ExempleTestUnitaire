using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperation.Tests
{
    public class Courant_Retrait //: IDisposable
    {
        private readonly Courant _courant;

        public Courant_Retrait()
        {
            //Console.WriteLine("Je fais ceci avant chaque test");
            _courant = new Courant();
            _courant.Depot(100);
        }

        [Theory]
        [InlineData(10, 90)]
        [InlineData(20, 80)]
        [InlineData(33.33, 66.67)]
        [InlineData(100, 0)]
        public void Retrait_Valide(double montant, double attendu)
        {
            _courant.Retrait(montant);

            Assert.Equal(attendu, _courant.Solde, 0.001);
        }

        [Fact]
        public void Depot_ExceptionOnNegativeAmount()
        {
            Exception exception = Record.Exception(() => _courant.Retrait(-100));

            Assert.IsType<ArgumentOutOfRangeException>(exception);
            Assert.Equal("Le montant doit être positif. (Parameter 'montant')", exception.Message);
        }

        [Fact]
        public void Depot_ExceptionSoldeInsuffisant()
        {
            Exception exception = Record.Exception(() => _courant.Retrait(101));

            Assert.IsType<InvalidOperationException>(exception);
            Assert.Equal("Solde insuffisant.", exception.Message);
        }

        //public void Dispose()
        //{
        //    Console.WriteLine("Je fais ceci après chaque test...");
        //}
    }
}
