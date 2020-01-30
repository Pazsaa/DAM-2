using System;
using System.IO;
using System.Net;
using System.Net.Sockets;


namespace Servidor
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                IPEndPoint ie = new IPEndPoint(IPAddress.Any, 31416);

                using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
                {
                    s.Bind(ie);
                    s.Listen(10);

                    using (Socket sClient = s.Accept())
                    {
                        IPEndPoint ieClient = (IPEndPoint)sClient.RemoteEndPoint;
                        Console.WriteLine("Client {0} connected at port {1}", ieClient.Address, ieClient.Port);

                        using (NetworkStream ns = new NetworkStream(sClient))
                        using (StreamReader sr = new StreamReader(ns))
                        using (StreamWriter sw = new StreamWriter(ns))
                        {
                            string msg;
                            msg = sr.ReadLine();
                            switch (msg)
                            {
                                case "HORA":
                                    sw.WriteLine(DateTime.Now.Hour + ":" + DateTime.Now.Minute);
                                    sw.Flush();
                                    break;
                                case "FECHA":
                                    sw.WriteLine(DateTime.Now.Date.Day + "/" + DateTime.Now.Date.Month + "/" + DateTime.Now.Year);
                                    sw.Flush();
                                    break;
                                case "TODO":
                                    sw.WriteLine(DateTime.Now);
                                    sw.Flush();
                                    break;
                                case "APAGAR":
                                    Environment.Exit(1);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
