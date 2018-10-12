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
        public void AddVertexTest()//цей тест валиться при запуску всіх тестів ібо не занулюється статична NumberOfVertex
        {
            UndoRedoManager manager = new UndoRedoManager();
            Canvas testCanvas = new Canvas();
            Vertex first = new Vertex();
            Vertex second = new Vertex();

            Assert.AreEqual(0, testCanvas.Count);
            Shapes.Commands.Vertex.AddVertex testCommand = 
                new Shapes.Commands.Vertex.AddVertex(testCanvas, first, manager);
             
            manager.Execute(testCommand);
            Assert.AreEqual(1, testCanvas.Count);

            manager.Undo();
            Assert.AreEqual(0, testCanvas.Count);

            manager.Redo();
            Assert.AreEqual(1, testCanvas.Count);

            manager.Execute(
                new Shapes.Commands.Vertex.AddVertex(testCanvas, second, manager));
            Assert.AreEqual(2, testCanvas.Count);

            manager.Undo();
            manager.Undo();
            Assert.AreEqual(0, testCanvas.Count);

            manager.Redo();
            Assert.AreEqual(1, testCanvas.Count);

            Configuration.UndoAll(manager);
        }



        [TestMethod]
        public void ExecuteTest()
        {

        }
        [TestMethod]
        public void UnExecuteTest()
        {

        }
    }
}
