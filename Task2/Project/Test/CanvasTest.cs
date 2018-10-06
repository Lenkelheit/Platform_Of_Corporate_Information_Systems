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
            Assert.IsTrue(test.Count == 0 && test[0] == null);
        }
        [TestMethod]
        public void IndexerTest()
        {
            test = new Canvas();
            test[0] = new Pentagon();
            Assert.IsTrue(test[0] == new Pentagon());
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
            Assert.AreEqual(test[0], null);
        }
        [TestMethod]
        public void RemoveAtTest()
        {
            test = new Canvas();
            Pentagon added = new Pentagon();
            added.Opacity = 10;
            test.Insert(0, added);
            test.RemoveAt(0);
            Assert.AreEqual(test[0], null);
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
            test.CopyTo(targetArr, 1);
            Assert.AreEqual(2, targetArr.Length);
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
                new Type[1] { typeof(ShapeBase) });
            test = new Canvas();
            string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Test\Serialization\CanvasData.xml";
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
