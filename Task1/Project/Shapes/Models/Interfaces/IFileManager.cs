using System.Text;

namespace Shapes.Models.Interfaces
{
    /// <summary>
    /// This interface provides methods for writing to and reading from common file.
    /// </summary>
    public interface IFileManager
    {
        /// <summary>
        /// Represents name of file.
        /// </summary>
        StringBuilder NameOfFile { get; }
        // METHODS
        /// <summary>
        /// Writes some information to file.
        /// </summary>
        /// <param name="fileStream">
        /// Stream for access to file.
        /// </param>
        /// <returns>
        /// The value if writing to file was successfull.
        /// </returns>
        bool WtiteToFile(System.IO.Stream fileStream);
        /// <summary>
        /// Reads some information from file.
        /// </summary>
        /// <param name="fileStream">
        /// Stream for access to file.
        /// </param>
        /// <returns>
        /// The value if reading from file was successfull.
        /// </returns>
        bool ReadFromFile(System.IO.Stream fileStream);
    }
}
