using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models.Classes;
using static System.Math;

namespace Test
{
    [TestClass]
    public class CircleTest
    {
        [TestMethod]
        public void CircleGetPerimeterTest()
        {
            Circle testCircle = new Circle(new Point(2, 2), 3);
            double expectedResult = 2 * 3 * PI;
            Assert.AreEqual(expectedResult, testCircle.GetPerimeter);
        }
        [TestMethod]
        public void CircleGetSquareTest()
        {
            Circle testCircle = new Circle(new Point(2, 2), 3);
            double expectedResult = 3 * 3 * PI;
            Assert.AreEqual(expectedResult, testCircle.GetSquare);
        }
        [TestMethod]
        public void CircleGetRadiusTest()
        {
            Circle testCircle = new Circle(new Point(2, 2), 3);
            double expectedResult = 3;
            Assert.AreEqual(expectedResult, testCircle.Radius);
        }
        [TestMethod]
        public void CircleGetCenterTest()
        {
            Circle testCircle = new Circle(new Point(2, 2), 3);
            Point expectedResult = new Point(2, 2);
            Assert.AreEqual(expectedResult, testCircle.Center);
        }
        [TestMethod]
        public void CircleConstructorTest()
        {
            Circle testCircle = new Circle(new Point(2, 2), 3);
            double expectedRadius = 3;
            Point expectedCenter = new Point(2, 2);
            Assert.IsTrue (expectedCenter.X == testCircle.Center.X &&
                expectedCenter.Y == testCircle.Center.Y &&
                expectedRadius == testCircle.Radius);
        }
    }
}

