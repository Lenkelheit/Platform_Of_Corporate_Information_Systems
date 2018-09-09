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
        double radius;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="сenter">Center point</param>
        /// <param name="radius">Radius</param>
        public Circle(Point сenter, double radius)
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
        public double Radius
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
        /// <summary>
        /// Interprets string as numeric data for circle.
        /// </summary>
        /// <param name="line">
        /// The string data.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when quantity of elements for creating circle is unacceptable.
        /// </exception> 
        /// <exception cref="System.FormatException">
        /// Thrown when format of string data is unacceptable.
        /// </exception>
        protected override void Interpret(string line)
        {
            numberElementsForShape = 3;
            string[] data = line.Split(' ');
            if (data.Length != numberElementsForShape) 
            {
                throw new System.ArgumentException("Wrong argument amount.");
            }
            else 
            {
                Center.X = double.Parse(data[0]);
                Center.Y = double.Parse(data[1]);
                Radius = double.Parse(data[2]);
            }
        }
        /// <summary>
        /// Writes some information about circle to file.
        /// </summary>
        /// <param name="writeStream">
        /// Stream only for writing to file.
        /// </param>
        public override void WriteToFile(System.IO.StreamWriter writeStream)
        {
            //Circle - means it is data for circle.
            writeStream.WriteLine($"Circle {center.X} {center.Y} {radius}");
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
