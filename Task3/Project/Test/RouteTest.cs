using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiDriver;

namespace Test
{
    [TestClass]
    public class RouteTest
    {
        [TestMethod]
        public void StartStreetTest()
        {
            string expectedStartStreet = "Universitet";
            Route route = new Route("Universitet", "Lybinska", System.TimeSpan.FromHours(2), 113);

            Assert.IsTrue(route.StartStreet == expectedStartStreet);
        }

        [TestMethod]
        public void EndStreetTest()
        {
            string expectedEndStreet = "Lybinska";
            Route route = new Route("Universitet", "Lybinska", System.TimeSpan.FromHours(2), 113);

            Assert.IsTrue(route.EndStreet == expectedEndStreet);
        }

        [TestMethod]
        public void TimeTest()
        {
            System.TimeSpan expectedTimeSpan = System.TimeSpan.FromHours(2); 
            Route route = new Route("Universitet", "Lybinska", System.TimeSpan.FromHours(2), 113);

            Assert.IsTrue(route.Time == expectedTimeSpan);
        }

        [TestMethod]
        public void PriceTest()
        {
            double expectedPrice = 113;
            Route route = new Route("Universitet", "Lybinska", System.TimeSpan.FromHours(2), 113);

            Assert.IsTrue(route.Price == expectedPrice);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            string expectedStartStreet = "Universitet";
            string expectedEndStreet = "Lybinska";
            System.TimeSpan expectedTimeSpan = System.TimeSpan.FromHours(2);
            double expectedPrice = 113;

            Route route = new Route("Universitet", "Lybinska", System.TimeSpan.FromHours(2), 113);
            Assert.IsTrue(route.StartStreet == expectedStartStreet
                       && route.EndStreet == expectedEndStreet
                       && route.Time == expectedTimeSpan
                       && route.Price == expectedPrice);

        }
    }
}

