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
    /// Represents class for circle
    /// </summary>
    public class Circle : ShapeBase
    {
        // FIELDS
        Point center;
        uint radius;
        // CONSTRUCTORS
        /// <summary>
        /// Basic constructor without parameters
        /// </summary>
        public Circle()
        {
            center = new Point();
            radius = 0;
        }
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="сenter">Center point</param>
        /// <param name="radius">Radius</param>
        public Circle(Point сenter, uint radius)
        {
            this.center = сenter;
            this.radius = radius;
        }
        // PROPERTIES
        /// <summary>
        /// Returns the perimeter of the circle
        /// </summary>
        /// <returns>Shape perimeter</returns>
        public override double GetPerimeter
        {
            get
            {
                return 2 * PI * radius;
            }
        }
        /// <summary>
        /// Returns the square of the circle
        /// </summary>
        /// <returns>Shape square</returns>
        public override double GetSquare
        {
            get
            {
                return PI * radius * radius;
            }
        }
        /// <summary>
        /// Propetry that returns circle radius
        /// </summary>
        /// <returns>Circle radius</returns>
        public uint Radius
        {
            get
            {
                return radius;
            }
        }
        /// <summary>
        /// Propetry that returns circle center point
        /// </summary>
        /// <returns>Circle center point</returns>
        public Point Center
        {
            get
            {
                return center;
            }
        }
        // METHODS


        public override void ReadFromFile(Stream fileStream)
        {
            throw new NotImplementedException();
        }

        public override void WtiteToFile(Stream fileStream)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Returns the central point of shape
        /// </summary>
        /// <returns>Central point of shape</returns>
        protected override Point GetMiddlePoint()
        {
            return center;
        }
    }
}
