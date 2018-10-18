namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents the command <see cref = "Models.Pentagon" /> which changes its color.
    /// </summary>
    public class ChangeColor : Interfaces.ICommand
    {
        // FIELDS
        private Models.Pentagon pentagon;
        private System.Windows.Media.Color color;
        private System.Windows.Media.Color prevColor;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="pentagon">Current pentagon.</param>
        /// <param name="color">New color.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when pentagon is null.</exception>
        public ChangeColor(Models.Pentagon pentagon, System.Windows.Media.Color color)
        {
            if (pentagon != null)
            {
                this.pentagon = pentagon;
                this.color = color;
                this.prevColor = pentagon.Color;
            }
            else
            {
                throw new System.ArgumentNullException("Pentagon is null");
            }
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
            pentagon.Color = color;
        }
        /// <summary>
        /// Returns <see cref="Models.Pentagon"/> to its previous color.
        /// </summary>
        public void UnExecute()
        {
            pentagon.Color = prevColor;
        }
    }
}
