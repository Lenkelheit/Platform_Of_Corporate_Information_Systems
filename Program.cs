using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shapes.Models.Interfaces;
using Shapes.Models.Enums;
using System.IO;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>();

            using (StreamWriter sw = new StreamWriter("треба файл!"))
            {
                IEnumerable<IShape> newShapes = from i in shapes
                                                orderby i.GetSquare
                                                select i;
                foreach (List<IShape> shape in newShapes)
                {
                    sw.WriteLine(shape);
                }
            }

            using (StreamWriter sw = new StreamWriter("треба файл!"))
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
