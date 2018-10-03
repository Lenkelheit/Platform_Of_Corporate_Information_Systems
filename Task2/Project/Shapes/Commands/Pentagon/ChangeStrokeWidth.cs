namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents the command <see cref = "Models.Pentagon" /> which changes its stroke width.
    /// </summary>
    public class ChangeStrokeWidth : Interfaces.ICommand
    {
        // FIELDS
        private Models.Pentagon Pentagon;
        private double StrokeThickness;
        private double PrevStrokeThickness;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="pentagon"></param>
        /// <param name="StrokeThickness"></param>
        public ChangeStrokeWidth(Models.Pentagon pentagon, double StrokeThickness)
        {
            this.Pentagon = pentagon;
            this.StrokeThickness = StrokeThickness;
        }
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "StrokeWidth changed";
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Pentagon"/> stroke width.
        /// </summary>
        public void Execute()
        {
            PrevStrokeThickness = Pentagon.StrokeThickness;
            Pentagon.StrokeThickness = StrokeThickness;
        }
        /// <summary>
        /// Returns <see cref="Models.Pentagon"/> to its previous stroke width.
        /// </summary>
        public void UnExecute()
        {
            Pentagon.StrokeThickness = StrokeThickness;
        }
    }
}
