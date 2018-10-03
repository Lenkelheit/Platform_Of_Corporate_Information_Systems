namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents the command <see cref = "Models.Pentagon" /> which changes its color.
    /// </summary>
    public class ChangeColor : Interfaces.ICommand
    {
        // FIELDS
        private Models.Pentagon Pentagon;
        private System.Windows.Media.Color Color;
        private System.Windows.Media.Color PrevColor;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="pentagon">Current pentagon.</param>
        /// <param name="color">New color.</param>
        public ChangeColor(Models.Pentagon pentagon, System.Windows.Media.Color color)
        {
            this.Pentagon = pentagon;
            this.Color = color;
        }
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "Color changed";
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Pentagon"/> color.
        /// </summary>
        public void Execute()
        {
            PrevColor = Pentagon.Color;
            Pentagon.Color = Color;
        }
        /// <summary>
        /// Returns <see cref="Models.Pentagon"/> to its previous color.
        /// </summary>
        public void UnExecute()
        {
            Pentagon.Color = PrevColor;
        }
    }
}
