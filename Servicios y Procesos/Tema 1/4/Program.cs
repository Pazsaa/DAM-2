using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serv4
{
    class Program
    {
        readonly private static object l = new object();
        public static int meta = 50;
        public static bool isRaceOver = false;
        public static int winner = 0;
        public static Random r;

        public static void caballo(object a)
        {
            r = new Random();
            int i = 0;
            while(i < meta && !isRaceOver)
            {
               
                int distance = r.Next(1, 3);
                string str = new string('*', distance);
                lock (l)
                {
                    Console.SetCursorPosition(i, (int)a);
                    Console.Write(str);
                }
                i += distance;
                int sleepyness = r.Next(100, 600);
                Thread.Sleep(sleepyness);
            }

            isRaceOver = true;
            if(i >= meta)
            {
                winner = (int)a;
            }
        }

        static void Main(string[] args)
        {
            char again = 'y';
            do
            {
                Console.Clear();
                isRaceOver = false;
                int apuesta;
                bool parsed;
                do {
                    Console.WriteLine("¿A que caballo quieres apostart? <1-5>");
                    parsed = int.TryParse(Console.ReadLine(), out apuesta);
                } while (!parsed || apuesta < 1 || apuesta > 5);

                Console.Clear();
                Thread[] caballos = new Thread[5];
                for (int i = 0; i < caballos.Length; i++)
                {
                    caballos[i] = new Thread(caballo);
                    caballos[i].Start(i + 1);
                }
                Array.ForEach(caballos, (x) => x.Join());

                Console.SetCursorPosition(5, 7);
                Console.WriteLine("Ganó el caballo: {0}", winner);
                Console.SetCursorPosition(5, 8);
                Console.ForegroundColor = apuesta == winner ? ConsoleColor.Green : ConsoleColor.Red;
                Console.WriteLine(apuesta == winner ? "Has ganado!" : "Has perdido");

                Console.ResetColor();
                Console.SetCursorPosition(5, 9);
                Console.WriteLine("¿Quieres continuar? <s/n>");
                again = Console.ReadKey().KeyChar;
            } while (again != 'n');
            
            
            
            Console.ReadKey();
        }
    }
}
