using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public static class Interfaz
    {
        public static void ShowAlumnos(Aula a)
        {
            for(int i = 0; i < a.alumnos.Length; i++)
                Console.Write(a.alumnos[i] + "  ");
            Console.WriteLine();
        }

        public static void ShowAula(Aula a)
        {
            for(int i = 0; i < a.Notas.GetLength(0); i++)
            {
                Console.WriteLine((Aula.Asignaturas)i);
                for (int j = 0; j < a.Notas.GetLength(1); j++)
                {
                    Console.Write(a.Notas[i, j] + "\t");
                }
                Console.WriteLine("\n");
            }
        }

        public static void ShowNotasAlumno(Aula a, string alumno)
        {
            Console.WriteLine(a.NotasAlumno(alumno));
        }

        public static void ShowNotasMateria(Aula a, Aula.Asignaturas asi)
        {
            Console.WriteLine(asi);
            for(int j = 0; j < a.Notas.GetLength(1); j++)
            {
                Console.Write(a.Notas[(int)asi, j] + "\t");
            }
        }

        public static void ShowSoloAporbados(Aula a)
        {
            List<string> nombres = a.SoloAprobados();
            foreach(string str in nombres)
            {
                Console.WriteLine(str);
                ShowNotasAlumno(a, str);
                Console.WriteLine("\n");
            }
        }
    }
}
