using System.Collections.Generic;

namespace Shapes.Commands.Vertex
{
    /// <summary>
    /// Class that represents command for adding vertex to pentagon
    /// </summary>
    public class AddVertex : Interfaces.ICommand
    {
        // CONSTANTS
        const int numOfEdgesInPentagon = 5;

        // FIELDS
        Models.Canvas baseCanvas;
        Models.Vertex target;


        //CONSTRUCTORS
        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="baseCanvas">Vertex in which will be added vertex</param>
        /// <param name="target">Added vertex</param>
        /// <exception cref="System.NullReferenceException">Pentagon or vertex doesn't exist!</exception>
        AddVertex(Models.Canvas baseCanvas, Models.Vertex target)
        {
            if (baseCanvas != null && target != null)
            {
                this.baseCanvas = baseCanvas;
                this.target = target;
            }
            else
            {
                throw new System.NullReferenceException("Pentagon or vertex doesn't exist!");
            }
        }

        // PROPERTIES
        /// <summary>
        /// Property that enable to interract with command name
        /// </summary>
        /// /// <returns>Command name</returns>
        public string Name
        {
            get
            {
                return "Vertex added";
            }
        }

        // METHODS
        /// <summary>
        /// Method that execute command
        /// </summary>
        public void Execute()
        {
            baseCanvas.PresentVertex.Add(target);
            if (baseCanvas.PresentVertex.Count == numOfEdgesInPentagon)
            {
                Models.Pentagon newPentagon = new Models.Pentagon();
                for (int i = 0; i < numOfEdgesInPentagon; i++)
                {
                    newPentagon.Points[i] = baseCanvas.PresentVertex[i].Location;
                }
                new Pentagon.AddPentagon(baseCanvas, newPentagon).Execute();
                baseCanvas.PresentVertex.Clear();

            }
        }
        /// <summary>
        /// Method that returns command execution
        /// </summary>
        /// <exception cref="System.NullReferenceException">Vertex doesn't exist!</exception>
        public void UnExecute()
        {
            if (baseCanvas.PresentVertex.Count == 0)
            {
                throw new System.NullReferenceException("Vertex doesn't exist!");
            }
            else
            {
                baseCanvas.PresentVertex.RemoveAt(baseCanvas.PresentVertex.Count - 1);
            }

        }
    }
}
