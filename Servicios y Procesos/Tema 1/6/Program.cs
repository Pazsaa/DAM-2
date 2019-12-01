using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Serv6
{
    class Program
    {
        readonly private static object l = new object();
        public static Random r = new Random();
        public static int Numero1 = 0;
        public static int Numero2 = 0;

        public static bool isDisplayPaused = false;
        public static bool gameOver = false;

        public static int puntuacion = 0;

        

        // Player 1 / Player 2
        public static void Players(int i, ref int numero)
        {
            while (!gameOver)
            {
                numero = r.Next(1, 10);

                lock (l)
                {
                    Console.SetCursorPosition(1, i);
                    Console.Write(numero);
                }
                int sleep = r.Next(100, numero * 100);
                Thread.Sleep(sleep);
            }
        }

        // Display
        public static void Display()
        {
            while (!gameOver)
            {
                gameOver = puntuacion >= 20 || puntuacion <= -20;
                if (!gameOver)
                {
                    if (Numero1 == 5 || Numero1 == 7)
                    {
                        puntuacion += isDisplayPaused ? 5 : 1;
                        isDisplayPaused = true;
                    }

                    if (Numero2 == 5 || Numero2 == 7)
                    {
                        puntuacion -= isDisplayPaused ? 1 : 5;
                        isDisplayPaused = false;
                    }

                    if (!isDisplayPaused)
                    {
                        lock (l)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.BackgroundColor = (ConsoleColor)r.Next((int)ConsoleColor.Red, (int)ConsoleColor.Yellow);
                            Console.SetCursorPosition(3, 3);
                            Console.WriteLine("{0, -20}", "Puntuacion: " + puntuacion);
                            Console.ResetColor();
                        }
                    }

                    Thread.Sleep(200);
                }
            }

            lock (l)
            {
                Console.BackgroundColor = (ConsoleColor)r.Next((int)ConsoleColor.Red, (int)ConsoleColor.Yellow);
                Console.SetCursorPosition(3, 3);
                Console.WriteLine("{0, -20}", "Puntuacion: " + puntuacion);
                Console.ResetColor();
            }
        }

        static void Main(string[] args)
        {
            Thread p1 = new Thread(() => Players(1, ref Numero1));
            Thread p2 = new Thread(() => Players(2, ref Numero2));
            Thread display = new Thread(() => Display());
            p1.Start(); p2.Start();
            display.Start();

            Console.ReadKey();
        }
    }
}
