using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Servidor
{
    class Program
    {
        private static readonly object _lock = new object();
        private static readonly Dictionary<string, Socket> clientes = new Dictionary<string, Socket>();
        //private static readonly List<Socket> clients = new List<Socket>();

        static void Main(string[] args)
        {
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 31416);

            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                s.Bind(ie);
                s.Listen(100);

                while (true)
                {
                    Socket client = s.Accept();
                    Console.WriteLine("Client {0} connected at {1}", (client.RemoteEndPoint as IPEndPoint).Address, (client.RemoteEndPoint as IPEndPoint).Port);
                    //lock (_lock) clients.Add(client);
                    Thread t = new Thread(o => ClientThread(client));
                    t.Start();
                }
            }
        }

        public static void ClientThread(Socket client)
        {
            string username = "";
            string ip = (client.RemoteEndPoint as IPEndPoint).Address.ToString();

            try
            {
                using (NetworkStream ns = new NetworkStream(client))
                using (StreamReader sr = new StreamReader(ns))
                {
                    username = sr.ReadLine();
                    // test
                    lock (_lock) clientes.Add(username, client);
                    // eof test
                    string connectedString = String.Format("{0}@{1} has connected!", username, ip);
                    Broadcast(connectedString, client);
                }

                while (true)
                {
                    using (NetworkStream ns = new NetworkStream(client))
                    using (StreamReader sr = new StreamReader(ns))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        string message = sr.ReadLine();
                        string FORMAT = username + "@" + ip + ": " + message;
                        Console.WriteLine(FORMAT);

                        switch (message)
                        {
                            case "#salir":
                                client.Close();
                                break;
                            case "#lista":
                                lock (_lock)
                                {
                                    string format = "";
                                    foreach (KeyValuePair<string, Socket> e in clientes)
                                    {
                                        format = string.Format("{0}@{1}\n", e.Key, (e.Value.RemoteEndPoint as IPEndPoint).Address);
                                        sw.WriteLine(format);
                                        sw.Flush();
                                    }
                                }
                                break;
                            default:
                                Broadcast(FORMAT, client);
                                break;
                        }
                    }
                }
                
            }
            catch (IOException ex)
            {
                Console.WriteLine("{0}@{1} disconnected!", username, ip);
                string disconnectedString = String.Format("{0}@{1} has disconnected!", username, ip);
                lock (_lock) clientes.Remove(username);
                Broadcast(disconnectedString, client);
            }
            
        }

        public static void Broadcast(string message, Socket origin)
        {
            //foreach(Socket c in clients)
            //{
            //    if(c != origin)
            //    {
            //        using (NetworkStream ns = new NetworkStream(c))
            //        using (StreamWriter sw = new StreamWriter(ns))
            //        {
            //            sw.WriteLine(message);
            //        }
            //    }
            //}

            // testing
            foreach(KeyValuePair<string, Socket> e in clientes)
            {
                Socket client = e.Value;
                if(client != origin)
                {
                    using (NetworkStream ns = new NetworkStream(client))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        sw.WriteLine(message);
                    }
                }
            }
        }
    }
}
