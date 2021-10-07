using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectCity.Client.Services;
using ProjectCity.EntitiesShare;

namespace ProjectCity.Server.Services.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGenerateProjects()
        {
            Assert.IsTrue(Service.GenerateProjects().Count() > 0);
        }
    }
}
