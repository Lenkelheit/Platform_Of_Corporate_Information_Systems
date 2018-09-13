using static System.Math;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents class for circle
    /// </summary>
    public class Circle : ShapeBase
    {
        // CONST
        const uint ARGUMENT_AMOUNT = 3;    
        // FIELDS
        Point center;
        double radius;
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
        public Circle(Point сenter, double radius)
        {
            if (radius < 0)
            {
                throw new System.ArgumentException("The radius can not be less than zero");
            }
            this.center = сenter;
            this.radius = radius;
        }
        // PROPERTIES
        /// <summary>
        /// Number of simple elements of the circle.
        /// </summary>
        public override uint ArgumentAmount => ARGUMENT_AMOUNT;        
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
        /// <returns>
        /// Filled circle into <see cref="ShapeBase"/>.
        /// </returns>        
        /// <exception cref="System.ArgumentException">
        /// Thrown when quantity of elements for creating circle is unacceptable.
        /// </exception> 
        /// <exception cref="System.FormatException">
        /// Thrown when format of string data is unacceptable.
        /// </exception>
        protected override ShapeBase Interpret(string line)
        {
            string[] data = line.Split(' ');
            if (data.Length != ArgumentAmount) 
            {
                throw new System.ArgumentException("Wrong argument amount for circle.");
            }
            else 
            {
                center.X = double.Parse(data[0]);
                center.Y = double.Parse(data[1]);
                radius = double.Parse(data[2]);
                return this;                
            }
        }
        /// <summary>
        /// Creates <see cref="Circle"/> and fills its fields.
        /// </summary>
        /// <param name="line">
        /// The string data.
        /// </param>
        /// <returns>
        /// Created circle into <see cref="ShapeBase"/>.
        /// </returns>
        public static ShapeBase CreateInstance(string line)
        {
            return new Circle().Interpret(line);
        }        
        /// <summary>
        /// Writes some information about circle to file.
        /// </summary>
        /// <param name="writeStream">
        /// Stream only for writing to file.
        /// </param>
        public override void WriteToFile(System.IO.StreamWriter writeStream)
        {
            writeStream.WriteLine($"{ID} {center.X} {center.Y} {radius}");
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
