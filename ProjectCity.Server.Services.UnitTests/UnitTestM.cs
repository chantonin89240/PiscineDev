using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProjectCity.Server.Services;
using System.Linq;

namespace ProjectCity.Server.Services.UnitTests
{
    [TestClass]
    public class UnitTestM
    {
        [TestMethod]
        public void TestGenerateDev()
        {
            Assert.AreEqual(2, Service.GenerateDeveloper(2).Count);

        }

        [TestMethod]
        public void TestGetFields()
        {
            Assert.IsNotNull(Service.GetFields());
            Assert.IsTrue(Service.GetFields().Count(field => field.Id == 0 || field.Title == "") == 0);
        }

        [TestMethod]
        public void TestGetLevels()
        {
            Assert.IsNotNull(Service.GetLevels());
            Assert.IsTrue(Service.GetLevels().Count(level => level.Id == 0 || level.Description == "" || level.Niveau == 0) == 0);
        }

        [TestMethod]
        public void TestGetNameDeveloper()
        {
            Assert.IsNotNull(Service.GetName());
            Assert.IsTrue(Service.GetName().Count(name => name.FirstName == "" || name.LastName == "") == 0);
        }

        [TestMethod]
        public void TestGetCertifications()
        {
            Assert.IsNotNull(Service.GetCertifications());
        }

        [TestMethod]
        public void TestGenerateCertifications()
        {
            Assert.IsTrue(Service.GenerateCertifications(5).Count == 5);
        }

    }
       
}
