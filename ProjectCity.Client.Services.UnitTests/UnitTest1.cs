using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectCity.EntitiesShare;
using ProjectCity.Server.Services;
using ProjectCity.Client.Services;
using ProjectCity.VM;
using ProjectCity.Client.Services;
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

            Assert.IsTrue(x.Count > 0);
        }

        [TestMethod]
        public void TestGames()
        {
            Assert.IsTrue(Service.Games("JSon/Data.json").Count > 0);
        }

        [TestMethod]
        public void TestSyncLoop()
        {
            Game game = new Game(1, 1, 1, 1, new CompanyType(1, "test", 1));
            game.Players.Add(new Player(1, "test", "test", "test"));
            Company company = new Company();

            Assert.IsTrue(Service.SyncLoop(game, company).GetType() == new InitGame().GetType());
        }

        [TestMethod]
        public void TestUpdateDevops()
        {
            Company company = new Company();
            StaffMember staff = new StaffMember();
            company.StaffMembers.Add(staff);

            Assert.IsTrue(Service.UpdateDevops(company) == "1");
        }

    }
}
