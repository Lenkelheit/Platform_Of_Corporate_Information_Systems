using Shapes.Models.Enums;
using Shapes.Models.Interfaces;
using IdentifierShape = System.Func<System.Type, string>;
using Deserialization = System.Func<string, Shapes.Models.Classes.ShapeBase>;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents basic algorithms for the shape objects.
    /// </summary>
    public abstract class ShapeBase : IShape, IFileManager
    {       
        // FIELDS
        static IdentifierShape idOfTheShape;
        static Dictionary<string, Deserialization> dictionaryOfId;    
        // PROPERTIES
        /// <summary>
        /// The identifier of the shape.
        /// </summary>
        public static IdentifierShape IdOfTheShape
        {
            get
            {
                return idOfTheShape;
            }
            set
            {
                idOfTheShape = value;
            }
        }        
        /// <summary>
        /// When overridden in a derived class, returns the identifier of the shape.
        /// </summary>
        public abstract string ID { get; }
        /// <summary>
        /// When overridden in a derived class, returns the number of simple elements of the shape.
        /// </summary>
        public abstract uint ArgumentAmount { get; }       
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
        // CONSTRUCTOR
        static ShapeBase()
        {
            dictionaryOfId = new Dictionary<string, Deserialization>();
            idOfTheShape = (type) => type.Name;
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
        /// Register shapes in dictionary of Id.
        /// </summary>
        /// <param name="key">
        /// Id of the shape.
        /// </param>
        /// <param name="transformer">
        /// Transformer <see cref="string"/> to <see cref="ShapeBase"/>.
        /// </param>
        public static void RegisterShape(string key, Deserialization transformer)
        {
            dictionaryOfId.Add(key, transformer);
        }        
        /// <summary>
        /// When overridden in a derived class, interprets string as numeric data.
        /// </summary>
        /// <param name="line">
        /// The string data.
        /// </param>
        /// <returns>
        /// When overridden in a derived class, returns filled shape into <see cref="ShapeBase"/>.
        /// </returns>
        protected abstract ShapeBase Interpret(string line);      
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
            //In "name" will be stored information about what class can be created.
            System.Text.StringBuilder name = new System.Text.StringBuilder("");
            char letter = ' ';
            while ((letter = (char)readStream.Read()) != ' ')
            {
                name.Append(letter);
            }
            if (name.ToString() == ID)
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
    }
}
