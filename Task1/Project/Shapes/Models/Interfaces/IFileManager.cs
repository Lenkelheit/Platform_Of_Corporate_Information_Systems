namespace Shapes.Models.Interfaces
{
    /// <summary>
    /// Provides methods for writing to and reading from file.
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Reads some information from file.
        /// </summary>
        /// <param name="readStream">
        /// Stream for access to file.
        /// </param>
        void ReadFromFile(System.IO.StreamReader readStream);
        /// <summary>
        /// Writes some information to file.
        /// </summary>
        /// <param name="writeStream">
        /// Stream for access to file.
        /// </param>
        void WtiteToFile(System.IO.StreamWriter writeStream);
    }
}

