namespace Shapes.Commands.Vertex
{
    /// <summary>
    /// Represents command of removing <see cref="Models.Vertex"/>.
    /// </summary>
    public class RemoveVertex : Interfaces.ICommand
    {
        // FIELDS
        private Models.Vertex vertex;
        private Models.Canvas canvas;
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "Vertex removed";
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="canvas">Current canvas.</param>
        /// <param name="vertex">Current vertex.</param>
        public RemoveVertex(Models.Canvas canvas, Models.Vertex vertex)
        {
            this.canvas = canvas;
            this.vertex = vertex;
        }
        // METHODS
        /// <summary>
        /// Removes <see cref="Models.Vertex"/>.
        /// </summary>
        public void Execute()
        {
            canvas?.Remove(vertex);
        }
        /// <summary>
        /// Restores removed <see cref="Models.Vertex"/>.
        /// </summary>
        public void UnExecute()
        {
            canvas.Add(vertex);
        }
    }
}
