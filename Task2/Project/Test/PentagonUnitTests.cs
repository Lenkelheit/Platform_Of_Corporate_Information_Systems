using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;

namespace Test
{
    [TestClass]
    class PentagonUnitTests
    {
        Pentagon test = new Pentagon();
        [TestMethod]
        void ColorPropertyUnitTest()
        {
            test.Color = System.Windows.Media.Color.FromRgb(100, 100, 100);
            Assert.AreEqual(test.Color, System.Windows.Media.Color.FromRgb(100, 100, 100));
        }

        [TestMethod]
        void StrokeColorPropertyUnitTest()
        {
            test.StrokeColor = System.Windows.Media.Color.FromRgb(100, 100, 100);
            Assert.AreEqual(test.StrokeColor, System.Windows.Media.Color.FromRgb(100, 100, 100));
        }
    }
}
