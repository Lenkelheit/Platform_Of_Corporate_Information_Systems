using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;

namespace Test
{
    [TestClass]
    public class VertexTest
    {
        [TestMethod]
        public void AllInVertexTest()
        {
            Shapes.Models.Vertex first = new Shapes.Models.Vertex();
            Assert.AreEqual(new System.Windows.Point(0, 0), first.Location);

            Shapes.Models.Vertex second = new Shapes.Models.Vertex
            {
                Location = new System.Windows.Point(-2, 4)
            };
            Assert.AreEqual(new System.Windows.Point(-2, 4), second.Location);

            Shapes.Models.Vertex third = new Shapes.Models.Vertex
            {
                Location = new System.Windows.Point(-2, -5)
            };
            Assert.AreEqual("Vertex", third.Name);

            Shapes.Models.Vertex fourth = new Shapes.Models.Vertex
            {
                Location = new System.Windows.Point(-4, -5)
            };
            Assert.IsTrue(fourth.HitTest(new System.Windows.Point(-4, 0)));

            Assert.IsTrue(fourth.HitTest(new System.Windows.Point(-1, -4)));

            Assert.IsFalse(fourth.HitTest(new System.Windows.Point(3, 1)));

            double distance = Shapes.Models.Vertex.GetDistance(second, third);
            Assert.AreEqual(9, distance);

            distance = Shapes.Models.Vertex.GetDistance(second, fourth);
            Assert.AreEqual(System.Math.Sqrt(85), distance);
        }

        [TestMethod]
        public void SerialiseVertexTest()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Shapes.Models.Vertex));
            Shapes.Models.Vertex vertexForWritingToFile = new Shapes.Models.Vertex
            {
                Location = new System.Windows.Point(2, 7)
            };
            Shapes.Models.Vertex vertexForReadingFromFile;
            string fileName = Configuration.VERTEX_SERIALIZATION_FILE_NAME;

            using (System.IO.FileStream fStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
            {
                xmlFormat.Serialize(fStream, vertexForWritingToFile);
            }
            using (System.IO.FileStream fStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
            {
                vertexForReadingFromFile = (Shapes.Models.Vertex)xmlFormat.Deserialize(fStream);
            }

            Assert.IsTrue(vertexForWritingToFile.Location == vertexForReadingFromFile.Location);
        }

        [TestMethod]
        public void AddVertexCommandTest()
        {
            Shapes.Models.UndoRedoManager manager = new Shapes.Models.UndoRedoManager();
            Shapes.Models.Canvas testCanvas = new Shapes.Models.Canvas();
            Shapes.Models.Vertex first = new Shapes.Models.Vertex();
            Shapes.Models.Vertex second = new Shapes.Models.Vertex();

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
        public void ChangeLocationCommandTest()
        {
            Shapes.Models.UndoRedoManager manager = new Shapes.Models.UndoRedoManager();
            Shapes.Models.Vertex first = new Shapes.Models.Vertex
            {
                Location = new System.Windows.Point(1, 2)
            };
            Assert.AreEqual(new System.Windows.Point(1, 2), first.Location);

            Shapes.Commands.Vertex.ChangeLocation changeLocationCommand =
                  new Shapes.Commands.Vertex.ChangeLocation(first, new System.Windows.Point(5, 6));

            manager.Execute(changeLocationCommand);

            Assert.AreEqual(new System.Windows.Point(5, 6), first.Location);


            manager.Undo();
            Assert.AreEqual(new System.Windows.Point(1, 2), first.Location);

            manager.Redo();
            Assert.AreEqual(new System.Windows.Point(5, 6), first.Location);
        }

        [TestMethod]
        public void RemoveVertexCommandTest()
        {
            Shapes.Models.UndoRedoManager manager = new Shapes.Models.UndoRedoManager();
            Shapes.Models.Canvas canvas = new Shapes.Models.Canvas();
            Shapes.Models.Vertex first = new Shapes.Models.Vertex
            {
                Location = new System.Windows.Point(1, 2)
            };
            Assert.AreEqual(0, canvas.Count);
            Assert.IsFalse(canvas.Contains(first));

            canvas.Add(first);
            Assert.AreEqual(1, canvas.Count);
            Assert.IsTrue(canvas.Contains(first));

            Shapes.Commands.Vertex.RemoveVertex removeVertexCommand =
                  new Shapes.Commands.Vertex.RemoveVertex(canvas, first);

            manager.Execute(removeVertexCommand);

            Assert.AreEqual(0, canvas.Count);
            Assert.IsFalse(canvas.Contains(first));


            manager.Undo();
            Assert.AreEqual(1, canvas.Count);
            Assert.IsTrue(canvas.Contains(first));

            manager.Redo();
            Assert.AreEqual(0, canvas.Count);
            Assert.IsFalse(canvas.Contains(first));
        }
        [TestMethod]
        public void Radius()
        {
            Shapes.Models.Vertex v1 = new Shapes.Models.Vertex();
            Shapes.Models.Vertex v2 = new Shapes.Models.Vertex();

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
