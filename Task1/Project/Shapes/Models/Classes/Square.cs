using System;
using System.IO;
using System.Text;

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
