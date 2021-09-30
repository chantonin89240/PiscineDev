using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //StartAsynchroneClient();
            List<Training> listeForma = Call.FromJson<List<Training>>("formation");

            //Console.WriteLine("Hello World!");
        }

        static void StartAsynchroneClient()
        {
            Console.WriteLine("Attente de 100ms"); //Pour ne pas se connecter à un serveur pas encore prêt
            System.Threading.Thread.Sleep(100);

            string serverip = "127.0.0.1";
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

            while (true)
            {
                //attente d'une entrée utilisateur
                string text = Console.ReadLine();
                if (text == "exit") break;

                // envoi de la commande
                byte[] msg = System.Text.Encoding.UTF8.GetBytes(text); //conversion string en tableau
                int size = socket.Send(msg);
                if (size == 0) break;
                Console.WriteLine(">>" + text);

                //réception de la réponse
                size = socket.Receive(data);
                if (size == 0) break;
                string resp = System.Text.Encoding.UTF8.GetString(data, 0, size); //conversion tableau en string
                Console.WriteLine("<<" + resp);

                //traitement de la réponse (type de données)
                //switch(resp):
                //case()
            }
            Console.WriteLine("Déconnexion");
        }
    }
}