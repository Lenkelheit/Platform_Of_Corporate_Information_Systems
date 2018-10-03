namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents the command <see cref = "Models.Pentagon" /> which changes its stroke color.
    /// </summary>
    public class ChangeStrokeColor : Interfaces.ICommand
    {
        // FILEDS
        private Models.Pentagon Pentagon;
        private System.Windows.Media.Color StrokeColor;
        private System.Windows.Media.Color PrevStrokeColor;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="pentagon">Current pentagon.</param>
        /// <param name="StrokeColor">New color.</param>
        public ChangeStrokeColor(Models.Pentagon pentagon, System.Windows.Media.Color StrokeColor)
        {
            this.Pentagon = pentagon;
            this.StrokeColor = StrokeColor;
        }
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "StrokeColor changed";
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Pentagon"/> stroke color.
        /// </summary>
        public void Execute()
        {
            PrevStrokeColor = Pentagon.StrokeColor;
            Pentagon.StrokeColor = StrokeColor;
        }
        /// <summary>
        /// Returns <see cref="Models.Pentagon"/> to its previous stroke color.
        /// </summary>
        public void UnExecute()
        {
            Pentagon.StrokeColor = StrokeColor;
        }
    }
}
