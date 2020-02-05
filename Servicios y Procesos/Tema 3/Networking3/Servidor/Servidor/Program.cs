using System;
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
        private static readonly Dictionary<int, Socket> clients = new Dictionary<int, Socket>();
        private static readonly List<int> possible_numbers = Enumerable.Range(1, 20).ToList();
        private static int _countDown = 10;
        private static bool isGameOver = false;
        static void Main(string[] args)
        {
            bool isCountingDown = false;
            IPEndPoint ie = new IPEndPoint(IPAddress.Any, 31416);

            using (Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
            {
                s.Bind(ie);
                s.Listen(20);

                while (!isGameOver) 
                {
                    Socket client = s.Accept();
                    Random r = new Random();
                    int number = possible_numbers[r.Next(0, possible_numbers.Count)];
                    possible_numbers.Remove(number);

                    Console.WriteLine("Someone connected!, I gave him number {0}", number);

                    lock (_lock) clients.Add(number, client);

                    if(clients.Count >= 2 && !isCountingDown)
                    {
                        Thread game = new Thread(StartGame);
                        game.Start();
                        isCountingDown = !isCountingDown;
                    }
                }
            }

            Console.WriteLine("Game finished, shutting down...");
            Console.ReadKey();
        }

        public static void StartGame()
        {
            Console.WriteLine("Game started! Counting down from {0}", _countDown);
            while(_countDown > 0)
            {
                foreach (KeyValuePair<int, Socket> kv in clients)
                {
                    try
                    {
                        Socket client = kv.Value;
                        using (NetworkStream ns = new NetworkStream(client))
                        using (StreamWriter sw = new StreamWriter(ns))
                        {
                            sw.WriteLine(_countDown < 10 ? "Countdown: 0" + _countDown : "Countdown: " + _countDown.ToString());
                        }
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine("Someone left before the game started, skipping...");
                    }
                }

                Console.WriteLine(_countDown.ToString());
                _countDown--;
                Thread.Sleep(1000);
            }
            isGameOver = !isGameOver; // New clients accepted up to this point.

            int winner_number = clients.Keys.Max();
            Console.WriteLine("The highest number is {0}", winner_number);
            foreach(KeyValuePair<int, Socket> kv in clients)
            {
                Socket client = kv.Value;
                if(kv.Key != winner_number)
                {
                    try
                    {
                        using (NetworkStream ns = new NetworkStream(client))
                        using (StreamWriter sw = new StreamWriter(ns))
                        {
                            sw.WriteLine("The winner number was {0} and your number is {1}", winner_number, kv.Key);
                        }
                    }catch(Exception ex)
                    {
                        Console.WriteLine("Someone left before the game was finished, skipping...");
                    }
                }
                else
                {
                    try
                    {
                        using (NetworkStream ns = new NetworkStream(client))
                        using (StreamWriter sw = new StreamWriter(ns))
                        {
                            sw.WriteLine("Congratulations! You won with number {0}", winner_number);
                        }
                    }catch (Exception ex)
                    {
                        Console.WriteLine("Someone left before the game was finished, skipping...");
                    }
                }
            }
        }
    }
}
