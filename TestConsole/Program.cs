using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            InitGame test = new InitGame();

            string json = Serializer.ObjectToJsonText(test);

            

            Console.WriteLine(new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds());

            Console.ReadKey();
        }
    }
}
