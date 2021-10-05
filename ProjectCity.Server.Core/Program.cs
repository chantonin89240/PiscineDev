﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProjectCity.EntitiesShare;
using ProjectCity.Server.Services;
using ProjectCity.VM;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader r = new StreamReader("server.json");
            string text = r.ReadToEnd();

            StartAsynchroneClient(text);
            //StartAsynchroneServer();


        }

        static void StartAsynchroneClient(string text)
        {
            Console.WriteLine("Attente de 100ms"); //Pour ne pas se connecter à un serveur pas encore prêt
            System.Threading.Thread.Sleep(100);

            string serverip = "172.16.30.14";
            int serverport = 1000;

            //Connexion
            IPAddress IP = IPAddress.Parse(serverip);

            //Je veux une socket internet de type TCP
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Connexion au serveur {0}:{1}...", serverip, serverport);

            try
            {
                socket.Connect(IP, serverport);
                Console.WriteLine("Connecté Ecrire ci dessous vos commandes:");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erreur de connexion: {0}", e.Message);
            }


            //échanges(le client écrit en premier)
            byte[] data = new byte[1024]; // création d'un buffer

            //while (true)
            //{
            //    //attente d'une entrée utilisateur
            //    //string text = Console.ReadLine();
            //    if (text == "exit") break;

                // envoi de la commande
                byte[] msg = System.Text.Encoding.UTF8.GetBytes(text); //conversion string en tableau
                int size = socket.Send(msg);
                //if (size == 0) break;
                Console.WriteLine(">>" + text);

            while (true)
                {

                //réception de la réponse
                size = socket.Receive(data);
                if (size == 0) break;
                string resp = System.Text.Encoding.UTF8.GetString(data, 0, size); //conversion tableau en string
                Console.WriteLine("<<" + resp);

                if (size == 0) break;

                //traitement de la réponse (type de données)
                //switch(resp):
                //case()
            }

            Console.WriteLine("Déconnexion");

            Console.ReadKey();
            //Service serv = new Service();
            //serv.GenerateDeveloper(2);
            //StartAsynchroneServer();

        }

        static void StartAsynchroneServer()
        {
            int serverport = 1000;

            Console.WriteLine("Démarrage du serveur monouser sur le port {0}...", serverport);

            //IPAddress ipAddress = IPAddress.Loopback;
            IPAddress ipAddress = IPAddress.Parse("172.16.30.10");

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.IP);

            byte[] data = new Byte[1024];

            try
            {
                //mise en écoute
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, serverport);
                listener.Bind(localEndPoint);
                listener.Listen(1);
                Console.WriteLine("Attente du client...");

                //connexion entrante
                Socket client = listener.Accept();
                string clientIP = ((System.Net.IPEndPoint)client.RemoteEndPoint).Address.ToString();
                Console.WriteLine("Client connecté: {0}", clientIP);

                //Traitement des données avec les actions à mener

                //échanges (le client écrit en premier
                while (true)
                {
                    //attente réception
                    int size = client.Receive(data);
                    if (size == 0) break;
                    string text = System.Text.Encoding.UTF8.GetString(data, 0, size);
                    Console.WriteLine("<< " + text);

                    //traitement des données client
                    //JObject json = JObject.Parse(text);
                    Game game = JsonConvert.DeserializeObject<Game>(text);
                   


                    //envoie reponse
                    string resp = "Ceci est la réponse du serveur";
                    switch (text)
                    {
                        default:
                            break;
                    }
                    byte[] msg = System.Text.Encoding.UTF8.GetBytes(resp);
                    size = client.Send(msg);
                    if (size == 0) break;
                    Console.WriteLine(">> " + resp);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}