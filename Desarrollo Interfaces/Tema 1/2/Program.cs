#define FRASE
using System;

namespace Ejercicio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Introduce dos frases: ");
            string primera = Console.ReadLine();
            string segunda = Console.ReadLine();
            Console.Clear();
#if FRASE
            Console.WriteLine("\"{0}\"\t\\{1}\\", primera, segunda);
#else
            Console.WriteLine("{0}\t{1}\n{0}\n{1}", primera, segunda);

            Console.ReadKey();
#endif
        }
    }
}
