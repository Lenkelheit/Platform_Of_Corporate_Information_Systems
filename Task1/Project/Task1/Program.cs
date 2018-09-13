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
        const string WRITE_FILE_1 = "file1";
        const string WRITE_FILE_2 = "file2";
        
        static void Main(string[] args)
        {
            List<ShapeBase> shapes = new List<ShapeBase>();

            // Read the data in the List collection

            // Sort the collection ascending by the square and write the result into file1
            WriteToFile(shapes.OrderBy(shape => shape.GetSquare), WRITE_FILE_1);

            // Find shapes that lie in the third quarter of the coordinate plane and write them in a separate collection           
            LinkedList<ShapeBase> shapesThirdQuarter = 
                new LinkedList<ShapeBase>(shapes.Where(shape => shape.GetQuarter == CoordinateQuarters.Third));
            
            // Sort that collection decending by the perimeters and write the result into file2
            WriteToFile(shapesThirdQuarter.OrderByDescending(shape => shape.GetPerimeter), WRITE_FILE_2);
        }

        public static void WriteToFile<T>(IEnumerable<T> collection, string fileName) where T : IFileManager
        {
            using (StreamWriter streamWriter = new StreamWriter(fileName + ".txt"))
            {
                foreach (T item in collection)
                {
                    item.WriteToFile(streamWriter);
                }
            }
        }
    }
}
