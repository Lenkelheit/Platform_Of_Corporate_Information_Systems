namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents the command <see cref = "Models.Pentagon" /> which changes its opacity.
    /// </summary>
    public class ChangeOpacity : Interfaces.ICommand
    {
        // FILEDS
        private Models.Pentagon Pentagon;
        private double Opacity;
        private double PrevState;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="Pentagon">Current pentagon.</param>
        /// <param name="Opacity">New opacity.</param>
        public ChangeOpacity(Models.Pentagon Pentagon, double Opacity)
        {
            this.Pentagon = Pentagon;
            this.Opacity = Opacity;
        }
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "Opacity changed";
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Pentagon"/> opacity.
        /// </summary>
        public void Execute()
        {
            PrevState = Pentagon.Opacity;
            Pentagon.Opacity = Opacity;
        }
        /// <summary>
        /// Returns <see cref="Models.Pentagon"/> to its previous opacity.
        /// </summary>
        public void UnExecute()
        {
            Pentagon.Opacity = Opacity;
        }
    }
}

