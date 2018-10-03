using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using Shapes.Commands;

namespace Test
{
    [TestClass]
    public class VertexTest
    {
        #region AddVertexCommandTest

        [TestMethod]
        public void ExecuteTest()
        {
            Pentagon basePentagon = new Pentagon();
            Vertex[] edges = new Vertex[3];
            for (int i = 0; i < 3; i++)
            {
                basePentagon.Points[i] = edges[i].Location;
            }
            Vertex added = new Vertex();
            Shapes.Commands.Vertex.AddVertex testCommand = 
                new Shapes.Commands.Vertex.AddVertex(basePentagon, added);
            testCommand.Execute();
            Assert.AreEqual(added, basePentagon.Points[4]);
        }
        [TestMethod]
        public void UnExecuteTest()
        {
            Pentagon basePentagon = new Pentagon();
            Vertex[] edges = new Vertex[3];
            for (int i = 0; i < 3; i++)
            {
                basePentagon.Points[i] = edges[i].Location;
            }
            Vertex added = new Vertex();
            Shapes.Commands.Vertex.AddVertex testCommand =
                new Shapes.Commands.Vertex.AddVertex(basePentagon, added);
            testCommand.Execute();
            testCommand.UnExecute();
            Assert.AreEqual(new System.Windows.Point(), basePentagon.Points[4]);
        }
            #endregion
        }
}
