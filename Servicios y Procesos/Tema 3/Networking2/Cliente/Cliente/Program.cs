using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        private static readonly object _lock = new object();

        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 31416);

            using (Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    server.Connect(ie);
                }
                catch(SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                Console.WriteLine("Introduce tu nombre de usuario: ");
                // Server reads username here.

                Thread read = new Thread(o => ReadThread(server));
                read.Start();

                while (true)
                {
                    using (NetworkStream ns = new NetworkStream(server))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        string message = Console.ReadLine();
                        sw.WriteLine(message);
                    }
                }
            }
        }

        public static void WriteThread(Socket server)
        {
            while (true)
            {
                using(NetworkStream ns = new NetworkStream(server))
                using (StreamWriter sw = new StreamWriter(ns))
                {
                    string message = Console.ReadLine();
                    sw.WriteLine(message);
                }
            }
        }

        public static void ReadThread(Socket server)
        {
            while (true)
            {
                using (NetworkStream ns = new NetworkStream(server))
                using (StreamReader sr = new StreamReader(ns))
                {
                    string message = sr.ReadLine();
                    Console.WriteLine(message);
                }
            }
        }
    }
}
