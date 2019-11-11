using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4
{
    class EmpleadoEspecial : Empleado, IPastaGansa
    {
        public EmpleadoEspecial(string nombre, string apellidos, string dni, int edad, double Salario, string Telefono)
            : base(nombre, apellidos, dni, edad, Salario, Telefono)
        { 
        }
        public double GananciasEmpresa { get; set; }

        public EmpleadoEspecial() : base() { }
        public double GanarPasta(double ganancias)
        {
            this.GananciasEmpresa = ganancias;
            return ganancias * 0.005;
        }

        public override string ShowData()
        {
            return base.ShowData();
        }

        public override double Hacienda()
        {
            return base.Hacienda() + GanarPasta(GananciasEmpresa) * 0.1;
        }
    }
}
