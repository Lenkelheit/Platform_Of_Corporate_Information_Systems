using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxiDriver;

namespace Test
{
    [TestClass]
    public class OrderTest
    {
        [TestMethod]
        public void NumberTest()
        {
            int expectedNumber = 0989997997;
            Client expectedClient = new Client("Martin", "977797");
            Route expectedRoute = new Route("Universitet", "Lybinska", System.TimeSpan.FromHours(2), 113);

            Order order = new Order(expectedNumber, expectedClient, expectedRoute);
            Assert.IsTrue(order.Number == expectedNumber);
        }

        [TestMethod]
        public void ClientTest()
        {
            int expectedNumber = 0989997997;
            Client expectedClient = new Client("Martin", "977797");
            Route expectedRoute = new Route("Universitet", "Lybinska", System.TimeSpan.FromHours(2), 113);

            Order order = new Order(expectedNumber, expectedClient, expectedRoute);
            Assert.IsTrue(order.Client.Name == expectedClient.Name
                       && order.Client.Phone == expectedClient.Phone);
        }

        [TestMethod]
        public void RouteTest()
        {
            int expectedNumber = 0989997997;
            Client expectedClient = new Client("Martin", "977797");
            Route expectedRoute = new Route("Universitet", "Lybinska", System.TimeSpan.FromHours(2), 113);

            Order order = new Order(expectedNumber, expectedClient, expectedRoute);
            Assert.IsTrue(order.Route.StartStreet == expectedRoute.StartStreet
                       && order.Route.EndStreet == expectedRoute.EndStreet
                       && order.Route.Time == expectedRoute.Time
                       && order.Route.Price == expectedRoute.Price);
        }

        [TestMethod]
        public void ConstructorTest()
        {
            int expectedNumber = 0989997997;
            Client expectedClient = new Client("Martin", "977797");
            Route expectedRoute = new Route("Universitet", "Lybinska", System.TimeSpan.FromHours(2), 113);

            Order order = new Order(expectedNumber, expectedClient, expectedRoute);
            Assert.IsTrue(order.Number == expectedNumber
                       && order.Client.Name == expectedClient.Name
                       && order.Client.Phone == expectedClient.Phone
                       && order.Route.StartStreet == expectedRoute.StartStreet
                       && order.Route.EndStreet == expectedRoute.EndStreet
                       && order.Route.Time == expectedRoute.Time
                       && order.Route.Price == expectedRoute.Price);
        }
    }
}
