namespace Shapes.Commands.Vertex
{
    /// <summary>
    /// Represents command for <see cref="Models.Vertex"/> that changes its location.
    /// </summary>
    public class ChangeLocation : Interfaces.ICommand
    {
        // FIELDS
        private Models.Vertex vertex;
        private System.Windows.Point location;
        private System.Windows.Point prevLocation;
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "Vertex location changed";
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="vertex">Current vertex.</param>
        /// <param name="location">New location.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when vertex is null.
        /// </exception> 
        public ChangeLocation(Models.Vertex vertex, System.Windows.Point location)
        {
            if (vertex != null)
            {
                this.vertex = vertex;
                this.location = location;
                this.prevLocation = vertex.Location;
            }
            else
            {
                throw new System.ArgumentNullException("Vertex is null.");
            }
        }
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Vertex"/>'s location.
        /// </summary>
        public void Execute()
        {
            vertex.Location = location;
        }
        /// <summary>
        /// Returns <see cref="Models.Vertex"/> to its previous location.
        /// </summary>
        public void UnExecute()
        {
            vertex.Location = prevLocation;
        }
    }
}
