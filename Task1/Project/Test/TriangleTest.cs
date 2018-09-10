using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models.Classes;
using static System.Math;

namespace Test
{
    [TestClass]
    public class TriangleTest
    {
        [TestMethod]
        public void TriangleGetSqureTest()
        {
            Triangle testTriangle = new Triangle(new Point(0, 0),
                new Point(3, 0), new Point(0, 3));
            double expectedResult = 4.5;
            Assert.AreEqual(expectedResult, testTriangle.GetSquare, 10);
        }
        [TestMethod]
        public void TriangleGetPerimeterTest()
        {
            Triangle testTriangle = new Triangle(new Point(0, 0),
                new Point(3, 0), new Point(0, 3));
            double expectedResult = Sqrt(18) + 6;
            Assert.AreEqual(expectedResult, testTriangle.GetPerimeter);
        }
    }
}
