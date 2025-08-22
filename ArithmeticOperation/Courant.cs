using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArithmeticOperation
{
    public class Courant
    {
        public double Solde { get; private set; }

        public void Depot(double montant)
        {
            if (!(montant > 0))
                throw new ArgumentOutOfRangeException("montant", "Le montant doit être positif.");

            Solde += montant;
        }

        public void Retrait(double montant)
        {
            if (!(montant > 0))
                throw new ArgumentOutOfRangeException("montant", "Le montant doit être positif.");

            if (Solde - montant < 0)
                throw new InvalidOperationException("Solde insuffisant.");

            Solde -= montant;
        }
    }
}
