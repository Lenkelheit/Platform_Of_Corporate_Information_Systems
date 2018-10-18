using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shapes.Models;
using System.Xml.Serialization;
using System.IO;

namespace Test
{
    [TestClass]
    public class CanvasTest
    {
        Canvas test;
        [TestMethod]
        public void CountPropertyTest()
        {
            test = new Canvas();
            int startCount = 0;
            test.Add(new Pentagon());
            int finalCount = test.Count;
            Assert.AreEqual(startCount + 1, finalCount);
        }
        [TestMethod]
        public void ConstructorTest()
        {
            test = new Canvas();
            Assert.IsTrue(test.Count == 0);
        }
        [TestMethod]
        public void IndexerTest()
        {
            test = new Canvas();
            Pentagon p = new Pentagon();
            test.Add(p);
            Assert.IsTrue(test[0] == p);
        }
        [TestMethod]
        public void AddTest()
        {
            test = new Canvas();
            Pentagon added = new Pentagon();
            added.Opacity = 10;
            test.Add(added);
            Assert.AreEqual((test[0] as Pentagon).Opacity, 10);
        }
        [TestMethod]
        public void InsertTest()
        {
            test = new Canvas();
            Pentagon added = new Pentagon();
            added.Opacity = 10;
            test.Insert(0, added);
            Assert.AreEqual((test[0] as Pentagon).Opacity, 10);
        }        
        [TestMethod]
        public void RemoveTest()
        {
            test = new Canvas();
            Pentagon added = new Pentagon();
            added.Opacity = 10;
            test.Insert(0, added);
            test.Remove(added);
        }
        [TestMethod]
        public void RemoveAtTest()
        {
            test = new Canvas();
            Pentagon added = new Pentagon();
            added.Opacity = 10;
            test.Insert(0, added);
            test.RemoveAt(0);
        }
        [TestMethod]
        public void RemoveAllTest()
        {
            test = new Canvas();
            Pentagon added = new Pentagon(), added1 = new Pentagon(), added2 = new Pentagon();
            added.Opacity = 10;
            added1.Opacity = 4;
            added2.Opacity = 10;
            test.Add(added);
            test.Add(added1);
            test.Add(added2);
            test.RemoveAll(new Predicate<ShapeBase>(delegate (ShapeBase target)
            {
                Pentagon temp = (Pentagon)target;
                return temp.Opacity == 10;
            }));
            Assert.AreEqual(test.Count, 1);
        }
        [TestMethod]
        public void ClearTest()
        {
            test = new Canvas();
            for (int i = 0; i < 3; i++)
            {
                test.Add(new Pentagon());
            }
            test.Clear();
            Assert.AreEqual(0, test.Count);
        }
        [TestMethod]
        public void ContainsTest()
        {
            test = new Canvas();
            Pentagon added = new Pentagon();
            added.Opacity = 10;
            test.Add(added);
            Assert.IsTrue(test.Contains(added) && !(test.Contains(new Pentagon())));
        }
        [TestMethod]
        public void CountIfTest()
        {
            test = new Canvas();
            test.Add(new Pentagon()
            {
                Opacity = 0.8
            });
            test.Add(new Vertex());
            test.Add(new Vertex());
            test.Add(new Pentagon()
            {
                Opacity = 0.6
            });
            test.Add(new Pentagon()
            {
                Opacity = 0.4
            });
            test.Add(new Pentagon());

            Assert.AreEqual(2, test.CountIf((s) => s is Vertex));
            Assert.AreEqual(4, test.CountIf((s) => s is Pentagon));
            Assert.AreEqual(2, test.CountIf((s) => s is Pentagon && ((Pentagon)s).Opacity > 0.5));
        }
        [TestMethod]
        public void CopyToTest()
        {
            test = new Canvas();
            Pentagon added = new Pentagon(), added1 = new Pentagon(), added2 = new Pentagon();
            added.Opacity = 10;
            added1.Opacity = 4;
            added2.Opacity = 10;
            test.Add(added);
            test.Add(added1);
            test.Add(added2);
            Pentagon[] targetArr = new Pentagon[3];
            test.CopyTo(targetArr, 0);
            Assert.AreEqual(3, targetArr.Length);
        }
        [TestMethod]
        public void IndexOfTest()
        {
            test = new Canvas();
            Pentagon added = new Pentagon(), added1 = new Pentagon();
            added.Opacity = 10;
            added1.Opacity = 4;
            test.Add(added);
            test.Add(added1);
            Assert.AreEqual(1, test.IndexOf(added1));
        }
        [TestMethod]
        public void SerializationTest()
        {
            XmlSerializer xmlFormat = new XmlSerializer(typeof(Canvas),
                new Type[3] { typeof(ShapeBase) , typeof(Pentagon), typeof(Vertex)});
            test = new Canvas();
            string fileName = Configuration.CANVAS_SERIALIZATION_FILE_NAME;
            Pentagon added = new Pentagon();
            added.Opacity = 10;
            test.Add(added);
            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, test);
            }
            using (Stream fStream = new FileStream(fileName,
               FileMode.Open, FileAccess.Read, FileShare.None))
            {
                test = (Canvas)xmlFormat.Deserialize(fStream);
            }
            Assert.AreEqual(10, (test[0] as Pentagon).Opacity);
        }
    }
}
