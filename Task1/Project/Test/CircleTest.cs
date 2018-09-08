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
        public void CircleGetPerimetrTest()
        {
            Circle testCircle = new Circle(new Point(2, 2), 3);
            double expectedResult = 2 * 3 * PI;
            Assert.AreEqual(expectedResult, testCircle.GetPerimeter);
        }
    }
}
