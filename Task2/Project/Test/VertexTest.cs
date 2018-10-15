using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using Shapes.Commands;

namespace Test
{
    [TestClass]
    public class VertexTest
    {
        [TestMethod]
        public void Radius()
        {
            Vertex v1 = new Vertex();
            Vertex v2 = new Vertex();

            int startRadiusValue = v1.Radius;

            Assert.AreEqual(startRadiusValue, v1.Radius);
            Assert.AreEqual(startRadiusValue, v2.Radius);

            int newRadiusValue = 8;
            v1.Radius = newRadiusValue;

            Assert.AreEqual(newRadiusValue, v1.Radius);
            Assert.AreEqual(newRadiusValue, v2.Radius);

            v1.Radius = startRadiusValue;
        }
    }
}
