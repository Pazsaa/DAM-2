using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio1_4
{
    public abstract class Persona
    {
        public Persona():this("", "", "", 0) { }
        public Persona(string nombre, string apellidos, string dni, int edad)
        {
            Init(nombre, apellidos, dni, edad);
        }

        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        private string dni;
        public string Dni
        {
            get
            {
                return this.dni + LetraDNI(this.dni);
            }
            set
            {
                this.dni = value;
            }
        }
        private int edad;
        public int Edad { get { return edad; } set { if (value < 0) edad = 0; else edad = value; } }

        private void Init(string nombre, string apellidos, string dni, int edad)
        {
            this.Nombre = nombre; this.Apellidos = apellidos;
            this.Dni = dni; this.Edad = edad;
        }

        public virtual string ShowData()
        {
            return String.Format("Nombre: {0} \nApellidos: {1}\n" +
                                 "Dni: {2} \nEdad: {3}", this.Nombre, this.Apellidos, this.Dni, this.Edad) ;
        }

        public virtual void InsertData()
        {
            string nombre; string apellidos; string dni; int edad = 0;

            Console.WriteLine("Introduce nombre: ");
            nombre = Console.ReadLine();
            Console.WriteLine("Introduce apellidos: ");
            apellidos = Console.ReadLine();
            Console.WriteLine("Introduce dni: ");
            dni = Console.ReadLine();
            Console.WriteLine("Introduce edad: ");
            bool parsedAge = Int32.TryParse(Console.ReadLine(), out edad);

            Init(nombre, apellidos, dni, edad);
        }

        public char LetraDNI(string dni)
        {
            char[] letrasDni = { 'T', 'R', 'W', 'A', 'G', 'M', 'Y', 'F', 'P', 'D', 'X', 'B', 'N', 'J', 'Z', 'S', 'Q', 'V', 'H', 'L', 'C', 'K', 'E' };
            int num;
            bool numDni = Int32.TryParse(dni, out num);
            if (numDni)
                return letrasDni[num % 23];
            else
                return '?';
        }

        public abstract double Hacienda();
    }
}
