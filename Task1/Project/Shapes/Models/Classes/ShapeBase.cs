using Shapes.Models.Enums;
using Shapes.Models.Interfaces;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents basic algorithms for the shape objects.
    /// </summary>
    public abstract class ShapeBase : IShape, IFileManager
    {
        /// <summary>
        /// Stores number of elements for shape.
        /// </summary>
        protected int numberElementsForShape;
        // PROPERTIES
        /// <summary>
        /// When overridden in a derived class, returns the perimeter of the shape.
        /// </summary>
        public abstract double GetPerimeter { get; }
        /// <summary>
        /// When overridden in a derived class, returns the square of the shape.
        /// </summary>
        public abstract double GetSquare { get; }
        /// <summary>
        /// Returns the position of the shape whithin coordinate querter.
        /// </summary>
        public CoordinateQuarters GetQuarter
        {
            get
            {
                Point middlePoint = GetMiddlePoint();

                if(middlePoint.X > 0)
                {
                    return middlePoint.Y > 0 ? CoordinateQuarters.First : CoordinateQuarters.Fourth;
                }
                else return middlePoint.Y > 0 ? CoordinateQuarters.Second : CoordinateQuarters.Third;
            }
        }
        // METHODS
        /// <summary>
        /// When overridden in a derived class, return the middle point of the shape.
        /// </summary>
        /// <returns>
        /// The middle point of the shape.
        /// </returns>
        protected abstract Point GetMiddlePoint();
        /// <summary>
        /// When overridden in a derived class, interprets string as numeric data.
        /// </summary>
        /// <param name="line">
        /// The string data.
        /// </param>
        protected abstract void Interpret(string line);       
        /// <summary>
        /// Reads some information about circle from file.
        /// </summary>
        /// <param name="readStream">
        /// Stream only for reading from file.
        /// </param>
        /// <exception cref="System.ArgumentException ">
        /// Thrown when the first word in line from file isn`t recognized.
        /// </exception>
        public void ReadFromFile(System.IO.StreamReader readStream)
        {
            //In "name" will be stored information that class "Circle" will be read.
            StringBuilder name = new StringBuilder("");
            char letter = ' ';
            while ((letter = (char)readStream.Read()) != ' ')
            {
                name.Append(letter);
            }
            if (name.ToString() == GetType().Name)
            {
                Interpret(readStream.ReadLine());
            }
            else
            {
                throw new System.ArgumentException("The data isn`t recognized.");
            }
        }
        /// <summary>
        /// When overridden in a derived class, writes information to file.
        /// </summary>
        /// <param name="writeStream">
        /// The file stream.
        /// </param>
        public abstract void WriteToFile(System.IO.StreamWriter writeStream);
        /// <summary>
        /// Creates classes that inherit from "ShapeBase".
        /// </summary>
        /// <param name="readStream">
        /// Stream only for reading from file.
        /// </param>
        /// <returns>
        /// Instance of the corresponding class.
        /// </returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the first word in line from file isn`t recognized.
        /// </exception>
        public static ShapeBase CreateInstance(System.IO.StreamReader readStream)
        {
            //In "name" will be stored information about what class must be created.
            StringBuilder name = new StringBuilder("");
            char letter = ' ';
            while ((letter = (char)readStream.Read()) != ' ') 
            {
                name.Append(letter);
            }
            if (name.ToString() == "Circle")
            {
                Circle circle = new Circle();
                circle.Interpret(readStream.ReadLine());
                return circle;
            }
            else if (name.ToString() == "Square")
            {
                Square square = new Square();
                square.Interpret(readStream.ReadLine());
                return square;
            }
            else if (name.ToString() == "Triangle") 
            {
                Triangle triangle = new Triangle();
                triangle.Interpret(readStream.ReadLine());
                return triangle;
            }
            else
            {
                throw new System.ArgumentException("The data isn`t recognized.");
            }
        }        
    }
}
