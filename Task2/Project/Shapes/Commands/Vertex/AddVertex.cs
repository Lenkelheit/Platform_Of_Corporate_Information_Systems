using System.Collections.Generic;

namespace Shapes.Commands.Vertex
{
    /// <summary>
    /// Class that represents command for adding vertex to pentagon
    /// </summary>
    public class AddVertex : Interfaces.ICommand
    {
        // CONSTANTS
        const int NUM_OF_EDGES_IN_PENTAGON = 5;

        // FIELDS
        Models.Canvas baseCanvas;
        Models.Vertex target;
        Models.UndoRedoManager workCommandManger;


        //CONSTRUCTORS
        /// <summary>
        /// Constructor with 3 parameters
        /// </summary>
        /// <param name="baseCanvas">Vertex in which will be added vertex</param>
        /// <param name="target">Added vertex</param>
        /// <param name="workCommandManger">program command manager</param>
        /// <exception cref="System.NullReferenceException">Pentagon, command manager or vertex doesn't exist!</exception>
        AddVertex(Models.Canvas baseCanvas, Models.Vertex target, Models.UndoRedoManager workCommandManger)
        {
            if (baseCanvas != null)
            {

                if (target != null)
                {
                    if (workCommandManger != null)
                    {
                        this.baseCanvas = baseCanvas;
                        this.target = target;
                        this.workCommandManger = workCommandManger;  
                    }
                    else
                    {
                        throw new System.NullReferenceException("Pentagon or vertex doesn't exist!");
                    }
                }
                else
                {
                    throw new System.NullReferenceException("Pentagon or vertex doesn't exist!");
                }
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
        /// <returns>Command name</returns>
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
            baseCanvas.Add(target);
            target.NumberOfVertex++;
            if (target.NumberOfVertex == NUM_OF_EDGES_IN_PENTAGON)
            {
                workCommandManger.PopUndo();
                workCommandManger.Execute(new Pentagon.AddPentagon(baseCanvas));
            }
        }
        /// <summary>
        /// Method that returns command execution
        /// </summary>
        /// <exception cref="System.NullReferenceException">Vertex doesn't exist!</exception>
        public void UnExecute()
        {
            if (target.NumberOfVertex == 0)
            {
                throw new System.NullReferenceException("Vertex doesn't exist!");
            }
            else
            {
                baseCanvas.RemoveAt(target.NumberOfVertex - 1);
                target.NumberOfVertex--;
            }

        }
    }
}
