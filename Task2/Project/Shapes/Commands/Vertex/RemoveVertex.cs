namespace Shapes.Commands.Vertex
{
    /// <summary>
    /// Represents command of removing <see cref="Models.Vertex"/>.
    /// </summary>
    public class RemoveVertex : Interfaces.ICommand
    {
        // FIELDS
        private Models.Vertex vertex;
        private System.Windows.Point prevLocation;
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "Vertex removed";
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="vertex">Current vertex.</param>
        public RemoveVertex(Models.Vertex vertex)
        {
            this.vertex = vertex;
        }
        // METHODS
        /// <summary>
        /// Removes <see cref="Models.Vertex"/>.
        /// </summary>
        public void Execute()
        {
            if (vertex.Location.X != 0 || vertex.Location.Y != 0) 
            {
                prevLocation = vertex.Location;
                vertex.Location = new System.Windows.Point(0, 0);
            }
        }
        /// <summary>
        /// Restores removed <see cref="Models.Vertex"/>.
        /// </summary>
        public void UnExecute()
        {
            vertex.Location = prevLocation;
        }
    }
}
