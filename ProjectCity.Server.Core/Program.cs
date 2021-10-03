using ProjectCity.Server.Services;
using ProjectCity.VM;
using System;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Service serv = new Service();
            serv.GenerateDeveloper(2);
            //StartAsynchroneServer();

        }

        static void StartAsynchroneServer()
        {
            int serverport = 1000;

            Console.WriteLine("Démarrage du serveur monouser sur le port {0}...", serverport);

            //IPAddress ipAddress = IPAddress.Loopback;
            IPAddress ipAddress = IPAddress.Parse("172.16.30.13");

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.IP);

            byte[] data = new Byte[1024];

            try
            {
                //mise en écoute
                IPEndPoint localEndPoint = new IPEndPoint(ipAddress, serverport);
                listener.Bind(localEndPoint);
                listener.Listen();
                Console.WriteLine("Attente du client...");

                //connexion entrante
                Socket client = listener.Accept();
                string clientIP = ((System.Net.IPEndPoint)client.RemoteEndPoint).Address.ToString();
                Console.WriteLine("Client connecté: {0}", clientIP);

                //échanges (le client écrit en premier
                while (true)
                {
                    //attente réception
                    int size = client.Receive(data);
                    if (size == 0) break;
                    string text = System.Text.Encoding.UTF8.GetString(data, 0, size);
                    Console.WriteLine("<< " + text);

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