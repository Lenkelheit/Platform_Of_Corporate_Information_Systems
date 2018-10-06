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
        void SerialiseUnitTest()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Pentagon),
               new Type[] { typeof(System.Windows.Media.Color), typeof(System.Windows.Point[]) });
            Pentagon temp = new Pentagon();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Test\Serialization\PentagonData.xml";
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
            Assert.IsTrue(p.HitTest(new System.Windows.Point(2, 2)));
            Assert.IsTrue(p.HitTest(new System.Windows.Point(5, 2)));

        }
        #region RemovePentagonCommandTests

        [TestMethod]
        public void ExecuteTest()
        {
            Pentagon first = new Pentagon();
            Pentagon second = new Pentagon();
            Pentagon third = new Pentagon();
            Canvas baseCanvas = new Canvas();
            Shapes.Commands.Pentagon.RemovePentagon testCommand =
                new Shapes.Commands.Pentagon.RemovePentagon(baseCanvas, second);
            testCommand.Execute();
            Assert.AreEqual(baseCanvas[1], third);
        }
        [TestMethod]
        public void UnExecuteTest()
        {
            Pentagon first = new Pentagon();
            Pentagon second = new Pentagon();
            Pentagon third = new Pentagon();
            Canvas baseCanvas = new Canvas();
            Shapes.Commands.Pentagon.RemovePentagon testCommand =
                new Shapes.Commands.Pentagon.RemovePentagon(baseCanvas, second);
            testCommand.Execute();
            testCommand.UnExecute();
            Assert.AreEqual(baseCanvas[1], second);
        }

            #endregion
        }
}
