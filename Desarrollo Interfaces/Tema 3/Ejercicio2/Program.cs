using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ejercicio2.Menu;

namespace Ejercicio2
{
   class Program
    {
        public static void MenuNotasAlumnos(Aula a)
        {
            var menu = new Menu.Menu(new string[] { "Alberto", "Francisco", "Samuel", "Pablo", "Rodrigo", "Alfonso", "Roberto", "Adrian", "Carmen", "Silvia", "Maria", "Ana", "\nSalir" });
            var menuPainter = new ConsoleMenuPainter(menu);
            int choice = -1;
            bool picked = false;

            while (choice != 12)
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
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            Console.Clear();
                            Interfaz.ShowNotasAlumno(a, a.alumnos[choice]);
                            //a.NotasAlumno(a.alumnos[choice]);
                            Console.ReadKey();
                            goto default;
                        default:
                            picked = !picked;
                            Console.Clear();
                            break;
                    }
            }
        }

        public static void MenuMediaAlumnos(Aula a)
        {
            var menu = new Menu.Menu(new string[] { "Alberto", "Francisco", "Samuel", "Pablo", "Rodrigo", "Alfonso", "Roberto", "Adrian", "Carmen", "Silvia", "Maria", "Ana", "\nSalir" });
            var menuPainter = new ConsoleMenuPainter(menu);
            int choice = -1;
            bool picked = false;

            while(choice != 12)
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
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                    case 9:
                    case 10:
                    case 11:
                            Console.Clear();
                            Console.WriteLine("Media de {0}: {1}", a.alumnos[choice], a.MediaAlumno(a.alumnos[choice]));
                            Console.ReadKey();
                            goto default;
                    default:
                        picked = !picked;
                        Console.Clear();
                        break;
                }
            }
        }

        public static void MenuMaxMinAlumnos(Aula a, ref int max, ref int min)
        {
            var menu = new Menu.Menu(new string[] { "Alberto", "Francisco", "Samuel", "Pablo", "Rodrigo", "Alfonso", "Roberto", "Adrian", "Carmen", "Silvia", "Maria", "Ana", "\nSalir" });
            var menuPainter = new ConsoleMenuPainter(menu);
            int choice = -1;
            bool picked = false;

            while (choice != 12)
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
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                        case 4:
                        case 5:
                        case 6:
                        case 7:
                        case 8:
                        case 9:
                        case 10:
                        case 11:
                            Console.Clear();
                            a.MaxMin(ref max, ref min, a.alumnos[choice]);
                            Console.WriteLine("La nota máxima de {0} es {1} y la mínima {2}.", a.alumnos[choice], max, min);
                            Console.ReadKey();
                            goto default;
                        default:
                            picked = !picked;
                            Console.Clear();
                            break;
                    }
            }
        }

        public static void MenuNotasAsignaturas(Aula a)
        {
            var menu = new Menu.Menu(new string[] { "Matematicas", "Lengua", "Ciencias", "Geografia", "\nSalir" });
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
                        picked = !picked;
                        Console.ResetColor();
                        break;
                }

                if (picked)
                    switch (choice)
                    {
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            Console.Clear();
                            Interfaz.ShowNotasMateria(a, (Aula.Asignaturas)choice);
                            //a.NotasMateria((Aula.Asignaturas)choice);
                            Console.ReadKey();
                            goto default;
                        default:
                            picked = !picked;
                            Console.Clear();
                            break;
                    }
            }
        }

        public static void MenuMediaAsignaturas(Aula a)
        {
            var menu = new Menu.Menu(new string[] { "Matematicas", "Lengua", "Ciencias", "Geografia", "\nSalir" });
            var menuPainter = new ConsoleMenuPainter(menu);
            int choice = -1;
            bool picked = false;

            while(choice != 4)
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
                        case 0:
                        case 1:
                        case 2:
                        case 3:
                            Console.Clear();
                            Console.WriteLine("La media de {0} es: {1}",(Aula.Asignaturas) choice, a.MediaAsignatura((Aula.Asignaturas)choice));
                            Console.ReadKey();
                            goto default;
                        default:
                            picked = !picked;
                            Console.Clear();
                            break;
                    }
            }
        }

        static void Main(string[] args)
        {
            Aula a = new Aula();

            var menu = new Menu.Menu(new string []{ "Calcular media del aula", "Media de un alumno", "Media asignatura", "Ver notas alumno", "Ver notas asignatura", "Nota maxima y minima alumno", "Aprobados", "Ver tabla entera", "Salir"});
            var menuPainter = new ConsoleMenuPainter(menu);
            int choice = -1;
            bool picked = false;

            while(choice != 8)
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
                        case 0:
                            Console.Clear();
                            Console.WriteLine("Media de la tabla: {0}", a.MediaAula());
                            Console.ReadKey();
                            goto default;
                        case 1:
                            Console.Clear();
                            MenuMediaAlumnos(a);
                            goto default;
                        case 2:
                            Console.Clear();
                            MenuMediaAsignaturas(a);
                            goto default;
                        case 3:
                            Console.Clear();
                            MenuNotasAlumnos(a);
                            goto default;
                        case 4:
                            Console.Clear();
                            MenuNotasAsignaturas(a);
                            goto default;
                        case 5:
                            Console.Clear();
                            int max = 0; int min = 0;
                            MenuMaxMinAlumnos(a, ref max, ref min);
                            goto default;
                        case 6:
                            Console.Clear();
                            Interfaz.ShowSoloAporbados(a);
                            Console.ReadKey();
                            goto default;
                        case 7:
                            Console.Clear();
                            Interfaz.ShowAula(a);
                            Console.ReadKey();
                            goto default;
                        default:
                            picked = !picked;
                            Console.Clear();
                            break;
                    }
            }
        }
    }
}
