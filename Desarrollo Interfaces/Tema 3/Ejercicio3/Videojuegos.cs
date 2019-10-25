using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Videojuegos
    {
        public List<Videojuego> Biblioteca = new List<Videojuego>();

        public Videojuegos()
        {
            Biblioteca.Add(new Videojuego("Destroy All Humans!", 2007, Videojuego.Estilo.Videoaventura));
            Biblioteca.Add(new Videojuego("Kingdom Hearts 2", 2005, Videojuego.Estilo.Videoaventura));
            Biblioteca.Add(new Videojuego("Nier Automata", 2017, Videojuego.Estilo.Videoaventura));
        }

        // Devuelve la posición en la que hay que insertar un elemento en base al año. Mas viejos antes.
        public int Posicion(int year)
        {
            foreach (Videojuego juego in Biblioteca)
            {
                if (juego.Year > year)
                    return Biblioteca.IndexOf(juego);
            }

            return -1; // Algo fue mal.
        }

        // Borra elementos entre indice minimo y máximo.
        public bool Eliminar(int max, int min = 0)
        {
            if(min < 0 || max > Biblioteca.Count - 1 || max < min)
                return false;

            for(int i = max; i >= min; i--)
            {
                Biblioteca.RemoveAt(i);
            }
            return true;
        }

        // Busca y devuelve otra coleccion compuesta de videojuegos que concuerden con el estilo dado.
        public List<Videojuego> Busqueda(Videojuego.Estilo estilo)
        {
            List<Videojuego> resultado = new List<Videojuego>();
            return Biblioteca.FindAll(r => r.Tipo == estilo);
        }

    }
}
