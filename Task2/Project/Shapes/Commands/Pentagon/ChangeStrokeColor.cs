namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents the command <see cref = "Models.Pentagon" /> which changes its stroke color.
    /// </summary>
    public class ChangeStrokeColor : Interfaces.ICommand
    {
        // FILEDS
        private Models.Pentagon pentagon;
        private System.Windows.Media.Color strokeColor;
        private System.Windows.Media.Color prevStrokeColor;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="pentagon">Current pentagon.</param>
        /// <param name="strokeColor">New color.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when pentagon is null.</exception>
        public ChangeStrokeColor(Models.Pentagon pentagon, System.Windows.Media.Color strokeColor)
        {
            if (pentagon != null)
            {
                this.pentagon = pentagon;
                this.strokeColor = strokeColor;
                this.prevStrokeColor = pentagon.StrokeColor;
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
        public string Name => "Stroke Color changed";
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Pentagon"/> stroke color.
        /// </summary>
        public void Execute()
        {
            pentagon.StrokeColor = strokeColor;
        }
        /// <summary>
        /// Returns <see cref="Models.Pentagon"/> to its previous stroke color.
        /// </summary>
        public void UnExecute()
        {
            pentagon.StrokeColor = prevStrokeColor;
        }
    }
}

