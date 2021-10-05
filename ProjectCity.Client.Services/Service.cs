using Newtonsoft.Json;
using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using static System.Net.Mime.MediaTypeNames;


namespace ProjectCity.Client.Services
{
    public partial class Service
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


    }
}
