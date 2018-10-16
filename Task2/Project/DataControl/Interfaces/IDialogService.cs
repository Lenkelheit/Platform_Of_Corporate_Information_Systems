namespace DataControl.Interfaces
{
    /// <summary>
    /// Represents service for work with dialog windows.
    /// </summary>
    public interface IDialogService
    {
        /// <summary>
        /// Returns path to selected file.
        /// </summary>
        string FilePath { get; }
        /// <summary>
        /// Returns selected color.
        /// </summary>
        System.Windows.Media.Color Color { get; }
        /// <summary>
        /// Shows some message.
        /// </summary>
        /// <param name="message">Text to showing.</param>
        void ShowMessage(string message);
        /// <summary>
        /// Opens dialog for choosing color.
        /// </summary>
        /// <returns>
        /// True if color was chosen, else - false.
        /// </returns>
        bool ColorDialog();
        /// <summary>
        /// Opens dialog for opening file.
        /// </summary>
        /// <returns>
        /// True if file was opened, else - false.
        /// </returns>
        bool OpenFileDialog();
        /// <summary>
        /// Opens dialog for saving some information to file.
        /// </summary>
        /// <returns>
        /// True if information was saved to file, else - false.
        /// </returns>
        bool SaveFileDialog();
    }
}
