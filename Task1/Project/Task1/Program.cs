using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Models.Classes;
using Shapes.Models.Enums;
using Shapes.Models.Interfaces;
using Shapes;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ShapeBase> shapes = new List<ShapeBase>();

            // Read the data in the List collection



            // Sort the collection ascending by the square and write the result into file1

            IEnumerable<ShapeBase> newShapes = from i in shapes
                                               orderby i.GetSquare
                                               select i;
            WriteToFile<ShapeBase>(newShapes, "file1");


            // Find shapes that lie in the third quarter of the coordinate plane and write them in a separate collection
            // Sort that collection decending by the perimeters and write the result into file2

            IEnumerable<ShapeBase> newColections = from i in shapes
                                                   where i.GetQuarter == CoordinateQuarters.Third
                                                   orderby i.GetPerimeter descending
                                                   select i;
            WriteToFile<ShapeBase>(newColections, "file2");

        }

        public static void WriteToFile<IFileManager>(IEnumerable<IFileManager> collection, string fileName)
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName))
            {
                foreach (IFileManager item in collection)
                {
                    streamWriter.WriteLine(item);
                }
            }
        }
    }
}
