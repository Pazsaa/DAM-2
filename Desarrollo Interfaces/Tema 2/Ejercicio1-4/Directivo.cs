using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4
{
    class Directivo : Persona, IPastaGansa
    {
        public double GananciasEmpresa { set; get; }
        public string Departamento;
        public double Beneficios;
        private int personas;
        public int Personas
        {
            set
            {
                if (value < 10) Beneficios = 2;
                if (value > 10 && value < 50) Beneficios = 3.5;
                if (value > 50) Beneficios = 4;

                personas = value;
            }

            get { return personas; }
        }

        public Directivo(string nombre, string apellidos, string dni, int edad, string departamento, int personas, double beneficios)
            : base(nombre, apellidos, dni, edad)
        {
            Init(departamento, personas);
            this.Beneficios = beneficios;
        }

        public Directivo(string nombre, string apellidos, string dni, int edad, string departamento, int personas)
            : base(nombre, apellidos, dni, edad)
        {
            Init(departamento, personas);
        }

        public static Directivo operator --(Directivo d)
        {
            if (d.Beneficios > 0)
                return new Directivo(d.Nombre, d.Apellidos, d.Dni, d.Edad, d.Departamento, d.Personas, d.Beneficios - 1);
            else
                return d;
        }

        private void Init(string departamento, int personas)
        {
            this.Departamento = departamento;
            this.Personas = personas;
        }

        public override string ShowData()
        {
            //Console.WriteLine( base.ShowData() + String.Format("Departamento: {0}\n Personas a cargo: {1}\n Beneficios: {2}", this.Departamento, this.Personas, this.Beneficios));
            return base.ShowData() + String.Format("\nDepartamento: {0}\nPersonas a cargo: {1}\nBeneficios: {2}% \nHacienda: {3}", this.Departamento, this.Personas, this.Beneficios, this.Hacienda());
        }

        public override void InsertData()
        {
            base.InsertData();
            string departamento; int personas = 0;


            Console.WriteLine("Introduce nombre de departamento: ");
            departamento = Console.ReadLine();
            Console.WriteLine("Introduce numero de personas a cargo: ");
            Int32.TryParse(Console.ReadLine(), out personas);
        }

        public override double Hacienda()
        {
            return GanarPasta(GananciasEmpresa) * 0.3;
        }

        public double GanarPasta(double ganancias)
        {
            if(ganancias > 0)
            {
                return ganancias * Beneficios / 100;
            }
            else
            {
                Directivo d = this;
                d--;
                return 0;
            }
        }
    }
}
