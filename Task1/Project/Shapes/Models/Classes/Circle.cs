using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents class for circle
    /// </summary>
    public class Circle : ShapeBase
    {
        //FIELDS
        const double Pi = 3.14;
        Point center;
        double radius;
        //CONSTRUCTORS
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="Center">Center point</param>
        /// <param name="Radius">Radius</param>
        public Circle(Point Center, double Radius)
        {
            center = Center;
            radius = Radius;
        }
        //PROPERTIES
        /// <summary>
        /// Returns the perimeter of the circle
        /// </summary>
        /// <returns>Shape perimeter</returns>
        public override double GetPerimeter
        {
            get { return 2 * Pi * radius; }
        }
        /// <summary>
        /// Returns the square of the circle
        /// </summary>
        /// <returns>Shape square</returns>
        public override double GetSquare
        {
            get { return Pi * radius * radius; }
        }
        //METHODS


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
