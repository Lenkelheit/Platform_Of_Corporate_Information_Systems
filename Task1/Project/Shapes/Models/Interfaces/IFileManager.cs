namespace Shapes.Models.Interfaces
{
    /// <summary>
    /// Provides methods for writing to and reading from file.
    /// </summary>
    public interface IFileManager
    {
         /// <summary>
        /// Identifier for shape.
        /// </summary>
        string ID { get; }
        /// <summary>
        /// Number of elements for shape.
        /// </summary>
        uint ArgumentAmount { get; }       
        /// <summary>
        /// Reads some information from file.
        /// </summary>
        /// <param name="readStream">
        /// Stream for access to file and is only for reading from it.
        /// </param>
        void ReadFromFile(System.IO.StreamReader readStream);
        /// <summary>
        /// Writes some information to file.
        /// </summary>
        /// <param name="writeStream">
        /// Stream for access to file and is only for writing to it.
        /// </param>
        void WriteToFile(System.IO.StreamWriter writeStream);
    }
}

