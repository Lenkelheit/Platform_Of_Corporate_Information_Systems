using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using Shapes.Commands;

namespace Test
{
    [TestClass]
    public class UndoRedoManagerTest
    {
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

        }
        [TestMethod]
        public void CanRodoTest()
        {
            UndoRedoManager urm = new UndoRedoManager();

            Assert.IsFalse(urm.CanRedo);
        }
        [TestMethod]
        public void UndoTest()
        {
            UndoRedoManager urm = new UndoRedoManager();
            
        }
        [TestMethod]
        public void RedoTest()
        {
            UndoRedoManager urm = new UndoRedoManager();
            
        }
        [TestMethod]
        public void UndoItemsTest()
        {
            UndoRedoManager urm = new UndoRedoManager();
            
        }
        [TestMethod]
        public void ExecuteTest()
        {
            UndoRedoManager urm = new UndoRedoManager();
            
        }
        [TestMethod]
        public void RedoItemsTest()
        {
            UndoRedoManager urm = new UndoRedoManager();
            
        }
        [TestMethod]
        public void StateChangeTest()
        {
            UndoRedoManager urm = new UndoRedoManager();
            
        }
    }
}
