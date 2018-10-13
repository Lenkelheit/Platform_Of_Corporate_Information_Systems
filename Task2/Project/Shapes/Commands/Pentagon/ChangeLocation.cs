namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents the command <see cref = "Models.Pentagon" /> which changes its location.
    /// </summary>
    public class ChangeLocation : Interfaces.ICommand
    {
        // FIELDS
        private Models.Pentagon pentagon;
        private System.Windows.Point[] points;
        private System.Windows.Point[] prevLocation;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="pentagon">Current pentagon.</param>
        /// <param name="points">New points.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when pentagon is null.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when points is null.</exception>
        public ChangeLocation(Models.Pentagon pentagon, System.Windows.Point[] points)
        {
            if (pentagon == null)
            { 
                throw new System.ArgumentNullException("Pentagon is null");
            }
            if (points == null)
            {
                throw new System.ArgumentNullException("Points is null");
            }
            this.pentagon = pentagon;
            this.points = points;
            this.prevLocation = pentagon.Points;
        }
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "Location changed";
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Pentagon"/> location.
        /// </summary>
        public void Execute()
        {
            pentagon.Points = points;
        }
        /// <summary>
        /// Returns <see cref="Models.Pentagon"/> to its previous location.
        /// </summary>
        public void UnExecute()
        {
            pentagon.Points = prevLocation;
        }
    }
}
