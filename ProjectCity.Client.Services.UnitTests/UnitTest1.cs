using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectCity.EntitiesShare;
using ProjectCity.Server.Services;
using ProjectCity.Client.Services;
using ProjectCity.VM;
using System.Collections.Generic;

namespace ProjectCity.Client.Services.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestFromJson()
        {
            var x = Serializer.FromJson<dynamic>("../../../../ProjectCity.VM/JSon/Data.json");

            List<Game> games = new List<Game>();

            //games.Add(x["data"]["game"][0]);


            games.Add(new Game() {
                Id = x.data.game[0].id
            });
        }

    }
}
