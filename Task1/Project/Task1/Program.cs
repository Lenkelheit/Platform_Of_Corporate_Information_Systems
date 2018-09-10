using System;
using System.Collections.Generic;
using System.Linq;
using Shapes.Models.Classes;
using Shapes.Models.Enums;
using Shapes.Models.Interfaces;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<ShapeBase> shapes = new List<ShapeBase>();

            string file1 = "";
            string file2 = "";

            // Read the data in the List collection

            // Sort the collection ascending by the square and write the result into file1
            WriteToFile(shapes.OrderBy(shape => shape.GetSquare), file1);

            // Find shapes that lie in the third quarter of the coordinate plane and write them in a separate collection           
            LinkedList<ShapeBase> shapeBases = 
                new LinkedList<ShapeBase>(shapes.Where(shape => shape.GetQuarter == CoordinateQuarters.Third));
            
            // Sort that collection decending by the perimeters and write the result into file2
            WriteToFile(shapeBases.OrderByDescending(shape => shape.GetPerimeter), file2);
        }

        public static void WriteToFile<T>(IEnumerable<T> collection, string fileName) where T : IFileManager
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName + ".txt"))
            {
                foreach (T item in collection)
                {
                    item.WtiteToFile(streamWriter);
                }
            }
        }
    }
}
