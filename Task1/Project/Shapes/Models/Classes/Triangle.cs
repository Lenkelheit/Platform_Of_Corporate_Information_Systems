using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

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
        /// Basic constructor without parametrs
        /// </summary>
        public Triangle()
        {
            first = new Point();
            second = new Point();
            third = new Point();
        }
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
        /// <returns>Triangles perimetr</returns>
        public override double GetPerimeter
        {
            get
            {
                return Point.Distance(first, second) + Point.Distance(first, third) + Point.Distance(third, second);
            }
        }
        /// <summary>
        /// Returns the square of the triangle
        /// </summary>
        /// <returns>Triangles square</returns>
        public override double GetSquare
        {
            get
            {
                double halfPerim = (Point.Distance(first, second) + Point.Distance(first, third) + Point.Distance(third, second))/2;
                return Sqrt(halfPerim * (halfPerim - Point.Distance(first, second)) * (halfPerim - Point.Distance(first, third)) *
                    (halfPerim - Point.Distance(third, second)));
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

        // METHODS
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

