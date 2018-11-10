using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiDriver;

namespace Test
{
    [TestClass]
    public class ChampionTest
    {
        [TestMethod]
        public void NumberTest()
        {
            int expectedNumber = 25;

            Champion сhampion = new Champion(25, "Steve", 57);
            Assert.IsTrue(сhampion.Number == expectedNumber);           
        }

        [TestMethod]
        public void NameTest()
        {
            string expectedName = "Steve";

            Champion сhampion = new Champion(25, "Steve", 57);
            Assert.IsTrue(сhampion.Name == expectedName);
        }

        [TestMethod]
        public void ScoreTest()
        {
            double expectedScore = 57;

            Champion сhampion = new Champion(25, "Steve", 57);
            Assert.IsTrue(сhampion.Score == expectedScore);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            int expectedNumber = 25;
            string expectedName = "Steve";
            double expectedScore = 57;

            Champion сhampion = new Champion(25, "Steve", 57);
            Assert.IsTrue(сhampion.Number == expectedNumber
                       && сhampion.Name == expectedName
                       && сhampion.Score == expectedScore);
        }

    }
}

