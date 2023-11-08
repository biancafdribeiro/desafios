using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio3
{
    public class ContaBancaria : IConta
    {
        private double saldo;

        public ContaBancaria(double saldoInicial)
        {
            saldo = saldoInicial;
        }

        public List<int> Notas { get; } = new List<int> { 100, 50, 20, 10, 5, 2 };

        public bool Saca(double valor)
        {
            if (saldo >= valor)
            {
                saldo -= valor;
                return true;
            }
            return false;
        }
    }

}

