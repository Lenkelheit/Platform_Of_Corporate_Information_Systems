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
        public string Name => "Location changed";
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="vertex">Current vertex.</param>
        /// <param name="location">New location.</param>
        public ChangeLocation(Models.Vertex vertex, System.Windows.Point location)
        {
            this.vertex = vertex;
            this.location = location;
        }
        // METHODS
        /// <summary>
        /// Changes <see cref="Models.Vertex"/>'s state.
        /// </summary>
        public void Execute()
        {
            prevLocation = vertex.Location;
            vertex.Location = location;
        }
        /// <summary>
        /// Returns <see cref="Models.Vertex"/> to its previous state.
        /// </summary>
        public void UnExecute()
        {
            vertex.Location = prevLocation;
        }
    }
}
