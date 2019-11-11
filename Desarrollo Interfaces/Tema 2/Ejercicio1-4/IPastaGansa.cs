using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4
{
    interface IPastaGansa
    {
        double GananciasEmpresa { get; set; }
        double GanarPasta(double ganancias);
    }
}
