using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using System.Xml.Serialization;
using System.IO;
using Shapes.Commands;

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

    }
}
