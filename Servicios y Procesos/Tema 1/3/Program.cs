using System;
using System.Threading;

namespace Serv3
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            new Thread(() =>
            {
                while (x < 1000 && x > -1000)
                {
                    x++;
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(x);
                }
            }).Start();

            new Thread(() =>
            {
                while (x < 1000 && x > -1000)
                {
                    x--;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(x);
                }
            }).Start();
        }
    }
}
