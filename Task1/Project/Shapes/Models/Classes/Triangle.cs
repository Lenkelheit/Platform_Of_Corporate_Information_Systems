using static System.Math;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents class for triangle
    /// </summary>
    public class Triangle : ShapeBase
    {
        // CONST    
        const uint ARGUMENT_AMOUNT = 6;
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
        // PROPERTIES
        /// <summary>
        /// Identifier of the triangle.
        /// </summary>
        public override string ID => nameof(Triangle);
        /// <summary>
        /// Number of simple elements of the triangle.
        /// </summary>
        public override uint ArgumentAmount => ARGUMENT_AMOUNT;      
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
                double halfPerim = this.GetPerimeter / 2;
                // √p(p - a)(p - b)(p - c)
                return Sqrt(halfPerim 
                    * (halfPerim - Point.Distance(first, second))
                    * (halfPerim - Point.Distance(first, third)) 
                    * (halfPerim - Point.Distance(third, second)));
            }
        }
        // METHODS
        /// <summary>
        /// Interprets string as numeric data for triangle.
        /// </summary>
        /// <param name="line">
        /// The string data.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when quantity of elements for creating triangle is unacceptable.
        /// </exception> 
        /// <exception cref="System.FormatException">
        /// Thrown when format of string data is unacceptable.
        /// </exception>
        protected override void Interpret(string line)
        {
            string[] data = line.Split(' ');
            if (data.Length != ArgumentAmount) 
            {
                throw new System.ArgumentException("Wrong argument amount for triangle.");
            }
            else 
            {
                first.X = double.Parse(data[0]);
                first.Y = double.Parse(data[1]);
                second.X = double.Parse(data[2]);
                second.Y = double.Parse(data[3]);
                third.X = double.Parse(data[4]);
                third.Y = double.Parse(data[5]);
            }
        }
        /// <summary>
        /// Writes some information about triangle to file.
        /// </summary>
        /// <param name="writeStream">
        /// Stream only for writing to file.
        /// </param>
        public override void WriteToFile(System.IO.StreamWriter writeStream)
        {
            writeStream.WriteLine($"{ID} {first.X} {first.Y} {second.X} {second.Y} {third.X} {third.Y}");
        }
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
