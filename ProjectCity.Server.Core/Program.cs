using Newtonsoft.Json;
using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ProjectCity.Server.Core
{
    class Program
    {
        // Incoming data from the client.  
        public static string data = null;

        public static void StartListening()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new Byte[1024];

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse("172.16.30.14");
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 1000);

            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);

            // Bind the socket to the local endpoint and
            // listen for incoming connections.  
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);

                // Start listening for connections.  
                while (true)
                {
                    Console.WriteLine("Waiting for a connection...");
                    // Program is suspended while waiting for an incoming connection.  
                    Socket handler = listener.Accept();//////////////////////////////////////////////////////// UN THREAD
                    string clientIP = ((System.Net.IPEndPoint)handler.RemoteEndPoint).Address.ToString();
                    Console.WriteLine("Client connecté: {0}", clientIP);
                    StreamReader r = new StreamReader("../../../../Data.json");
                    string json = r.ReadToEnd();
                    byte[] msg = System.Text.Encoding.UTF8.GetBytes(json); //conversion string en tableau
                    int size = handler.Send(msg);
                    if (size == 0) break;
                    Console.WriteLine(">>" + json);

                    var tServer = new Thread(() =>
                    {
                        
                        data = null;

                        // An incoming connection needs to be processed.  
                        while (true)
                        {
                            int bytesRec = handler.Receive(bytes);
                            data = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                            var game = JsonConvert.DeserializeObject<Game>(data);

                            foreach (var g in game.Players)
                            {
                                Console.WriteLine(g.Pseudo);
                            }

                            data = "String désérialisé";

                            break;

                            /////// TRAITEMENT 

                            /////// ENVOI MISE A JOUR coté server Gestion TOUR PAR TOUR
                        }

                        // Show the data on the console.  
                        Console.WriteLine("Text received : {0}", data);

                        // Echo the data back to the client.  
                        byte[] msg = Encoding.UTF8.GetBytes(data);

                        handler.Send(msg);
                        handler.Shutdown(SocketShutdown.Both);
                        handler.Close();
                    });
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }


        public static int Main(String[] args)
        {
            StartListening();

            return 0;
        }


    }
}
    

