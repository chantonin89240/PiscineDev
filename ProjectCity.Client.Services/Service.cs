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
using System.Text.Json;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;


namespace ProjectCity.Client.Services
{
    public static partial class Service
    {
        public static List<Game> Initial { get; set; }


        public static List<Game> Games()
        {
            //var dataGame = Serializer.FromJson<dynamic>(filename);
            //List<Game> games = new List<Game>();
           
            /*foreach(Game game in Initial)
            {
            //}

            //foreach (var game in dataGame.data.game)
            //{
                CompanyType compType = new CompanyType(          
                    (int)game.CompanyType.Id,
                    (string)game.CompanyType.Title,
                    (int)game.CompanyType.SalariesLimite
                );

                games.Add(new Game(
                    (int)game.Id,
                    (int)game.PlayerMax,
                    (int)game.TurnMax,
                    (int)game.StartBudget,
                    compType
                    ));
            
            }*/
            return Initial;
        }

        public static void SetGame(Game game)
        {
            Serializer.SaveUWP("server.json", game); 
        }

        public static InitGame SyncLoop(Game game, Company company)
        {
            InitGame parameters = new InitGame();
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
                    System.Threading.Thread.Sleep(1000);
                
                    loop++;
                }
                parameters.Game = game;
                parameters.Company = company;

            }

            return parameters;
        }

        // méthode qui maj le nombre de devops recruter
        public static string UpdateDevops(Company company)
        {
            int total = company.StaffMembers.Count;
            string devops = total.ToString();
            return devops = total.ToString();
        }
         
        public static void StartClient()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[4096];

            // Connect to a remote device.  
            try
            {

                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1000);

                // Create a TCP/IP  socket.  
                Socket sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    sender.Connect(ipAddress, 1000);/////////////////////////////////////////////   UN THREAD

                    // Receive the response from the remote device.  
                    int bytesRec = sender.Receive(bytes);
                    string msgServer = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    JsonDocument document = JsonDocument.Parse(msgServer);
                    JsonElement root = document.RootElement;
                    JsonElement dataElement = root.GetProperty("data");
                    JsonElement gamesElement = dataElement.GetProperty("game");

                    Initial = JsonConvert.DeserializeObject<List<Game>>(gamesElement.ToString());

                    var t = new Thread(() =>
                    {
                        while (true)
                        {
                            

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

    }
}
