using System;
using System.Collections.Generic;
using System.IO;
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
        Point topLeft;
        Point bottomRight;
        //Constructors
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="topleft">Point in Top, Left corner</param>
        /// <param name="bottomright">Point in Bottom, Right corner</param>
        public Square(Point topleft, Point bottomright)
        {
            if (topleft.X == bottomright.X || topleft.Y == bottomright.Y)
            {
                throw new Exception("This points can't make square");
            }
            topLeft = topleft;
            bottomRight = bottomright;
        }
        //PROPERTIES
        /// <summary>
        /// Returns the perimeter of the square
        /// </summary>
        /// <returns>Shape perimeter</returns>
        public override double GetPerimeter
        {
            get
            {
                return Abs(topLeft.X - bottomRight.X) * 2 + Abs(topLeft.Y - bottomRight.Y) * 2;
            }
        }
        /// <summary>
        /// Returns the square of the square
        /// </summary>
        /// <returns>Shape square</returns>
        public override double GetSquare
        {
            get
            {
                return Abs(topLeft.X - bottomRight.X) * Abs(topLeft.Y - bottomRight.Y);
            }
        }
        //METHODS
        /// <summary>
        /// Returns the central point of shape
        /// </summary>
        /// <returns>Central point</returns>
        protected override Point GetMiddlePoint()
        {
            return new Point(bottomRight.X - Abs(topLeft.X - bottomRight.X) / 2,
                topLeft.Y - Abs(topLeft.Y - bottomRight.Y));
        }

        public override void ReadFromFile(Stream fileStream)
        {
            throw new NotImplementedException();
        }

        public override void WtiteToFile(Stream fileStream)
        {
            throw new NotImplementedException();
        }
    }
}

