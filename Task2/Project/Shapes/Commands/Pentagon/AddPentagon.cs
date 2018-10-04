using System.Collections.Generic;
using System.Linq;
namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents command of adding <see cref="Models.Pentagon"/>.
    /// </summary>
    public class AddPentagon : Interfaces.ICommand
    {
        // CONST
        private const int COUNT_VERTEX = 5;
        // FIELDS
        private Models.Canvas canvas;
        private Models.Vertex[] arrVertices;
        private Models.Pentagon pentagon;
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "Pentagon added";
        // CONSTRUCTORS
        /// <summary>
        /// Constructor with parameters.
        /// </summary>
        /// <param name="canvas">Current canvas.</param>
        /// <exception cref="System.ArgumentNullException">
        /// Thrown when canvas is null.
        /// </exception>
        public AddPentagon(Models.Canvas canvas)
        {
            if (canvas == null)
            {
                throw new System.ArgumentNullException("Canvas is null.");
            }
            this.canvas = canvas;
        }
        // METHODS
        private IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1)
            {
                return list.Select(t => new T[] { t });
            }
            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
        }
        private double CalculateDistanceByIndeces(Models.Vertex[] arrVertices, int[] indices)
        {
            double distance = 0;
            for (int i = 1; i < COUNT_VERTEX; i++) 
            {
                distance += Models.Vertex.GetDistance(arrVertices[indices[i - 1]], arrVertices[indices[i]]);
            }
            return distance += Models.Vertex.GetDistance(arrVertices[indices[0]], arrVertices[indices[COUNT_VERTEX - 1]]);
        }
        private int[] SortIndicesForVertices(Models.Vertex[] arrVertices)
        {
            double minDistance = double.MaxValue, localDistance = 0;
            int indexOfMinDistance = 0;
            int[] arrIndices = new int[COUNT_VERTEX];
            for (int i = 0; i < COUNT_VERTEX; i++)
            {
                arrIndices[i] = i;
            }
            var matrixIndices = GetPermutations(arrIndices, COUNT_VERTEX).ToArray();
            for (int i = 0; i < matrixIndices.Length; i++) 
            {
                localDistance = CalculateDistanceByIndeces(arrVertices, matrixIndices[i].ToArray());
                if (localDistance < minDistance)
                {
                    minDistance = localDistance;
                    indexOfMinDistance = i;
                }
            }
            return matrixIndices[indexOfMinDistance].ToArray();
        }
        /// <summary>
        /// Adds <see cref="Models.Pentagon"/>.
        /// </summary>
        public void Execute()
        {
            if (pentagon == null) 
            {
                arrVertices = canvas.Shapes.OfType<Models.Vertex>().ToArray();
                var arrPoints = (arrVertices.Select(vertex => vertex.Location)).ToArray();
                System.Array.Sort(SortIndicesForVertices(arrVertices), arrPoints);
                pentagon = new Models.Pentagon
                {
                    Points = arrPoints
                };
            }
            canvas.RemoveAll(vertex => vertex is Models.Vertex);
            canvas.Add(pentagon);
        }        
        /// <summary>
        /// Restores previous state without added <see cref="Models.Pentagon"/>.
        /// </summary>
        public void UnExecute()
        {
            canvas.Remove(pentagon);
            for (int i = 0; i < COUNT_VERTEX; i++)
            {
                canvas.Add(arrVertices[i]);
            }
        }
    }
}
