using static System.Math;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents class for square
    /// </summary>
    public class Square : ShapeBase
    {
        const uint ARGUMENT_AMOUNT = 4;    
        // FIELDS
        Point topLeft;
        Point bottomRight;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with params
        /// </summary>
        /// <param name="topLeft">Point in Top, Left corner</param>
        /// <param name="bottomRight">Point in Bottom, Right corner</param>
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
        /// Identifier of the square.
        /// </summary>
        public override string ID => nameof(Square);
        /// <summary>
        /// Number of simple elements of the square.
        /// </summary>
        public override uint ArgumentAmount => ARGUMENT_AMOUNT;    
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
        /// <summary>
        /// Interprets string as numeric data for square.
        /// </summary>
        /// <param name="line">
        /// The string data.
        /// </param>
        /// <exception cref="System.ArgumentException">
        /// Thrown when quantity of elements for creating square is unacceptable.
        /// </exception> 
        /// <exception cref="System.FormatException">
        /// Thrown when format of string data is unacceptable.
        /// </exception>
        protected override void Interpret(string line)
        {
            string[] data = line.Split(' ');
            if (data.Length != ArgumentAmount) 
            {
                throw new System.ArgumentException("Wrong argument amount.");
            }
            else 
            {
                topLeft.X = double.Parse(data[0]);
                topLeft.Y = double.Parse(data[1]);
                bottomRight.X = double.Parse(data[2]);
                bottomRight.Y = double.Parse(data[3]);
            }
        }
        /// <summary>
        /// Writes some information about square to file.
        /// </summary>
        /// <param name="writeStream">
        /// Stream only for writing to file.
        /// </param>
        public override void WriteToFile(System.IO.StreamWriter writeStream)
        {
            //Square - means it is data for square.
            writeStream.WriteLine($"{ID} {topLeft.X} {topLeft.Y} {bottomRight.X} {bottomRight.Y}");
        }
    }
}

