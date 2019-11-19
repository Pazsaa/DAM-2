using System;

namespace Serv1
{
    class Program
    {
        public delegate void MyDelegate();

        static void MenuGenerator(string[] opts, Delegate[] funcs)
        {
            int choice = -1;
            do
            {
                Console.Clear();
                for (int i = 0; i <= opts.Length; i++)
                {
                    if (i == opts.Length)
                    {
                        Console.WriteLine((i + 1) + "- Exit");
                    }
                    else
                    {
                        Console.WriteLine((i + 1) + "- " + opts[i]);
                    }
                }

                Int32.TryParse(Console.ReadLine(), out choice);

                if (choice > 0 && choice <= opts.Length)
                {
                    funcs[choice - 1].DynamicInvoke();
                    Console.ReadKey();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid option, try again.");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            } while (choice != opts.Length + 1);
        }

        static void f1()
        {
            Console.WriteLine("A");
        }
        static void f2()
        {
            Console.WriteLine("B");;
        }
        static void f3()
        {
            Console.WriteLine("C");
        }

        static void Main(string[] args)
        {
            MenuGenerator(new string[] { "Op1", "Op2", "Op3" },
                          new MyDelegate[] { f1, f2, f3 });
        }
    }
}
