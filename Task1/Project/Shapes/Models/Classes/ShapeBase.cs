using System.Collections.Generic;
using Shapes.Models.Enums;
using Shapes.Models.Interfaces;
using IdentifierCreator = System.Func<System.Type, string>;
using Deserialization = System.Func<string, Shapes.Models.Classes.ShapeBase>;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents basic algorithms for the shape objects.
    /// </summary>
    public abstract class ShapeBase : IShape, IFileManager
    {       
        // FIELDS
        static IdentifierCreator idCreatorByType;
        static Dictionary<string, Deserialization> factory;    
        // PROPERTIES
        /// <summary>
        /// Creator Id by type.
        /// </summary>
        public static IdentifierCreator IdCreatorByType
        {
		
            get
            {
                return idCreatorByType;
            }
            set
            {
                idCreatorByType = value;
            }
        }     
        /// <summary>
        /// Identifier of the shape.
        /// </summary>
        public string ID => ShapeBase.idCreatorByType(this.GetType());
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
            factory = new Dictionary<string, Deserialization>();
            idCreatorByType = (type) => type.Name;
	    
            RegisterShape(typeof(Circle), Circle.CreateInstance);
            RegisterShape(typeof(Square), Square.CreateInstance);
            RegisterShape(typeof(Triangle), Triangle.CreateInstance);	    
        }        
        // METHODS
        static string ReadAWordFromStream(System.IO.StreamReader readStream)
        {
            //In "identifier" will be stored a first word in line from file.
            System.Text.StringBuilder identifier = new System.Text.StringBuilder("");
            for (char letter = (char)readStream.Read(); letter != ' '; letter = (char)readStream.Read())
            {
                identifier.Append(letter);
            }
            return identifier.ToString();
        }	
        /// <summary>
        /// When overridden in a derived class, return the middle point of the shape.
        /// </summary>
        /// <returns>
        /// The middle point of the shape.
        /// </returns>
        protected abstract Point GetMiddlePoint();
        /// <summary>
        /// Register shapes in factory.
        /// </summary>
        /// <param name="type">
        /// Type of the shape.
        /// </param>
        /// <param name="creator">
        /// Creator shapes by <see cref="string"/>.
        /// </param>
        public static void RegisterShape(System.Type type, Deserialization creator)
        {
            factory.Add(idCreatorByType(type), creator);
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
            string identifier = ReadAWordFromStream(readStream);
            if (!factory.ContainsKey(identifier)) 
            {
                throw new System.ArgumentException("The data isn`t recognized.");
            }
            else
            {
                return factory[identifier].Invoke(readStream.ReadLine());
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
            string identifier = ReadAWordFromStream(readStream);
            if (identifier == ID) 
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
