namespace DataControl.Services
{
    /// <summary>
    /// Represents dialog service for default.
    /// </summary>
    public class DefaultDialogService : Interfaces.IDialogService
    {
        // FIELDS
        private string filePath;
        private System.Drawing.Color color;

        // PROPERTIES
        /// <summary>
        /// Returns path to selected file.
        /// </summary>
        public string FilePath
        {
            get
            {
                return filePath;
            }
        }
        /// <summary>
        /// Returns selected color.
        /// </summary>
        public System.Drawing.Color Color
        {
            get
            {
                return color;
            }
        }

        // METHODS
        /// <summary>
        /// Opens dialog for choosing color.
        /// </summary>
        /// <returns>
        /// True if color was chosen, else - false.
        /// </returns>
        public bool ColorDialog()
        {
            System.Windows.Forms.ColorDialog colorDialog = new System.Windows.Forms.ColorDialog();
            if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                color = colorDialog.Color;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Opens dialog for opening file.
        /// </summary>
        /// <returns>
        /// True if file was opened, else - false.
        /// </returns>
        public bool OpenFileDialog()
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
            if (openFileDialog.ShowDialog() == true) 
            {
                filePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Opens dialog for saving some information to file.
        /// </summary>
        /// <returns>
        /// True if information was saved to file, else - false.
        /// </returns>
        public bool SaveFileDialog()
        {
            Microsoft.Win32.SaveFileDialog saveFileDialog = new Microsoft.Win32.SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                filePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }
        /// <summary>
        /// Shows some message.
        /// </summary>
        /// <param name="message">Text to showing.</param>
        public void ShowMessage(string message)
        {
            System.Windows.MessageBox.Show(message);
        }
    }
}
