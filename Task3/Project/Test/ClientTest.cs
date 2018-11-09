using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiDriver;

namespace Test
{
    [TestClass]
    public class ClientTest
    {
        [TestMethod]
        public void NameTest()
        {
            string expectedName = "Martin";

            Client client = new Client("Martin", "977797");
            Assert.IsTrue(client.Name == expectedName);
        }

        [TestMethod]
        public void PhoneTest()
        {
            string expectedPhone = "977797";

            Client client = new Client("Martin", "977797");
            Assert.IsTrue(client.Phone == expectedPhone);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            string expectedName = "Martin";
            string expectedPhone = "977797";

            Client client = new Client("Martin", "977797");
            Assert.IsTrue(client.Name == expectedName && client.Phone == expectedPhone);
        }
    }
}
