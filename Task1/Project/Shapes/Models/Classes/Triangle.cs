namespace Shapes.Models.Classes
{
    public class Triangle : ShapeBase
    {
        // FIELDS
        Point first;
        Point second;
        Point third;
        // CONSTRUCTORS
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
        /// Returns the perimeter of the triangle
        /// </summary>
        public override double GetPerimeter
        {
            get
            {
                throw new NotImplementedException();
            }
        }
        /// <summary>
        /// Returns the square of the triangle
        /// </summary>
        public override double GetSquare
        {
            get
            {
                throw new NotImplementedException();
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
            numberElementsForShape = 6;
            string[] data = line.Split(' ');
            if (data.Length != numberElementsForShape) 
            {
                throw new System.ArgumentException("The data about quantity of elements for creating triangle is unacceptable.");
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
        public void WtiteToFile(System.IO.StreamWriter writeStream)
        {
            //Triangle - means it is data for triangle.
            writeStream.WriteLine($"Triangle {first.X} {first.Y} {second.X} {second.Y} {third.X} {third.Y}");
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
