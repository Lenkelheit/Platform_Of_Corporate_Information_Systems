namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents the command <see cref = "Models.Pentagon" /> which changes its location.
    /// </summary>
    public class ChangeLocation : Interfaces.ICommand
    {
        // FIELDS
        private Models.Pentagon pentagon;
        private System.Windows.Point point;
        private System.Windows.Point[] prevLocation;
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="pentagon">Current pentagon.</param>
        /// <param name="point">New points.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when pentagon is null.</exception>
        public ChangeLocation(Models.Pentagon pentagon, System.Windows.Point point)
        {
            if (pentagon != null)
            {
                this.pentagon = pentagon;
                this.point = point;
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
        public string Name => "Location changed";
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Pentagon"/> location.
        /// </summary>
        public void Execute()
        {
            prevLocation = pentagon.Points;
            for(int i = 0; i < 5; ++i)
            {
                pentagon.Points[i].X += point.X;
                pentagon.Points[i].Y += point.Y;
            }
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
