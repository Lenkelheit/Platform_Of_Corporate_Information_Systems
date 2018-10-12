using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Serialization;

namespace Test
{
    [TestClass]
    public class ShapeBaseTest
    {
        private void SaveToFile(string fileName, Shapes.Models.ShapeBase shape)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Shapes.Models.ShapeBase),
                new System.Type[] { shape.GetType() });
            using (System.IO.FileStream fStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None)) 
            {
                xmlFormat.Serialize(fStream, shape);
            }
        }
        private void LoadFromFile(string fileName, out Shapes.Models.ShapeBase shape, System.Type derivativeTypeOfShape)
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Shapes.Models.ShapeBase),
                new System.Type[] { derivativeTypeOfShape });
            using (System.IO.FileStream fStream = new System.IO.FileStream(fileName,
                System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.None))
            {
                shape = (Shapes.Models.ShapeBase)xmlFormat.Deserialize(fStream);
            }
        }

        [TestMethod]
        public void SerialiseShapeBaseAndVertexTest()
        {
            Shapes.Models.ShapeBase shapeForWritingToFile = new Shapes.Models.Vertex
            {
                Location = new System.Windows.Point(2, 7)
            };
            Assert.IsTrue(shapeForWritingToFile is Shapes.Models.Vertex);

            string fileName = Configuration.SHAPEBASE_AND_VERTEX_SERIALIZATION_FILE_NAME;

            SaveToFile(fileName, shapeForWritingToFile);

            Shapes.Models.ShapeBase shapeForReadingFromFile;
            LoadFromFile(fileName, out shapeForReadingFromFile, shapeForWritingToFile.GetType());
            Assert.IsTrue(shapeForReadingFromFile is Shapes.Models.Vertex);

            Shapes.Models.Vertex vertexWrite = (Shapes.Models.Vertex)shapeForWritingToFile;
            Shapes.Models.Vertex vertexRead = (Shapes.Models.Vertex)shapeForReadingFromFile;
            Assert.IsTrue(vertexWrite.Name == vertexRead.Name && vertexWrite.Location == vertexRead.Location);
        }

        [TestMethod]
        public void SerialiseShapeBaseAndPentagonTest()
        {
            Shapes.Models.ShapeBase shapeForWritingToFile = new Shapes.Models.Pentagon
            {
                Color = System.Windows.Media.Color.FromRgb(100, 100, 100),
                StrokeColor = System.Windows.Media.Color.FromRgb(100, 100, 100),
                StrokeThickness = 10,
                Opacity = 10,
                Points = new System.Windows.Point[Shapes.Models.Pentagon.NUM_OF_EDGE_IN_PENTAGON]
                {
                    new System.Windows.Point(2, 4),
                    new System.Windows.Point(3 ,5),
                    new System.Windows.Point(4 ,6),
                    new System.Windows.Point(5 ,7),
                    new System.Windows.Point(6 ,8)
                }
            };
            Assert.IsTrue(shapeForWritingToFile is Shapes.Models.Pentagon);

            string fileName = Configuration.SHAPEBASE_AND_PENTAGON_SERIALIZATION_FILE_NAME;

            SaveToFile(fileName, shapeForWritingToFile);

            Shapes.Models.ShapeBase shapeForReadingFromFile;
            LoadFromFile(fileName, out shapeForReadingFromFile, shapeForWritingToFile.GetType());
            Assert.IsTrue(shapeForReadingFromFile is Shapes.Models.Pentagon);

            Shapes.Models.Pentagon pentagonWrite = (Shapes.Models.Pentagon)shapeForWritingToFile;
            Shapes.Models.Pentagon pentagonRead = (Shapes.Models.Pentagon)shapeForReadingFromFile;
            Assert.IsTrue(pentagonWrite.Name == pentagonRead.Name && pentagonWrite.Color == pentagonRead.Color
                && pentagonWrite.StrokeColor == pentagonRead.StrokeColor
                && pentagonWrite.StrokeThickness == pentagonRead.StrokeThickness
                && pentagonWrite.Opacity == pentagonRead.Opacity);
            for (int i = 0; i < Shapes.Models.Pentagon.NUM_OF_EDGE_IN_PENTAGON; ++i) 
            {
                Assert.AreEqual(pentagonWrite.Points[i], pentagonRead.Points[i]);
            }
        }
    }
}
