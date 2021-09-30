using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCity.Client.Services
{
    public class Service
    {
        public List<Game> Games()
        {
            List<Game> games = new List<Game>();

            var dataGame = Serializer.FromJson<dynamic>("../../../../ProjectCity.VM/JSon/Data.json");

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
    }
}
