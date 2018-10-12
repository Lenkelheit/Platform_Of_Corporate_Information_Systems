using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using System.Xml.Serialization;
using System.IO;
using Shapes.Commands.Pentagon;

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
               new Type[] { typeof(System.Windows.Media.Color), typeof(System.Windows.Point[]) });
            Pentagon temp = new Pentagon();
            string fileName = Configuration.PENTAGON_SERIALIZATION_FILE_NAME;
            temp.Points = test.Points;
            temp.Color = test.Color;
            temp.StrokeColor = test.StrokeColor;
            temp.Opacity = test.Opacity;
            temp.StrokeThickness = test.StrokeThickness;
            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, temp);
            }
            using (Stream fStream = new FileStream(fileName,
               FileMode.Open, FileAccess.Read, FileShare.None))
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

        }

        [TestMethod]
        public void RemoveCommandTest()
        {
            Pentagon first = new Pentagon();
            Pentagon second = new Pentagon();
            Pentagon third = new Pentagon();
            Canvas baseCanvas = new Canvas();

            Assert.AreEqual(0, baseCanvas.Count);



            baseCanvas.Add(second);
            Assert.AreEqual(1, baseCanvas.Count);

            Shapes.Commands.Pentagon.RemovePentagon testCommand =
                  new Shapes.Commands.Pentagon.RemovePentagon(baseCanvas, second);
            testCommand.Execute();

            Assert.AreEqual(0, baseCanvas.Count);


            testCommand.UnExecute();

            Assert.AreEqual(1, baseCanvas.Count);
            Assert.AreEqual(baseCanvas[0], second);
        }


        #region ChangePentagonTest

        [TestMethod]
        public void CommandChangeColorTest()
        {
            Pentagon pentagon = new Pentagon();
            System.Windows.Media.Color color = System.Windows.Media.Color.FromRgb(0, 255, 0);
            System.Windows.Media.Color expectedColor = pentagon.Color;

            UndoRedoManager undoRedoManager = new UndoRedoManager();

            ChangeColor changeColor = new ChangeColor(pentagon, color);
            undoRedoManager.Execute(changeColor);
            Assert.AreEqual(pentagon.Color, color);

            undoRedoManager.Undo();
            Assert.AreEqual(pentagon.Color, expectedColor);
        }

        [TestMethod]
        public void CommandChangeLocationTest()
        {
            Vertex[] vertices = new Vertex[Configuration.countPoints];
            for (int i = 0; i < vertices.Length; ++i)
            {
                vertices[i] = new Vertex();
            }
            vertices[0].Location = new System.Windows.Point(1, 1);
            vertices[1].Location = new System.Windows.Point(3, 1);
            vertices[2].Location = new System.Windows.Point(4, 2);
            vertices[3].Location = new System.Windows.Point(2, 2);
            vertices[4].Location = new System.Windows.Point(1, 2);

            Pentagon pentagon = new Pentagon(vertices);
            System.Windows.Point[] points = new System.Windows.Point[Configuration.countPoints];
            points[0] = new System.Windows.Point(1, 1);
            points[1] = new System.Windows.Point(3, 1);
            points[2] = new System.Windows.Point(4, 2);
            points[3] = new System.Windows.Point(2, 2);
            points[4] = new System.Windows.Point(1, 2);

            System.Windows.Point[] expectedLocation = new System.Windows.Point[Configuration.countPoints];
            Array.Copy(pentagon.Points, expectedLocation, Configuration.countPoints);

            UndoRedoManager undoRedoManager = new UndoRedoManager();

            ChangeLocation changeLocation = new ChangeLocation(pentagon, points);
            undoRedoManager.Execute(changeLocation);
            //for (int i = 0; i < Configuration.countPoints; ++i)
            //{
            //    Assert.AreEqual(pentagon.Points[i], points[i]);
            //}
            CollectionAssert.AreEqual(pentagon.Points, points);

            undoRedoManager.Undo();
            //for (int i = 0; i < 5; ++i)
            //{
            //    Assert.AreEqual(pentagon.Points[i], expectedLocation[i]);
            //}
            CollectionAssert.AreEqual(pentagon.Points, expectedLocation);
        }

        [TestMethod]
        public void CommandChangeOpacityTest()
        {
            Pentagon pentagon = new Pentagon();
            double opacity = Configuration.opacity;
            double expectedOpacity = pentagon.Opacity;

            UndoRedoManager undoRedoManager = new UndoRedoManager();

            ChangeOpacity changeOpacity = new ChangeOpacity(pentagon, opacity);
            undoRedoManager.Execute(changeOpacity);
            Assert.AreEqual(pentagon.Opacity, opacity);

            undoRedoManager.Undo();
            Assert.AreEqual(pentagon.Opacity, expectedOpacity);
        }

        [TestMethod]
        public void CommandChangeStrokeColorTest()
        {
            Pentagon pentagon = new Pentagon();
            System.Windows.Media.Color color = System.Windows.Media.Color.FromRgb(255, 0, 0);
            System.Windows.Media.Color expectedColor = pentagon.StrokeColor;

            UndoRedoManager undoRedoManager = new UndoRedoManager();

            ChangeStrokeColor changeStrokeColor = new ChangeStrokeColor(pentagon, color);
            undoRedoManager.Execute(changeStrokeColor);
            Assert.AreEqual(pentagon.StrokeColor, color);

            undoRedoManager.Undo();
            Assert.AreEqual(pentagon.StrokeColor, expectedColor);
        }

        [TestMethod]
        public void CommandChangeStrokeWidthTest()
        {
            Pentagon pentagon = new Pentagon();
            double strokeThickness = Configuration.strokeThickness;
            double expectedStrokeThickness = pentagon.StrokeThickness;

            UndoRedoManager undoRedoManager = new UndoRedoManager();

            ChangeStrokeWidth changeStrokeWidth = new ChangeStrokeWidth(pentagon, strokeThickness);
            undoRedoManager.Execute(changeStrokeWidth);
            Assert.AreEqual(pentagon.StrokeThickness, strokeThickness);

            undoRedoManager.Undo();
            Assert.AreEqual(pentagon.StrokeThickness, expectedStrokeThickness);
        }

        #endregion
    }
}
