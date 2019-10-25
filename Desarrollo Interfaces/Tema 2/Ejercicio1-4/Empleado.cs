using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4
{
    class Empleado : Persona
    {
        public Empleado()
            : this("", "", "", 0, 0, "")
        { }

        public Empleado(string nombre, string apellidos, string dni, int edad, double Salario, string Telefono)
            : base(nombre, apellidos, dni, edad)
        {
            this.Salario = Salario;
            this.Telefono = Telefono;
        }
        private double salario;
        public double Salario
        {
            set
            {
                if (value < 600) irpf = 7;
                if (value > 600 && value < 3000) irpf = 15;
                if (value > 3000) irpf = 20;

                salario = value;
            }
            get { return salario; }
        }

        private int irpf;
        private string telefono;
        public string Telefono
        {
            set { telefono = value; }
            get { return "+34" + telefono; }
        }

        override public string ShowData()
        {
            return base.ShowData() + String.Format("\nTelefono: {0}\nSalario: {1}\nIRPF: {2} \nHacienda: {3}", this.Telefono, this.Salario, this.irpf, this.Hacienda());
        }

        public string ShowData(int index)
        {
            switch (index)
            {
                case 0: return this.Nombre;
                case 1: return this.Apellidos;
                case 2: return this.Dni;
                case 3: return this.Edad.ToString();
                case 4: return this.Telefono.ToString();
                case 5: return this.Salario.ToString();
                case 6: return this.irpf.ToString();
                default: return "?";
            }
        }

        public override double Hacienda()
        {
            return this.irpf * this.Salario / 100;
        }
    }
}
