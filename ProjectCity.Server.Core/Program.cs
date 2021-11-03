using Newtonsoft.Json;
using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;

namespace ProjectCity.Server.Core
{
    public class Program
    {
        // Data buffer for incoming data.  
        public static byte[] bytes = new Byte[4096];
        public static Socket handler { get; set; }

        // Incoming data from the client.  

        public static List<Game> Initial { get; set; }

        public static void StartListening()
        {
            
            int nbClients = 0;

            // Establish the local endpoint for the socket.  
            // Dns.GetHostName returns the name of the
            // host running the application.  
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
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
                    handler = listener.Accept();
                    string clientIP = ((System.Net.IPEndPoint)handler.RemoteEndPoint).Address.ToString();
                    Console.WriteLine("Client connecté: {0}", clientIP);
                    nbClients++;

                    //Envoi fichier config game
                    //handler.Send(System.Text.Encoding.UTF8.GetBytes("Client IP : "+ clientIP + ", N° : "+ nbClients));
                    StreamReader r = new StreamReader("../../../../ProjectCity.VM/JSon/Data.json");
                    string json = r.ReadToEnd();
                    byte[] msg = System.Text.Encoding.UTF8.GetBytes(json); //conversion string en tableau
                    int size = handler.Send(msg);
                    if (size == 0) break;
                    //Console.WriteLine(">>" + json);

                    //Création d'une réf client
                    ClientCommunication cc = new ClientCommunication(handler, nbClients);

                    Thread Tc = new Thread(Communication);
                    Tc.Start(cc);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();

        }

        public static void StartClient()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[4096];

            // Connect to a remote device.  
            try
            {

                IPAddress ipAddress = IPAddress.Parse("172.16.30.20");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1000);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(ipAddress, 1000);/////////////////////////////////////////////   UN THREAD



                    var t = new Thread(() =>
                    {
                        while (true)
                        {

                            // Receive the response from the remote device.  
                            int bytesRec = sender.Receive(bytes);
                            string msgServer = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                            //var dataGame = JsonConvert.DeserializeObject<dynamic>(msgServer);

                            //foreach (Game game in dataGame.data.game)
                            //{
                            //    CompanyType compType = new CompanyType(
                            //        (int)game.CompanyType.Id,
                            //        (string)game.CompanyType.Title,
                            //        (int)game.CompanyType.SalariesLimite
                            //    );

                            //    Initial.Add(new Game(
                            //        (int)game.Id,
                            //        (int)game.PlayerMax,
                            //        (int)game.TurnMax,
                            //        (int)game.StartBudget,
                            //        compType
                            //        ));

                            //}
                            JsonDocument document = JsonDocument.Parse(msgServer);

                            JsonElement root = document.RootElement;
                            JsonElement gamesElement = root.GetProperty("game");


                            //Initial = JsonConvert.DeserializeObject<List<Game>>(gamesElement);

                            // Appel Dispatcher
                        }
                    });
                    t.Start();

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());


                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static int Main(String[] args)
        {
            StartListening();

            return 0;
        }

        public static void Communication(object client)
        {
            ClientCommunication cc = client as ClientCommunication;

            // An incoming connection needs to be processed.  
            while (true)
            {
                /////// ENVOI MISE A JOUR coté server Gestion TOUR PAR TOUR

                int bytesRec = handler.Receive(bytes);
                string data = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                Console.WriteLine(data);
                //int bytesRec = handler.Receive(bytes);
                //data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                //var game = JsonConvert.DeserializeObject<Game>(data);
                //foreach (var g in game.Players)
                //{
                //    Console.WriteLine(g.Pseudo);
                //}
                //data = "String désérialisé";
                //break;
                /////// TRAITEMENT 

            };
        }

        class ClientCommunication
        {
            public Socket socket { get; set; }
            public int numero { get; set; }

            public ClientCommunication(Socket socket, int numero)
            {
                this.socket = socket;
                this.numero = numero;
            }
        }
    }
}


