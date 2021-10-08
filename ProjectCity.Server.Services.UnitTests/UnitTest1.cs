using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectCity.Client.Services;
using ProjectCity.EntitiesShare;
using ProjectCity.VM;
using System.Collections.Generic;

namespace ProjectCity.Server.Services.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGenerateProjects()
        {
            Assert.IsTrue(Service.GenerateProjects().Count > 0);
        }

        [TestMethod]
        public void TestGenerateTrainings()
        {
            Service.GenerateTraining();
            Assert.IsTrue(Service.GetTraining().Count > 0);
        }

        [TestMethod]
        public void TestGenerateEvents()
        {
            Assert.IsTrue(Service.GenerateEvents().Count > 0);
        }
    }
}
