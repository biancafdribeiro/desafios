using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Desafio3
{
    public interface IConta
    {
        List<int> Notas { get; } //apenas leitura
        bool Saca(double valor);
    }
}
