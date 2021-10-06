using Newtonsoft.Json;
using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;


namespace ProjectCity.Client.Services
{
    public static partial class Service
    {
        public static List<Game> Games(string filename)
        {
            var dataGame = Serializer.FromJson<dynamic>(filename);
            List<Game> games = new List<Game>();
           
            foreach (var game in dataGame.data.game)
            {
                CompanyType compType = new CompanyType(          
                    (int)game.companyType.id,
                    (string)game.companyType.title,
                    (int)game.companyType.salariesLimite
                );

                games.Add(new Game(
                    (int)game.id,
                    (int)game.playerMax,
                    (int)game.turnMax,
                    (int)game.startBudget,
                    compType
                    ));
            
            }
            return games;
        }

        public static void SetGame(Game game)
        {
            Serializer.SaveUWP("server.json", game); 
        }

        public static Dictionary<string, object> SyncLoop(Game game, Company company)
        {           
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            int loop = 0;
            if (game != null)
            {
                while (game.Players.Count < game.PlayerMax)
                {
                    // ici on ajoute les joueurs via le server
                    if (loop == 3)
                    {
                        game.Players.Add(new Player(2, "Anto", "Dec", "pseudo2"));
                    }

                    //Game = Service.Games("JSon/server.json").Find(g => g.Id == Game.Id);                   
                    System.Threading.Thread.Sleep(3000);
                
                    loop++;
                }
                parameters.Add("Company", company);
                parameters.Add("Game", game);

            }

            return parameters;
        }

        public static void StartClient()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[1024];

            // Connect to a remote device.  
            try
            {
                // Establish the remote endpoint for the socket.  
                // This example uses port 11000 on the local computer.  
                //IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                //IPAddress ipAddress = ipHostInfo.AddressList[0];
                IPAddress ipAddress = IPAddress.Parse("172.16.30.14");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1000);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    sender.Connect(ipAddress, 1000);/////////////////////////////////////////////   UN THREAD


                    var t = new Thread(() =>
                    {
                        while (true)
                        {
                            // Receive the response from the remote device.  
                            int bytesRec = sender.Receive(bytes);
                            Console.WriteLine("Echo test = {0}",
                                Encoding.UTF8.GetString(bytes, 0, bytesRec));


                            // Appel Dispatcher
                        }
                    });
                    t.Start();

                    Console.WriteLine("Socket connected to {0}",
                        sender.RemoteEndPoint.ToString());

                    // Encode the data string into a byte array.  
                    //byte[] msg = Encoding.UTF8.GetBytes(text);

                    // Send the data through the socket.  
                    //int bytesSent = sender.Send(msg);////// invoquer depuis une méthode depuis un événement



                    // Release the socket.  
                    //sender.Shutdown(SocketShutdown.Both);
                    //sender.Close();

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

    }
}
