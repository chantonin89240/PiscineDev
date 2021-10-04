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
            var dataGame = Serializer.FromJson<dynamic>("JSon/Data.json");
            List<Game> games = new List<Game>();
           
            foreach (var game in dataGame.data.game)
            {
                games.Add(new Game()
                {
                    Id = game.id,
                    PlayerMax = game.playerMax,
                    TurnMax = game.turnMax,
                    StartBudget = game.startBudget,
                    CompanyType = new CompanyType()
                    {
                        Id = game.companyType.id,
                        Title = game.companyType.title,
                        SalariesLimite = game.companyType.salariesLimite,

                    }
            });
            }
            return games;
        }

        public static void SetGame(Game game)
        {
            Serializer.ToJSon("D:/JSon/Activity2.json", game);
        }
    }
}
