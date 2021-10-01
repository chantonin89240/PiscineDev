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
        public static List<Game> Games()
        {
            List<Game> games = new List<Game>();

            var dataGame = Serializer.FromJson<dynamic>("JSon/Data.json");

            //games.Add(x["data"]["game"][0]);


            foreach (var game in dataGame.data.game)
            {
                games.Add(new Game()
                {
                    Id = game.id,
                    PlayerMax = game.playerMax,
                    TurnMax = game.turnMax,
                    StartBudget = game.startBudget
                });
            }
            return games;
        }

        public static void SetGame(Game game)
        {
            Serializer.ToJSon("JSon/Activity.json", game);
        }
    }
}
