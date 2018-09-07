using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models.Classes
{
    public class Circle : ShapeBase
    {
        public Point Center
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        public double Radius
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override double GetPerimeter
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override double GetSquare
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public override void ReadFromFile(Stream fileStream)
        {
            throw new NotImplementedException();
        }

        public override void WtiteToFile(Stream fileStream)
        {
            throw new NotImplementedException();
        }

        protected override Point GetMiddlePoint()
        {
            throw new NotImplementedException();
        }
    }
}
