namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents the command <see cref = "Models.Pentagon" /> which changes its stroke width.
    /// </summary>
    public class ChangeStrokeWidth : Interfaces.ICommand
    {
        // FIELDS
        private Models.Pentagon pentagon;
        private double strokeThickness;
        private double prevStrokeThickness;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="pentagon"></param>
        /// <param name="strokeThickness"></param>
        /// <exception cref="System.ArgumentNullException">Thrown when pentagon is null.</exception>
        public ChangeStrokeWidth(Models.Pentagon pentagon, double strokeThickness)
        {
            if (pentagon != null)
            {
                this.pentagon = pentagon;
                this.strokeThickness = strokeThickness;
                this.prevStrokeThickness = pentagon.StrokeThickness;
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
        public string Name => "Stroke Width changed";
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Pentagon"/> stroke width.
        /// </summary>
        public void Execute()
        {
            pentagon.StrokeThickness = strokeThickness;
        }
        /// <summary>
        /// Returns <see cref="Models.Pentagon"/> to its previous stroke width.
        /// </summary>
        public void UnExecute()
        {
            pentagon.StrokeThickness = prevStrokeThickness;
        }
    }
}
