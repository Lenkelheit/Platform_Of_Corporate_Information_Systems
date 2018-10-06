namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents the command <see cref = "Models.Pentagon" /> which changes its opacity.
    /// </summary>
    public class ChangeOpacity : Interfaces.ICommand
    {
        // FILEDS
        private Models.Pentagon pentagon;
        private double opacity;
        private double prevState;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="pentagon">Current pentagon.</param>
        /// <param name="opacity">New opacity.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when pentagon is null.</exception>
        public ChangeOpacity(Models.Pentagon pentagon, double opacity)
        {
            if (pentagon != null)
            {
                this.pentagon = pentagon;
                this.opacity = opacity;
                this.prevState = pentagon.Opacity;
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
        public string Name => "Opacity changed";
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Pentagon"/> opacity.
        /// </summary>
        public void Execute()
        {
            pentagon.Opacity = opacity;
        }
        /// <summary>
        /// Returns <see cref="Models.Pentagon"/> to its previous opacity.
        /// </summary>
        public void UnExecute()
        {
            pentagon.Opacity = prevState;
        }
    }
}

