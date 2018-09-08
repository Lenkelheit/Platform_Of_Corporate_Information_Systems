using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models.Classes
{
    public class Square : ShapeBase
    {
        public Point TopLeftPoint
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public Point BottomRightPoint
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

        public override void ReadFromFile(StreamReader readStream)
        {
            throw new NotImplementedException();
        }

        public override void WtiteToFile(StreamWriter writeStream)
        {
            throw new NotImplementedException();
        }

        protected override Point GetMiddlePoint()
        {
            throw new NotImplementedException();
        }
    }
}
