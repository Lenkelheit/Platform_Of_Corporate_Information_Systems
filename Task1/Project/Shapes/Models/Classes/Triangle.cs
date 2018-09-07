using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models.Classes
{
    class Triangle : ShapeBase
    {
        //FIELDS
        Point first;
        Point second;
        Point third;
        //Contructors
        /// <summary>
        /// Basic constructor with params
        /// </summary>
        /// <param name="First">First point</param>
        /// <param name="Second">Second point</param>
        /// <param name="Third">Third point</param>
        public Triangle(Point First, Point Second, Point Third)
        {
            first = First;
            second = Second;
            third = Third;
        }
        //Properties
        /// <summary>
        /// Returns the perimeter of the triangle
        /// </summary>
        public override double GetPerimeter
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Returns the square of the triangle
        /// </summary>
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

        //METHODS
        /// <summary>
        /// Returns the position of the triangle whithin coordinate querter
        /// </summary>
        /// <returns>Central point of shape</returns>
        protected override Point GetMiddlePoint()
        {
            return new Point((first.X + second.X + third.X)/3, (first.Y + second.Y + third.Y)/3);
        }
    }
}

