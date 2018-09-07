using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents class for circle
    /// </summary>
    class Circle : ShapeBase
    {
        //FIELDS
        /// <summary>
        /// Center point
        /// </summary>
        Point center;
        /// <summary>
        /// Circle radius
        /// </summary>
        double radius;
        //CONSTRUCTORS
        /// <summary>
        /// Basic constructor
        /// </summary>
        public Circle() { }
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="cent"></param>
        /// <param name="rad"></param>
        public Circle(Point cent, double rad)
        {
            center = cent;
            radius = rad;
        }
        //PROPERTIE
        /// <summary>
        /// Returns the perimeter of the circle
        /// </summary>
        public override double GetPerimeter
        {
            get
            {
                return 2 * 3.14 * radius;
            }
        }
        /// <summary>
        /// Returns the square of the circle
        /// </summary>
        public override double GetSquare
        {
            get
            {
                return 3.14 * radius * radius;
            }
        }
        //METHODS
        /// <summary>
        /// Returns the position of the shape whithin coordinate querter
        /// </summary>
        protected override Point GetMiddlePoint()
        {
            return new Point(center.X, center.Y);
        }
    }
}
