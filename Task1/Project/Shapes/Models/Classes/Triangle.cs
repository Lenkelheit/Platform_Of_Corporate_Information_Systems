using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models.Classes
{
    public class Triangle : ShapeBase
    {
        // FIELDS
        Point first;
        Point second;
        Point third;
        // CONSTRUCTORS
        /// <summary>
        /// Basic constructor with params
        /// </summary>
        /// <param name="first">First point</param>
        /// <param name="second">Second point</param>
        /// <param name="third">Third point</param>
        public Triangle(Point first, Point second, Point third)
        {
            this.first = first;
            this.second = second;
            this.third = third;
        }
        // PROPETRIES
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

        // METHODS
        public override void ReadFromFile(StreamReader readStream)
        {
            throw new NotImplementedException();
        }

        public override void WtiteToFile(StreamWriter writeStream)
        {
            throw new NotImplementedException();
        }
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