using Newtonsoft.Json;
using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public static Socket sender { get; set; }
        public static List<Game> Initial { get; set; }


        public static List<Game> Games()
        {
            return Initial;
        }

        public static void SetGame(Game game)
        {
            Serializer.SaveUWP("server.json", game); 
        }

        public static InitGame SyncLoop(Game game)
        {
            InitGame parameters = new InitGame();
            int loop = 0;
            if (game != null)
            {
                Company companyPlayer2 = new Company();

                while (game.Players.Count < game.PlayerMax)
                {
                    // ici on ajoute les joueurs via le server
                    if (loop == 2)
                    {
                        game.Players.Add(new Player(2, "Anto", "Dec", "pseudo2"));
                        companyPlayer2.CompanyType = game.CompanyType;
                        companyPlayer2.Name = companyPlayer2.CompanyType.Title + " de "  + game.Players.First(p => p.Id == 2).Pseudo;
                    }

                    //Game = Service.Games("JSon/server.json").Find(g => g.Id == Game.Id);                   
                    System.Threading.Thread.Sleep(1000);
                
                    loop++;
                }
                parameters.Game = game;
                parameters.Game.Companies.Add(companyPlayer2);

            }

            return parameters;
        }

        // méthode qui maj le nombre de devops recruter
        public static string UpdateDevops(Company company)
        {
            int total = company.StaffMembers.Count;
            return total.ToString();
        }
         
        public static void StartClient()
        {
            // Data buffer for incoming data.  
            byte[] bytes = new byte[4096];
            

            // Connect to a remote device.  
            try
            {
                // Socket IP + port serveur
                IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 1000);

                // Creation d'une socket TCP/IP
                sender = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                try
                {
                    //Demande de connection au serveur distant
                    sender.Connect(ipAddress, 1000);

                    // Réception d'une réponse serveur distant  
                    int bytesRec = sender.Receive(bytes);
                    string msgServer = Encoding.UTF8.GetString(bytes, 0, bytesRec);

                    // Déserialisation de la réponse et conversion en objet
                    Initial = Serializer.JsonObjectToObject<List<Game>>(msgServer, "Game");

                    // Instanciation d'un thread d'écoute 
                    var t = new Thread(() =>
                    {
                        // boucle infini qui conserve la connection au serveur
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


        // Fonction d'envoi au serveur appellée coté client à chaque événement client le nécessitant
        public static void SendToServer(String data)
        {
            // instanciation d'un buffer ou tampon mémoire
            byte[] bytes = new Byte[4096];

            bytes = System.Text.Encoding.UTF8.GetBytes(data);

            // Envoi du message
            sender.Send(bytes);
        }

        // Fonction qui retourne une liste de developer, si il s'agit du premier tour de la parti le nombre de developer est mis en fonction du nombre de joueur 
        public static List<Developer> ListeDevops(Game game)
        {
            List<Developer> ListeDevops = new List<Developer>();
            int Tour = game.Turns.Count;
            int NbTotal;

            if (Tour == 0)
            {
                NbTotal = game.PlayerMax;
                Server.Services.Service.GenerateDeveloper(NbTotal);
            }
            else
            {
                Random NbDev = new Random();
                NbTotal = NbDev.Next(1, 4);

                Server.Services.Service.GenerateDeveloper(NbTotal);
            }
            
            return ListeDevops;
        }

    }
}
