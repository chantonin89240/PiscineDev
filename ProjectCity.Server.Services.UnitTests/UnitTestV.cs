using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectCity.Server.Services;
using System.Collections.Generic;
using System.Linq;


namespace ProjectCity.Client.Services.UnitTests
{
    [TestClass]
    public class UnitTestV
    {
        [TestMethod]
        public void TestFromJs()
        {
            Assert.IsTrue(Service.GetLevels().Count() != 0);
            Assert.IsTrue(Service.GetFields().Count() != 0);
            Assert.IsTrue(Service.GetSchools().Count() != 0);

        }

    }
}
