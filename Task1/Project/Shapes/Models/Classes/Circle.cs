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
        // METHODS
        /// <summary>
        /// Reads some information about circle from file.
        /// </summary>
        /// <param name="readStream">
        /// Stream for easy consistent access to file and is only for reading from it.
        /// </param>        
        public override void ReadFromFile(System.IO.StreamReader readStream)
        {
            string[] data = readStream.ReadLine().Split(' ');
            center.X = double.Parse(data[0]);
            center.Y = double.Parse(data[1]);
            radius = double.Parse(data[2]);        
        }
        /// <summary>
        /// Writes some information about circle to file.
        /// </summary>
        /// <param name="writeStream">
        /// Stream for easy consistent access to file and is only for writing to it.
        /// </param>
        public override void WriteToFile(System.IO.StreamWriter writeStream)
        {
            //c - means it is data for circle.
            writeStream.WriteLine($"c {center.X} {center.Y} {radius}");
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
