using static System.Math;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents class for square
    /// </summary>
    public class Square : ShapeBase
    {
        // CONST    
        const uint ARGUMENT_AMOUNT = 4;    
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
        /// <exception cref="System.ArgumentException">Thrown when points can't make square</exception>;
        public Square(Point topLeft, Point bottomRight)
        {
            if (Abs(topLeft.X - bottomRight.X) == Abs(topLeft.Y - bottomRight.Y))
            {
                this.topLeft = topLeft;
                this.bottomRight = bottomRight;
            }
            else
            {
                throw new System.ArgumentException("This points can't make square");
            }
        }
        // PROPERTIES
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
        /// <returns>
        /// Filled square into <see cref="ShapeBase"/>.
        /// </returns>        
        /// <exception cref="System.ArgumentException">
        /// Thrown when quantity of elements for creating square is unacceptable.
        /// </exception> 
        /// <exception cref="System.FormatException">
        /// Thrown when format of string data is unacceptable.
        /// </exception>
        protected override ShapeBase Interpret(string line)
        {
            string[] data = line.Split(' ');
            if (data.Length != ArgumentAmount) 
            {
                throw new System.ArgumentException("Wrong argument amount for square.");
            }
            else 
            {
                topLeft.X = double.Parse(data[0]);
                topLeft.Y = double.Parse(data[1]);
                bottomRight.X = double.Parse(data[2]);
                bottomRight.Y = double.Parse(data[3]);
                return this;                
            }
        }
        /// <summary>
        /// Creates <see cref="Square"/> and fills its fields.
        /// </summary>
        /// <param name="line">
        /// The string data.
        /// </param>
        /// <returns>
        /// Created square into <see cref="ShapeBase"/>.
        /// </returns>
        public static ShapeBase CreateInstance(string line)
        {
            return new Square().Interpret(line);
        }        
        /// <summary>
        /// Writes some information about square to file.
        /// </summary>
        /// <param name="writeStream">
        /// Stream only for writing to file.
        /// </param>
        public override void WriteToFile(System.IO.StreamWriter writeStream)
        {        
            writeStream.WriteLine($"{ID} {topLeft.X} {topLeft.Y} {bottomRight.X} {bottomRight.Y}");
        }
    }
}

