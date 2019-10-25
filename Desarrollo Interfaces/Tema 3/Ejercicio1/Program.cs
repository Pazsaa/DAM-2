using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio1.Menu;

namespace Ejercicio1
{
    class Program
    {
        public static bool ValidateIP(string ip)
        {
            if (String.IsNullOrWhiteSpace(ip))
                return false;

            string[] splits = ip.Split('.');
            if (splits.Length != 4)
                return false;

            byte tempParse;

            return splits.All(r => byte.TryParse(r, out tempParse));
        }

        public static string AskIP()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Introduce una dirección IP: ");
            Console.ResetColor();
            string ip = Console.ReadLine();

            while (!ValidateIP(ip))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("IP inválida, prueba de nuevo: ");
                Console.ResetColor();
                ip = Console.ReadLine();
            }
            return ip;
        }

        public static void MostrarTabla(Hashtable t)
        {
            Console.Clear();
            foreach(DictionaryEntry d in t)
            {
                Console.WriteLine("IP: {0}\nRAM: {1}GB\n\n", d.Key, d.Value);
            }
            Console.ReadKey();
        }

        public static void IntroducirElemento(Hashtable t)
        {
            Console.Clear();
            string ip = AskIP();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("¿Cuanta RAM tiene el equipo?");
            Console.ResetColor();
            int r;
            bool ramInt = Int32.TryParse(Console.ReadLine(), out r);

            while(!ramInt || r < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("RAM inválida, prueba otra vez: ");
                Console.ResetColor();
                ramInt = Int32.TryParse(Console.ReadLine(), out r);
            }

            t.Add(ip, r);
        }

        public static void MostrarElemento(Hashtable t)
        {
            Console.Clear();
            bool exists = false;
            string key = AskIP();
            foreach (DictionaryEntry d in t)
            {
                if (d.Key.ToString() == key)
                {
                    Console.WriteLine("IP: {0}\nRAM: {1}GB\n\n", d.Key, d.Value);
                    exists = !exists;
                    continue;
                }
            }

            if (!exists)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("La IP que buscas no está en la tabla, si debería estarlo, añadela desde el menú!");
            }
                
            Console.ReadKey();
        }

        static void Main(string[] args)
        {
            Hashtable ips = new Hashtable();
            ips.Add("192.168.0.20", 4); ips.Add("0.0.0.0", 12); ips.Add("32.32.32.32", 32);

            var menu = new Menu.Menu(new String[] { "Visualizar tabla", "Visualizar un elemento", "Introducir un elemento " , "Salir" });
            var menuPainter = new ConsoleMenuPainter(menu);

            int choice = -1;
            bool picked = false;

            while(choice != 3)
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

                if (picked)
                    switch (choice)
                    {
                        case 0: MostrarTabla(ips); goto default;
                        case 1: MostrarElemento(ips); goto default;
                        case 2: IntroducirElemento(ips); goto default;
                        default:
                            picked = !picked; Console.Clear(); break;
                    }
            }
        }
    }
}
