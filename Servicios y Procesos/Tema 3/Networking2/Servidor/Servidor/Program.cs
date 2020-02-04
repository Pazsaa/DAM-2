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
        private static readonly List<Socket> clients = new List<Socket>();

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
                    lock (_lock) clients.Add(client);
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
                    string connectedString = String.Format("{0}@{1} has connected!", username, ip);
                    Broadcast(connectedString, client);
                }

                while (true)
                {
                    using (NetworkStream ns = new NetworkStream(client))
                    using (StreamReader sr = new StreamReader(ns))
                    {
                        string message = username + "@" + ip + ": " + sr.ReadLine();
                        Console.WriteLine(message) ;
                        Broadcast(message, client);
                    }
                }
                
            }
            catch (IOException ex)
            {
                Console.WriteLine("{0}@{1} disconnected!", username, ip);
                string disconnectedString = String.Format("{0}@{1} has disconnected!", username, ip);
                lock (_lock) clients.Remove(client);
                Broadcast(disconnectedString, client);
            }
            
        }

        public static void Broadcast(string message, Socket origin)
        {
            foreach(Socket c in clients)
            {
                if(c != origin)
                {
                    using (NetworkStream ns = new NetworkStream(c))
                    using (StreamWriter sw = new StreamWriter(ns))
                    {
                        sw.WriteLine(message);
                    }
                }
            }
        }
    }
}
