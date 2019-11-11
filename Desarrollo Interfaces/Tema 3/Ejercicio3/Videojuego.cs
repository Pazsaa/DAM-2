using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    struct Videojuego
    {
        public Videojuego(string titulo, int year, Estilo tipo)
        {
            this.Titulo = titulo;
            this.Year = year;
            this.Tipo = tipo;
        }

        public string Titulo;
        public int Year;
        public Estilo Tipo;
        public enum Estilo
        {
            Arcade,
            Videoaventura,
            Shootemup,
            Estrategia,
            Deportivo
        }
    }
}
