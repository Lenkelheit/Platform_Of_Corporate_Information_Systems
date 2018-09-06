namespace FileManager.Models.Interfaces
{
    /// <summary>
    /// This interface provides methods for writing to and reading from common file.
    /// </summary>
    interface IFileManager
    {
        // PROPERTY
        /// <summary>
        /// Represents name of file.
        /// </summary>
        StringBuilder NameOfFile { get; }
        // METHOD
        /// <summary>
        /// Writes some information to file.
        /// </summary>
        /// <returns>
        /// The value if writing to file was successfull.
        /// </returns>
        bool WriteToFile();
        // METHOD
        /// <summary>
        /// Reads some information from file.
        /// </summary>
        /// <returns>
        /// The value if reading from file was successfull.
        /// </returns>
        bool ReadFromFile();
    }
}
