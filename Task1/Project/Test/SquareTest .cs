using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models.Classes;

namespace Test
{
    [TestClass]
    public class SquareTest
    {
        [TestMethod]
        public void SquareGetPerimeterTest()
        {
            Square testSquare = new Square(new Point(2, 4), new Point(4, 2));
            double expectedResult = 8;
            Assert.AreEqual(expectedResult, testSquare.GetPerimeter);
        }
        [TestMethod]
        public void SquareGetSquareTest()
        {
            Square testSquare = new Square(new Point(2, 4), new Point(4, 2));
            double expectedResult = 4;
            Assert.AreEqual(expectedResult, testSquare.GetSquare);
        }
        [TestMethod]
        public void SquareGetBottomRightPointTest()
        {
            Square testSquare = new Square(new Point(2, 4), new Point(4, 2));
            Point expectedResult = new Point(4, 2);
            Assert.AreEqual(expectedResult, testSquare.BottomRightPoint);
        }
        [TestMethod]
        public void SquareGetTopLeftPointTest()
        {
            Square testSquare = new Square(new Point(2, 4), new Point(4, 2));
            Point expectedResult = new Point(2 ,4);
            Assert.AreEqual(expectedResult, testSquare.TopLeftPoint);
        }
        [TestMethod]
        public void SquareConstructorTest()
        {
            Square testSquare = new Square(new Point(2, 4), new Point(4, 2));
            Point expectedBottomRightPoint = new Point(4, 2);
            Point expectedTopLeftPoint = new Point(2, 4);
            Point expectedCenter = new Point(2, 2);
            Assert.IsTrue (expectedBottomRightPoint.X == testSquare.BottomRightPoint.X &&
                expectedBottomRightPoint.Y == testSquare.BottomRightPoint.Y &&
                expectedTopLeftPoint.X == testSquare.TopLeftPoint.X &&
                expectedTopLeftPoint.Y == testSquare.TopLeftPoint.Y);
        }
    }
}
