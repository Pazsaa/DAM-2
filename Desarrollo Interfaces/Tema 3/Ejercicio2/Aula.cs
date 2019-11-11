using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio2
{
    public class Aula
    {
        public enum Asignaturas
        {
            Matematicas = 0,
            Lengua,
            Ciencias,
            Geografia

        }
        private int[,] notas = new int[4,12];
        public int[,] Notas { get { return notas; } }
        public string[] alumnos = { "Alberto", "Francisco", "Samuel", "Pablo", "Rodrigo", "Alfonso", "Roberto", "Adrian", "Carmen", "Silvia", "Maria", "Ana" };
        public int this[int i, int j]
        {
            set
            {
                notas[i,j] = value;
            }
            get
            {
                return notas[i,j];
            }
        }

        public Aula()
        {
            Random r = new Random();
            for(int i = 0; i < notas.GetLength(0); i++)
            {
                for(int j = 0; j < notas.GetLength(1); j++)
                {
                    int nota = r.Next(100) + 1;
                    switch (nota)
                    {
                        case int n when n < 5:
                            notas[i,j] = 0;
                            break;
                        case int n when n > 5 && n <= 10:
                            notas[i, j] = 1;
                            break;
                        case int n when n > 10 && n <= 15:
                            notas[i, j] = 2;
                            break;
                        case int n when n > 15 && n <= 25:
                            notas[i, j] = 3;
                            break;
                        case int n when n > 25 && n <= 40:
                            notas[i, j] = 4;
                            break;
                        case int n when n > 40 && n <= 55:
                            notas[i, j] = 5;
                            break;
                        case int n when n > 55 && n <= 70:
                            notas[i, j] = 6;
                            break;
                        case int n when n > 70 && n <= 80:
                            notas[i, j] = 7;
                            break;
                        case int n when n > 80 && n <= 90:
                            notas[i, j] = 8;
                            break;
                        case int n when n > 90 && n <= 95:
                            notas[i, j] = 9;
                            break;
                        case int n when n > 95 && n <= 100:
                            notas[i, j] = 10;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        //// Mover a clase interfaz
        //public void ShowAlumnos()
        //{
        //    for(int i = 0; i < alumnos.Length; i++)
        //    {
        //        Console.Write(alumnos[i] + "  ");
        //    }
        //    Console.WriteLine();
        //}

        // Mover a clase de interfaz
        //public void ShowAula()
        //{
        //    for(int i = 0; i < notas.GetLength(0); i++)
        //    {
        //        Console.WriteLine((Asignaturas)i);
        //        for(int j = 0; j < notas.GetLength(1); j++)
        //        {
        //            Console.Write(notas[i, j] + "\t");
        //        }
        //        Console.WriteLine("\n");
        //    }
        //}

        public string NotasAlumno(string alumno)
        {
            string resultado = "";
            int indexAlumno = FindAlumno(alumno);
            if (indexAlumno != -1)
            {
                resultado += String.Format("Notas {0}\n", alumno);
                for (int i = 0; i < notas.GetLength(0); i++)
                {
                    resultado += (Asignaturas)i;
                    resultado += String.Format(": {0} -- ", notas[i, indexAlumno]);
                }

                return resultado;
            }
            else
                return "Alumno not found";
        }

        // Mover a clase interfaz
        //public void NotasMateria(Asignaturas a)
        //{
        //    Console.WriteLine(a);
        //    for (int j = 0; j < notas.GetLength(1); j++)
        //    {
        //        Console.Write(notas[(int)a, j] + "\t");
        //    }
        //}

        public List<string> SoloAprobados()
        {
            List<string> aprobadosNombre = new List<string>();
            List<int> aprobadosIndex = new List<int>();
            int aprobados;

            for(int j = 0; j < notas.GetLength(1); j++)
            {
                aprobados = 0;
                for (int i = 0; i < notas.GetLength(0); i++)
                {
                    if (notas[i, j] >= 5) aprobados++;
                    if (aprobados == 4) aprobadosIndex.Add(j);
                }
            }

            if (aprobadosIndex.Count == 0)
                //Console.WriteLine("Nadie ha a aprobado todas, qué desgracia.");
                return null;

            foreach(int a in aprobadosIndex)
            {
                aprobadosNombre.Add(alumnos[a]);
                //Console.WriteLine(alumnos[a]);
                //NotasAlumno(alumnos[a]);
                //Console.WriteLine("\n");
            }

            return aprobadosNombre;
        }

        public double MediaAula()
        {
            int notaSuma = 0;
            for(int i = 0; i < notas.GetLength(0); i++)
            {
                for (int j = 0; j < notas.GetLength(1); j++)
                {
                    notaSuma += notas[i, j];
                }
            }

            return notaSuma / notas.Length;
        }

        public double MediaAlumno(string alumno)
        {
            int indexAlumno = FindAlumno(alumno);
            if (indexAlumno != -1)
            {
                int notaSuma = 0;
                for (int i = 0; i < notas.GetLength(0); i++)
                {
                    notaSuma += notas[i, indexAlumno];
                }

                return notaSuma / notas.GetLength(0);
            }
            else
                return -1; // Alumno not found
        }

        public double MediaAsignatura(Asignaturas a)
        {
            double sumaNotas = 0;
            for (int j = 0; j < notas.GetLength(1); j++)
            {
                sumaNotas += notas[(int)a, j];
            }
            return sumaNotas / 12;
        }

        public void MaxMin(ref int max, ref int min, string alumno)
        {
            max = 0; min = 10;
            int indexAlumno = FindAlumno(alumno);
            if(indexAlumno != -1)
            {
                for(int i = 0; i < notas.GetLength(0); i++)
                {
                    if (notas[i, indexAlumno] > max)
                        max = notas[i, indexAlumno];
                    if (notas[i, indexAlumno] < min)
                        min = notas[i, indexAlumno];
                }
            }
            else
            {
                max = -1; min = -1;
            }
        }

        public int FindAlumno(string alumno)
        {
            int? indexAlumno = null;
            for (int j = 0; j < alumnos.Length; j++)
            {
                if (alumnos[j] == alumno)
                {
                    indexAlumno = j;
                    continue;
                }
            }

            return indexAlumno != null ? (int)indexAlumno : -1;
        }
    }
}
