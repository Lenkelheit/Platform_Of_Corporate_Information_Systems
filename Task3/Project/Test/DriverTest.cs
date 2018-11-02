using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiDriver;

namespace Test
{
    [TestClass]
    public class DriverTest
    {       
        [TestMethod]
        public void NameTest()
        {
            string expectedName = "Jason";

            Driver driver = new Driver("Jason", "pa$$word", 100, 76);
            Assert.IsTrue(driver.Name == expectedName);
        }

        [TestMethod]
        public void PasswordTest()
        {
            string expectedPasswword = "pa$$word";

            Driver driver = new Driver("Jason", "pa$$word", 100, 76);
            Assert.IsTrue(driver.Password == expectedPasswword);
        }

        [TestMethod]
        public void BestScoreTest()
        {
            double expectedBestSore = 100;

            Driver driver = new Driver("Jason", "pa$$word", 100, 76);
            Assert.IsTrue(driver.BestScore == expectedBestSore);
        }

        [TestMethod]
        public void TotalScoreTest()
        {
            double expectedTotalSore = 76;

            Driver driver = new Driver("Jason", "pa$$word", 100, 76);
            Assert.IsTrue(driver.TotalScore == expectedTotalSore);
        }

        [TestMethod]
        public void ConstrucrtorTest()
        {
            string expectedName = "Jason";
            string expectePassword = "pa$$word";
            double expectedBestScore = 100;
            double expectedTotalScore = 76;

            Driver driver = new Driver("Jason", "pa$$word", 100, 76);
            Assert.IsTrue(driver.Name == expectedName 
                       && driver.Password == expectePassword
                       && driver.BestScore == expectedBestScore 
                       && driver.TotalScore == expectedTotalScore);
        }
    }
}
