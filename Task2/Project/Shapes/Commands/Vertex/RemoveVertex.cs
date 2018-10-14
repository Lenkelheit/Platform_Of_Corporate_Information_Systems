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
        private int index;
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
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when canvas is null.
        /// </exception>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when vertex is null.
        /// </exception>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when vertex hasn`t been found in canvas.
        /// </exception>
        public RemoveVertex(Models.Canvas canvas, Models.Vertex vertex)
        {
            if (canvas == null)
            {
                throw new System.ArgumentNullException("Canvas is null.");
            }
            if (vertex == null)
            {
                throw new System.ArgumentNullException("Vertex is null.");
            }
            this.canvas = canvas;
            this.vertex = vertex;
            index = canvas.IndexOf(vertex);
            if (index == -1)
            {
                throw new System.ArgumentOutOfRangeException("Vertex hasn`t been found.");
            }
        }
        // METHODS
        /// <summary>
        /// Removes <see cref="Models.Vertex"/>.
        /// </summary>
        public void Execute()
        {
            canvas.RemoveAt(index);
        }
        /// <summary>
        /// Restores removed <see cref="Models.Vertex"/>.
        /// </summary>
        public void UnExecute()
        {
            canvas.Insert(index, vertex);
        }
    }
}
