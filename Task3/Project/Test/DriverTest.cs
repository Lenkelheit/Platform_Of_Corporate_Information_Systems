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

            Driver driver = new Driver("Jason", "pa$$word", 76, 100);
            Assert.IsTrue(driver.Name == expectedName);
        }

        [TestMethod]
        public void PasswordTest()
        {
            string expectedPasswword = "pa$$word";

            Driver driver = new Driver("Jason", "pa$$word", 76, 100);
            Assert.IsTrue(driver.Password == expectedPasswword);
        }

        [TestMethod]
        public void BestScoreTest()
        {
            double expectedBestSore = 76;

            Driver driver = new Driver("Jason", "pa$$word", 76, 100);
            Assert.IsTrue(driver.BestScore == expectedBestSore);
        }

        [TestMethod]
        public void TotalScoreTest()
        {
            double expectedTotalSore = 100;
            Driver driver = new Driver("Jason", "pa$$word", 76, 100);
            Assert.IsTrue(driver.TotalScore == expectedTotalSore);
        }

        [TestMethod]
        public void LastScore()
        {
            double expectedLastScore = 80;
            double expectedBestScore = 80;
            double expectedTotalScore = 180;

            Driver driver = new Driver("Jason", "pa$$word", 76, 100);
            driver.LastScore = 80;
            Assert.IsTrue(driver.BestScore == expectedBestScore
                       && driver.TotalScore == expectedTotalScore
                       && driver.LastScore == expectedLastScore);           
        }

        [TestMethod]
        public void ConstrucrtorTest()
        {
            string expectedName = "Jason";
            string expectePassword = "pa$$word";
            double expectedBestScore = 76;
            double expectedTotalScore = 100;
            double expectedLastScore = 0;

            Driver driver = new Driver("Jason", "pa$$word", 76, 100);
            Assert.IsTrue(driver.Name == expectedName 
                       && driver.Password == expectePassword
                       && driver.BestScore == expectedBestScore 
                       && driver.TotalScore == expectedTotalScore
                       && driver.LastScore == expectedLastScore);
        }
    }
}
