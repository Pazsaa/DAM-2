using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Ejercicio4
{
    public class Menu
    {
        public Menu(IEnumerable<string> items)
        {
            Items = items.ToArray();
        }

        public IReadOnlyList<string> Items { get; }

        public int selectedIndex { get; private set; } = -1; // no selection
        public string selectedOpt => selectedIndex != -1 ? Items[selectedIndex] : null;

        public void moveUp() => selectedIndex = Math.Max(selectedIndex - 1, 0);
        public void moveDown() => selectedIndex = Math.Min(selectedIndex + 1, Items.Count - 1);
    }

    public class ConsoleMenuPainter
    {
        readonly Menu menu;

        public ConsoleMenuPainter(Menu menu)
        {
            this.menu = menu;
        }

        public void Paint(int x, int y)
        {
            for (int i = 0; i < menu.Items.Count; i++)
            {
                Console.SetCursorPosition(x, y + i);

                var color = menu.selectedIndex == i ? ConsoleColor.Yellow : ConsoleColor.Gray;

                Console.ForegroundColor = color;
                Console.WriteLine(menu.Items[i]);
            }
        }
    }

    class Program
    {
        public static void Dados(int caras = 6)
        {
            do
            {
                int aciertos = 0;
                Random r = new Random();

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("¿A qué numero quieres apostar? (1-{0})", caras);
                Console.ResetColor();

                int bet;
                if (int.TryParse(Console.ReadLine(), out bet) && (bet > 0 && bet <= caras))
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Has apostado al número {0}!", bet);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Tirando 10 dados...");

                    for (int i = 0; i < 10; i++)
                    {
                        int tirada = r.Next(caras) + 1;
                        if (tirada == bet)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            aciertos++;
                        }
                        else
                            Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine(tirada.ToString());
                        Thread.Sleep(500);
                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Has acertado {0} veces!", aciertos);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Numero inválido. Expulsado de la partida!");
                }

                Console.ResetColor();
                Console.WriteLine("¿Quieres volver a jugar? (S/N)");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        public static void AdivinaNumero()
        {
            do
            {
                Random r = new Random();
                int adivina = r.Next(100) + 1;

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("He anotado un numero entre el 1 y el 100 en un papelito.");
                Console.WriteLine("Tienes 5 intentos para adivinarlo... :)");
                Console.ResetColor();

                int intentos = 5;
                bool victory = false;

                int numero = 0;
                bool parse;
                while (intentos > 0 && !victory)
                {
                    do
                    {
                        parse = int.TryParse(Console.ReadLine(), out numero);
                    } while (!parse || (numero > 100 || numero < 1));

                    if (numero == adivina)
                        victory = true;
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR!");

                        string mayormenor = numero > adivina ? "MENOR" : "MAYOR";

                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("El numero que buscas es {0}!", mayormenor);
                        Console.WriteLine("Te quedan {0} intentos...", intentos);
                        intentos--;
                    }
                    Console.ResetColor();
                }


                if (!victory)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Tú pierdes! :)");
                    Console.WriteLine("El numero que tenia anotado era {0}!", adivina);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Correcto, has dicho {0}. Y {1} era el numero que habia anotado.", numero, adivina);
                    Console.WriteLine("Tu ganas, esta vez...");
                }

                Console.ResetColor();
                Console.WriteLine("¿Quieres volver a jugar? (S/N)");
            } while (Console.ReadKey().Key != ConsoleKey.N);
        }

        public static void Quiniela()
        {
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Resultados de la quiniela: ");
                Console.ResetColor();
                for (int i = 0; i < 14; i++)
                {
                    char res = resultadoQuiniela();
                    if (res == '1')
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(res);
                        Console.ResetColor();
                        Console.Write("\tX\t2");
                    }

                    if (res == 'X')
                    {
                        Console.Write("1");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("\t" + res);
                        Console.ResetColor();
                        Console.Write("\t2");
                    }

                    if (res == '2')
                    {
                        Console.Write("1\tX\t");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(res);
                        Console.ResetColor();
                    }

                    Console.WriteLine("");
                }
                Console.WriteLine("¿Quieres volver a jugar?(S/N)");
            } while (Console.ReadKey().Key != ConsoleKey.N);

        }

        public static char resultadoQuiniela()
        {
            Random r = new Random();
            int aleatorio = r.Next(100) + 1;

            switch (aleatorio)
            {
                case int val when (val < 60):
                    return '1';
                case int val when (val > 60 && val <= 85):
                    return 'X';
                case int val when (val >= 75):
                    return '2';
                default:
                    return '?';
            }
        }

        static void Main(string[] args)
        {
            var menu = new Menu(new String[] { "Jugar a los dados", "Jugar a adivinar", "Juego tres", "Jugar a todos", "<!> Salir" });
            var menuPainter = new ConsoleMenuPainter(menu);

            int choice = -1;
            bool picked = false;

            while (choice != 4)
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
                        case 0: Dados(); if (choice == 3) goto case 1; goto default;
                        case 1: AdivinaNumero(); if (choice == 3) goto case 2; goto default;
                        case 2: Quiniela(); goto default;
                        case 3: goto case 0;
                        default:
                            picked = !picked; Console.Clear(); break;
                    }
            }
        }
    }
}
