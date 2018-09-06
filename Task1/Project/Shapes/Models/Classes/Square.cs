using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents class for square
    /// </summary>
    class Square : ShapeBase
    {
        //FIELDS    
        /// <summary>
        /// Top-left corner point
        /// </summary>
        Point topLeft;
        /// <summary>
        /// Bottom-right corner point
        /// </summary>
        Point bottomRight;
        //Constructors
        /// <summary>
        /// Basic constructor
        /// </summary>
        Square() { }
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="topleft"></param>
        /// <param name="bottomright"></param>
        Square(Point topleft, Point bottomright)
        {
            topLeft = topleft;
            bottomRight = bottomright;
        }
        //PROPERTIES
        /// <summary>
        /// Returns the perimeter of the square
        /// </summary>
        public override double GetPerimeter
        {
            get
            {
                return (Abs(topLeft.X - bottomRight.X) * 2 + Abs(topLeft.Y - bottomRight.Y) * 2);
            }
        }
        /// <summary>
        /// Returns the square of the square
        /// </summary>
        public override double GetSquare
        {
            get
            {
                return (Abs(topLeft.X - bottomRight.X) * Abs(topLeft.Y - bottomRight.Y));
            }
        }
        //METHODS
        /// <summary>
        /// Returns the position of the square whithin coordinate querter
        /// </summary>
        /// <returns></returns>
        protected override Point GetMiddlePoint()
        {
            return new Point(bottomRight.X - Abs(topLeft.X - bottomRight.X) / 2,
                topLeft.Y - Abs(topLeft.Y - bottomRight.Y));
        }
    }
}

