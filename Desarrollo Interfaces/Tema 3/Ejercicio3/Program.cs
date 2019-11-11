using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3
{
    class Program
    {
        public static void InsertarJuego(Videojuegos v)
        { 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Nombre del juego: ");
            Console.ResetColor();
            string nombre = Console.ReadLine();
            Console.Clear();

            bool parsed;
            int year;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Fecha de lanzamiento: ");
            Console.ResetColor();
            do
            {
                parsed = Int32.TryParse(Console.ReadLine(), out year);
                if (!parsed || year < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Porfavor, introduzca un año válido:");
                    Console.ResetColor();
                }
            } while (!parsed || year < 0);

            Console.Clear();
            int tempCategoria;
            Videojuego.Estilo categoria;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Categoría: (0 Arcade, 1 VideoAventura, 2 Shootemup, 3 Estrategia, 4 Deportivo)");
            Console.ResetColor();
            do
            {
                parsed = Int32.TryParse(Console.ReadLine(), out tempCategoria);
                categoria = (Videojuego.Estilo)tempCategoria;
                if (!parsed || (tempCategoria < 0 || tempCategoria > 4))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Porfavor, introduzca una categoría válida: (0 Arcade, 1 VideoAventura, 2 Shootemup, 3 Estrategia, 4 Deportivo)");
                    Console.ResetColor();
                }
            } while (!parsed || (tempCategoria < 0 || tempCategoria > 4));

            v.Biblioteca.Add(new Videojuego(nombre, year, categoria));
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Juego añadido a la biblioteca correctamente: {0} {1} {2}", nombre, year, categoria);
        }

        public static void EliminarJuegos(Videojuegos v)
        {
            MostrarBiblioteca(v.Biblioteca);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Posición inicial desde la que borrar (índice):");
            int first;
            bool parsed = true;
            do
            {
                Console.ResetColor();
                parsed = Int32.TryParse(Console.ReadLine(), out first);
                if (!parsed || (first < 0 || first > v.Biblioteca.Count() - 1))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El índice que has introducido no es válido, prueba de nuevo: ");
                }
            } while (!parsed || (first < 0 || first > v.Biblioteca.Count() - 1));

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Posición final hasta la que borrar (índice):");
            int second;
            do
            {
                Console.ResetColor();
                parsed = Int32.TryParse(Console.ReadLine(), out second);
                if (!parsed || (first < 0 || first > v.Biblioteca.Count() - 1 || second < first))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El índice que has introducido no es válido, prueba de nuevo: ");
                }
            } while (!parsed || (first < 0 || first > v.Biblioteca.Count() - 1 || second < first));

            // Show to delete, ask for confirmation
            List<Videojuego> todelete = new List<Videojuego>();
            todelete.AddRange(v.Biblioteca.GetRange(first, second - first + 1));
            Console.Clear();
            MostrarBiblioteca(todelete);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nEstos son los elementos que se van a borrar.");
            Console.WriteLine("¿Continuar? s/n");
            Console.ResetColor();
            if (Console.ReadKey().Key == ConsoleKey.S)
                v.Eliminar(second, first);
        }

        public static void MostrarBiblioteca(List<Videojuego> v)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("{0, 10}\t\t{1, 10}\t\t{2, 10}\t\t{3, 10}","Indice", "Titulo", "F. Lanzamiento", "Género");
            Console.ResetColor();
            int i = 0;
            foreach(Videojuego videojuego in v)
            {
                Console.WriteLine("{0, 10}\t\t{1, 10}\t\t{2, 10}\t\t{3, 10}", i.ToString(), Shorten(videojuego.Titulo), videojuego.Year, videojuego.Tipo);
                i++;
            }
        }

        public static void MostrarBibliotecaEstilo(Videojuegos v)
        {
            Console.Clear();
            int tempCategoria;
            bool parsed;
            Videojuego.Estilo categoria;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Categoría: (0 Arcade, 1 VideoAventura, 2 Shootemup, 3 Estrategia, 4 Deportivo)");
            Console.ResetColor();
            do
            {
                parsed = Int32.TryParse(Console.ReadLine(), out tempCategoria);
                categoria = (Videojuego.Estilo)tempCategoria;
                if (!parsed || (tempCategoria < 0 || tempCategoria > 4))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Porfavor, introduzca una categoría válida: (0 Arcade, 1 VideoAventura, 2 Shootemup, 3 Estrategia, 4 Deportivo)");
                    Console.ResetColor();
                }
            } while (!parsed || (tempCategoria < 0 || tempCategoria > 4));

            Console.Clear();
            MostrarBiblioteca(v.Busqueda(categoria));
        }

        public static string Shorten(string str)
        {
            return str.Length > 10 ? str.Substring(0, 7) + "..." : str;
        }

        static void Main(string[] args)
        {
            Videojuegos videojuegos = new Videojuegos();

            var menu = new Menu.Menu(new string[] { "Añadir un juego", "Eliminar juegos", "Ver biblioteca", "Ver juegos por estilo", "Modificar juego", "Salir"});
            var menuPainter = new Menu.ConsoleMenuPainter(menu);
            int choice = -1;
            bool picked = false;

            while(choice != 5)
            {
                menuPainter.Paint(0, 0);
                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: menu.moveUp(); break;
                    case ConsoleKey.DownArrow: menu.moveDown(); break;
                    case ConsoleKey.Enter:
                        choice = menu.selectedIndex;
                        picked = !picked;
                        Console.ResetColor();
                        break;
                }

                if(picked)
                    switch (choice)
                    {
                        case 0: Console.Clear(); InsertarJuego(videojuegos); Console.ReadKey(); goto default;
                        case 1: Console.Clear(); EliminarJuegos(videojuegos); Console.ReadKey(); goto default;
                        case 2: Console.Clear(); MostrarBiblioteca(videojuegos.Biblioteca); Console.ReadKey(); goto default;
                        case 3: Console.Clear(); MostrarBibliotecaEstilo(videojuegos);  Console.ReadKey(); goto default;
                        case 4: goto default;
                        default:
                            picked = !picked;
                            Console.Clear();
                            break;
                    }
            }
        }
    }
}
