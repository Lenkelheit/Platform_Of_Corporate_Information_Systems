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
    public class Square : ShapeBase
    {
        // FIELDS
        Point topLeft;
        Point bottomRight;
        // CONSTRUCTORS
        /// <summary>
        /// Basic constructor without parameters
        /// </summary>
        public Square()
        {
            topLeft = new Point();
            bottomRight = new Point();
        }
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="topLeft">Point in Top, Left corner</param>
        /// <param name="bottomRight">Point in Bottom, Right corner</param>
        /// <exception cref="System.Exception">This points can't make square</exception>;
        public Square(Point topLeft, Point bottomRight)
        {
            if (Abs(topLeft.X - bottomRight.X) == Abs(topLeft.Y - bottomRight.Y))
            {
                this.topLeft = topLeft;
                this.bottomRight = bottomRight;
            }
            else
            {
                throw new ArgumentException("This points can't make square");
            }
        }
        // PROPERTIES
        /// <summary>
        /// Propetry that returns top left point
        /// </summary>
        /// <returns>Top left point</returns>
        public Point TopLeftPoint
        {
            get
            {
                return topLeft;
            }
        }
        /// <summary>
        /// Propetry that returns bottom right point
        /// </summary>
        /// <returns>Bottom right point</returns>
        public Point BottomRightPoint
        {
            get
            {
                return bottomRight;
            }
        }
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
        // METHODS
        /// <summary>
        /// Returns the central point of shape
        /// </summary>
        /// <returns>Central point</returns>
        protected override Point GetMiddlePoint()
        {
            return new Point(bottomRight.X - Abs(topLeft.X - bottomRight.X) / 2,
                topLeft.Y - Abs(topLeft.Y - bottomRight.Y));
        }

        public override void ReadFromFile(StreamReader readStream)
        {
            throw new NotImplementedException();
        }

        public override void WtiteToFile(StreamWriter writeStream)
        {
            throw new NotImplementedException();
        }
    }
}

