using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 31416);

            using(Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                try
                {
                    server.Connect(ie);
                }catch(SocketException ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }

                Console.WriteLine("Waiting for the game to start...");

                while (true)
                {
                    try
                    {
                        using (NetworkStream ns = new NetworkStream(server))
                        using (StreamReader sr = new StreamReader(ns))
                        {
                            Console.SetCursorPosition(0, 5);
                            Console.WriteLine(sr.ReadLine());
                        }
                    }
                    catch(Exception e)
                    {
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
