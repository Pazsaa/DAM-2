using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1_4.Menu;

namespace Ejercicio1_4
{
    class Program
    {
        public static double calcularGanancias(IPastaGansa ip, int gananciasEmpresa)
        {
            return ip.GanarPasta(gananciasEmpresa);
        }
        public static void mostrarDatos(Persona p)
        {
            Console.Clear();
            if (p is IPastaGansa)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("¿Cuanto ha ganado la empresa?");
                int gananciasEmpresa;
                bool getGananciasEmpresa = Int32.TryParse(Console.ReadLine(), out gananciasEmpresa);
                while (!getGananciasEmpresa)
                {
                    Console.WriteLine("Error, introduce un número válido:");
                    getGananciasEmpresa = Int32.TryParse(Console.ReadLine(), out gananciasEmpresa);
                }

                IPastaGansa ip = p as IPastaGansa;
                ip.GananciasEmpresa = gananciasEmpresa;

                Console.ResetColor();
                Console.WriteLine(p.ShowData());
                Console.WriteLine(calcularGanancias(p as IPastaGansa, gananciasEmpresa));
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine(p.ShowData());
                Console.ReadKey();
            }
            
            
        }

        static void Main(string[] args)
        {
            Directivo d = new Directivo("Alberto", "Paz García", "39492832", 23, "Horno de almas", 666);
            Empleado e = new Empleado("Pablo", "Blanco", "34629323", 20, 200, "636363636");
            EmpleadoEspecial es = new EmpleadoEspecial("Sergio", "Martin", "12312312", 20, 2000, "363636363");

            var menu = new Menu.Menu(new String[] { "Visualizar datos directivo", "Visualizar datos empleado", "Visualizar datos empleado especial", "Salir" });
            var menuPainter = new ConsoleMenuPainter(menu);

            int choice = -1;
            bool picked = false;

            while (choice != 3)
            {

                menuPainter.Paint(0, 0);
                var keyInfo = Console.ReadKey();

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow: menu.moveUp(); break;
                    case ConsoleKey.DownArrow: menu.moveDown(); break;
                    case ConsoleKey.Enter:
                        choice = menu.selectedIndex;
                        picked = true;
                        Console.ResetColor();
                        break;
                }

                if (picked)
                    switch (choice)
                    {
                        case 0: mostrarDatos(d);    goto default;
                        case 1: mostrarDatos(e);    goto default;
                        case 2: mostrarDatos(es);   goto default;
                        default:
                            picked = !picked; Console.Clear(); break;
                    }
            }
        }
    }
}
