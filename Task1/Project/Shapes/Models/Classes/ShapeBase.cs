using System.Collections.Generic;
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
        /// Identifier of the shape.
        /// </summary>
        public string ID => ShapeBase.IdOfTheShape(this.GetType());
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
        /// Creates classes that inherit from <see cref="ShapeBase"/>.
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
        public static ShapeBase MakeInstance(System.IO.StreamReader readStream)
        {
            //In "identifier" will be stored information about what class can be created if it will pass a control.
            System.Text.StringBuilder identifier = new System.Text.StringBuilder("");
            for (char letter = (char)readStream.Read(); letter != ' '; letter = (char)readStream.Read())
            {
                identifier.Append(letter);
            }
            if (!dictionaryOfId.ContainsKey(identifier.ToString())) 
            {
                throw new System.ArgumentException("The data isn`t recognized.");
            }
            else
            {
                return dictionaryOfId[identifier.ToString()].Invoke(readStream.ReadLine());
            }
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
            //In "identifier" will be stored information about what class can be created if it will pass a control.
            System.Text.StringBuilder identifier = new System.Text.StringBuilder("");
            for (char letter = (char)readStream.Read(); letter != ' '; letter = (char)readStream.Read()) 
            {
                identifier.Append(letter);
            }
            if (identifier.ToString() == ID)
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
