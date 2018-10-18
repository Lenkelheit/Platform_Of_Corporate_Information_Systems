namespace DataControl.Interfaces
{
    /// <summary>
    /// Represents service for work with files.
    /// </summary>
    public interface IFileService
    {
        /// <summary>
        /// Saves information to file.
        /// </summary>
        /// <param name="item">Object to saving.</param>
        /// <param name="fileName">The name of file.</param>
        void Save(Shapes.Models.Canvas item, string fileName);
        /// <summary>
        /// Loads information from file.
        /// </summary>
        /// <param name="item">Object to loading.</param>
        /// <param name="fileName">The name of file.</param>
        void Load(ref Shapes.Models.Canvas item, string fileName);
    }
}
