using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            //Read the data in the List collection



            //Sort the collection ascending by the square and write the result into file1
            using (StreamWriter sw = new StreamWriter("file1"))
            {
                IEnumerable<IShape> newShapes = from i in shapes
                                                orderby i.GetSquare
                                                select i;
                foreach (List<IShape> shape in newShapes)
                {
                    sw.WriteLine(shape);
                }
            }

            //Find shapes that lie in the third quarter of the coordinate plane and write them in a separate collection
            //Sort that collection decending by the perimeters and write the result into file2
            using (StreamWriter sw = new StreamWriter("file2"))
            {
                IEnumerable<IShape> newColections = from i in shapes
                                                    where i.GetQuarter == CoordinateQuarters.Third                                                   
                                                    orderby i.GetPerimeter descending
                                                    select i;
                foreach (List<IShape> j in newColections)
                {
                    sw.WriteLine(j);
                }
            }
        }
    }
}
