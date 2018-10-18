using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using Shapes.Commands;
using System.Text;

namespace Test
{
    [TestClass]
    public class UndoRedoManagerTest
    {
        bool checker;
        [TestMethod]
        public void ConstructorTest()
        {
            UndoRedoManager urm = new UndoRedoManager();

            Assert.IsFalse(urm.CanUndo);
            Assert.IsFalse(urm.CanRedo);

            Assert.AreEqual(0, urm.UndoItems.Count());
            Assert.AreEqual(0, urm.RedoItems.Count());
        }

        [TestMethod]
        public void CanUndoTest()
        {
            UndoRedoManager urm = new UndoRedoManager();

            Assert.IsFalse(urm.CanUndo);

            Canvas testCanvas = new Canvas();
            Vertex first = new Vertex();
            Shapes.Commands.Vertex.AddVertex testCommand =
                new Shapes.Commands.Vertex.AddVertex(testCanvas, first, urm);
            urm.Execute(testCommand);

            Assert.IsTrue(urm.CanUndo);

            urm.Undo();

            Assert.IsFalse(urm.CanUndo);

            urm.Redo();

            Assert.IsTrue(urm.CanUndo);
        }
        [TestMethod]
        public void CanRedoTest()
        {
            UndoRedoManager urm = new UndoRedoManager();

            Assert.IsFalse(urm.CanRedo);

            Canvas testCanvas = new Canvas();
            Vertex first = new Vertex();
            Shapes.Commands.Vertex.AddVertex testCommand =
                new Shapes.Commands.Vertex.AddVertex(testCanvas, first, urm);

            urm.Execute(testCommand);
            Assert.IsFalse(urm.CanRedo);

            urm.Undo();

            Assert.IsTrue(urm.CanRedo);

            urm.Redo();

            Assert.IsFalse(urm.CanRedo);
        }
        [TestMethod]
        public void UndoTest()
        {
            UndoRedoManager manager = new UndoRedoManager();
            Canvas testCanvas = new Canvas();
            Vertex first = new Vertex();
            Shapes.Commands.Vertex.AddVertex testCommand =
                new Shapes.Commands.Vertex.AddVertex(testCanvas, first, manager);
            manager.Execute(testCommand);
            manager.Undo();
            Assert.AreEqual(0, testCanvas.Count);
            Configuration.UndoAll(manager);
        }
        [TestMethod]
        public void RedoTest()
        {
            UndoRedoManager manager = new UndoRedoManager();
            Canvas testCanvas = new Canvas();
            Vertex first = new Vertex();
            Shapes.Commands.Vertex.AddVertex testCommand =
                new Shapes.Commands.Vertex.AddVertex(testCanvas, first, manager);
            manager.Execute(testCommand);
            manager.Undo();
            manager.Redo();
            Assert.AreEqual(1, testCanvas.Count);
            Configuration.UndoAll(manager);
        }
        [TestMethod]
        public void UndoItemsTest()
        {
            UndoRedoManager manager = new UndoRedoManager();
            Canvas testCanvas = new Canvas();
            for (int i = 0; i < Pentagon.NUM_OF_EDGE_IN_PENTAGON; i++)
            {
                manager.Execute(
                    new Shapes.Commands.Vertex.AddVertex(testCanvas, new Vertex(), manager));
            }
            CollectionAssert.AreEqual(new string[]
            { "Pentagon added", "Vertex added", "Vertex added", "Vertex added", "Vertex added" },
            manager.UndoItems.ToArray());
            Configuration.UndoAll(manager);
        }
        [TestMethod]
        public void ExecuteTest()
        {
            UndoRedoManager manager = new UndoRedoManager();
            Canvas testCanvas = new Canvas();
            Vertex first = new Vertex();
            Shapes.Commands.Vertex.AddVertex testCommand =
                new Shapes.Commands.Vertex.AddVertex(testCanvas, first, manager);
            manager.Execute(testCommand);
            Assert.AreEqual(1, testCanvas.Count);
            Configuration.UndoAll(manager);
        }
        [TestMethod]
        public void RedoItemsTest()
        {
            int undoCommands = 2;
            UndoRedoManager manager = new UndoRedoManager();
            Canvas testCanvas = new Canvas();
            for (int i = 0; i < Pentagon.NUM_OF_EDGE_IN_PENTAGON; i++)
            {
                manager.Execute(
                    new Shapes.Commands.Vertex.AddVertex(testCanvas, new Vertex(), manager));
            }
            for (int i = 0; i < undoCommands; i++)
            {
                manager.Undo();
            }
            StringBuilder sb = new StringBuilder();
            foreach (string item in manager.RedoItems)
            {
                sb.AppendFormat($"{item} ");
            }
            CollectionAssert.AreEqual(new string[]
            { "Vertex added", "Pentagon added"  },
            manager.RedoItems.ToArray());
            Configuration.UndoAll(manager);
        }
        [TestMethod]
        public void StateChangeTest()
        {
            UndoRedoManager manager = new UndoRedoManager();
            Canvas testCanvas = new Canvas();
            manager.PropertyChanged += Manager_PropertyChanged;
            Assert.IsFalse(manager.CanUndo);
            checker = manager.CanUndo;
            manager.Execute(
                    new Shapes.Commands.Vertex.AddVertex(testCanvas, new Vertex(), manager));
            Assert.IsTrue(checker && manager.CanUndo);
            Configuration.UndoAll(manager);
        }
        [TestMethod]
        public void ClearTest()
        {
            UndoRedoManager manager = new UndoRedoManager();

            Canvas testCanvas = new Canvas();
            Vertex first = new Vertex();
            Shapes.Commands.Vertex.AddVertex testCommand =
                new Shapes.Commands.Vertex.AddVertex(testCanvas, first, manager);


            Assert.AreEqual(0, manager.UndoItems.Count());
            Assert.AreEqual(0, manager.RedoItems.Count());

            manager.Execute(testCommand);
            manager.Execute(testCommand);
            manager.Execute(testCommand);

            manager.Undo();

            Assert.AreEqual(2, manager.UndoItems.Count());
            Assert.AreEqual(1, manager.RedoItems.Count());

            manager.Clear();

            Assert.AreEqual(0, manager.UndoItems.Count());
            Assert.AreEqual(0, manager.RedoItems.Count());
        }

        private void Manager_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CanUndo")
            {
                checker = true;
            }
            
        }
    }
}
