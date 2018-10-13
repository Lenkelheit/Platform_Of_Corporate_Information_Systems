using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using System.Xml.Serialization;
using System.Linq;

namespace Test
{
    [TestClass]
    public class PentagonTest
    {
        Pentagon test = new Pentagon();
        #region PropertiesTest
        [TestMethod]
        public void ColorPropertyUnitTest()
        {
            test.Color = System.Windows.Media.Color.FromRgb(100, 100, 100);

            Assert.AreEqual(test.Color, System.Windows.Media.Color.FromRgb(100, 100, 100));
        }
        [TestMethod]
        public void StrokeColorPropertyUnitTest()
        {
            test.StrokeColor = System.Windows.Media.Color.FromRgb(100, 100, 100);
            Assert.AreEqual(test.StrokeColor, System.Windows.Media.Color.FromRgb(100, 100, 100));
        }
        [TestMethod]
        public void StrokeThicknessPropertyUnitTest()
        {
            test.StrokeThickness = 10;
            Assert.AreEqual(test.StrokeThickness, 10);
        }
        [TestMethod]
        public void OpacityPropertyUnitTest()
        {
            test.Opacity = 10;
            Assert.AreEqual(test.Opacity, 10);
        }
        [TestMethod]
        public void PointsUnitTest()
        {
            test.Points = new System.Windows.Point[5]
                {new System.Windows.Point(2 ,4),
                new System.Windows.Point(3 ,5),
                new System.Windows.Point(4 ,6),
                new System.Windows.Point(5 ,7),
                new System.Windows.Point(6 ,8)};
            if (test.Points[0] == new System.Windows.Point(2, 4) ||
                test.Points[1] == new System.Windows.Point(3, 5) ||
                test.Points[2] == new System.Windows.Point(4, 6) ||
                test.Points[3] == new System.Windows.Point(5, 7) ||
                test.Points[4] == new System.Windows.Point(6, 8))
            {
                Assert.IsTrue(true);
            }
        }
        #endregion

        [TestMethod]
        public void SerialiseUnitTest()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Pentagon),
               new System.Type[] { typeof(System.Windows.Media.Color), typeof(System.Windows.Point[]) });
            Pentagon temp = new Pentagon();
            string fileName = Configuration.PENTAGON_SERIALIZATION_FILE_NAME;
            temp.Points = test.Points;
            temp.Color = test.Color;
            temp.StrokeColor = test.StrokeColor;
            temp.Opacity = test.Opacity;
            temp.StrokeThickness = test.StrokeThickness;
            using (System.IO.Stream fStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None))
            {
                xmlFormat.Serialize(fStream, temp);
            }
            using (System.IO.Stream fStream = new System.IO.FileStream(fileName,
               System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
            {
                test = (Pentagon)xmlFormat.Deserialize(fStream);
            }
            if (temp.Points == test.Points &&
            temp.Color == test.Color &&
            temp.StrokeColor == test.StrokeColor &&
            temp.Opacity == test.Opacity &&
            temp.StrokeThickness == test.StrokeThickness)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void HitTest()
        {
            Pentagon p = new Pentagon()
            {
                Points = new System.Windows.Point[5]
                {
                    new System.Windows.Point(1, 0),
                    new System.Windows.Point(0, 3),
                    new System.Windows.Point(3, 5),
                    new System.Windows.Point(5, 2),
                    new System.Windows.Point(1, 0)
                }
            };

            Assert.IsFalse(p.HitTest(new System.Windows.Point(0, 0)));
            Assert.IsTrue(p.HitTest(new System.Windows.Point(2, 2)));
        }

        [TestMethod]
        public void RemoveCommandTest()
        {
            UndoRedoManager manager = new UndoRedoManager();
            Pentagon first = new Pentagon();
            Pentagon second = new Pentagon();
            Pentagon third = new Pentagon();
            Canvas baseCanvas = new Canvas();

            Assert.AreEqual(0, baseCanvas.Count);



            baseCanvas.Add(second);
            Assert.AreEqual(1, baseCanvas.Count);

            Shapes.Commands.Pentagon.RemovePentagon testCommand =
                  new Shapes.Commands.Pentagon.RemovePentagon(baseCanvas, second);

            manager.Execute(testCommand);

            Assert.AreEqual(0, baseCanvas.Count);


            manager.Undo();

            Assert.AreEqual(1, baseCanvas.Count);
            Assert.AreEqual(baseCanvas[0], second);

            manager.Redo();
            Assert.AreEqual(0, baseCanvas.Count);
        }

        [TestMethod]
        public void AddPentagonCommandTest()
        {
            UndoRedoManager manager = new UndoRedoManager();
            Canvas canvas = new Canvas();
            Assert.AreEqual(0, canvas.Count);

            Pentagon first;
            Vertex[] arrVertices = new Vertex[Pentagon.NUM_OF_EDGE_IN_PENTAGON];
            arrVertices[0] = new Vertex
            {
                Location = new System.Windows.Point(0, 1)
            };
            arrVertices[1] = new Vertex
            {
                Location = new System.Windows.Point(3, 1)
            };
            arrVertices[2] = new Vertex
            {
                Location = new System.Windows.Point(1.5, -4)
            };
            arrVertices[3] = new Vertex
            {
                Location = new System.Windows.Point(1, 5)
            };
            arrVertices[4] = new Vertex
            {
                Location = new System.Windows.Point(6, -2)
            };
            for (int i = 0; i < arrVertices.Length; ++i) 
            {
                canvas.Add(arrVertices[i]);
            }
            Assert.AreEqual(5, canvas.Count);
            for (int i = 0; i < arrVertices.Length; ++i) 
            {
                Assert.IsTrue(canvas.Contains(arrVertices[i]));
            }

            Shapes.Commands.Pentagon.AddPentagon addPentagonCommand =
                  new Shapes.Commands.Pentagon.AddPentagon(canvas);

            manager.Execute(addPentagonCommand);

            Assert.AreEqual(1, canvas.Count);
            for (int i = 0; i < arrVertices.Length; ++i) 
            {
                Assert.IsFalse(canvas.Contains(arrVertices[i]));
            }

            Assert.IsTrue(canvas[0] is Pentagon);
            first = (Pentagon)canvas[0];
            for (int i = 0; i < arrVertices.Length; ++i) 
            {
                Assert.IsTrue(first.Points.Contains(arrVertices[i].Location));
            }

            manager.Undo();
            Assert.AreEqual(4, canvas.Count);
            for (int i = 0; i < arrVertices.Length - 1; ++i) 
            {
                Assert.IsTrue(canvas.Contains(arrVertices[i]));
            }

            manager.Redo();
            Assert.AreEqual(1, canvas.Count);
            for (int i = 0; i < arrVertices.Length; ++i)
            {
                Assert.IsFalse(canvas.Contains(arrVertices[i]));
            }

            Assert.IsTrue(canvas[0] is Pentagon);
            first = (Pentagon)canvas[0];
            for (int i = 0; i < arrVertices.Length; ++i)
            {
                Assert.IsTrue(first.Points.Contains(arrVertices[i].Location));
            }
        }
    }
}
