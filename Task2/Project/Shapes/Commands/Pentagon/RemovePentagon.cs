using Shapes.Models;

namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Class that represents command for removing pentagon
    /// </summary>
    public class RemovePentagon : Interfaces.ICommand
    {
        // FIELDS
        Canvas baseCanvas;
        Models.Pentagon target;
        int positionInCanvas;

        //CONSTRUCTORS
        /// <summary>
        /// Constructor with 2 parameters
        /// </summary>
        /// <param name="baseCanvas">Basic canvas from which will be removed pentagon</param>
        /// <param name="target">Pentagon that will be removed</param>
        /// <exception cref="System.NullReferenceException">Pentagon or canvas doesn't exist!</exception>
        RemovePentagon(Canvas baseCanvas, Models.Pentagon target)
        {
            if (target != null)
            {
                if (baseCanvas != null)
                {
                    this.target = target;
                    this.baseCanvas = baseCanvas;
                }
                else
                {
                    throw new System.NullReferenceException("Canvas doesn't exist!");
                }
            }
            else
            {
                throw new System.NullReferenceException("Pentagon doesn't exist!");
            }
        }

        // PROPETRIES
        /// <summary>
        /// Property that allows to get command name
        /// </summary>
        public string Name
        {
            get
            {
                return "Pentagon removed";
            }
        }

        // METHODS
        /// <summary>
        /// Method that execute command
        /// </summary>
        public void Execute()
        {
                positionInCanvas = baseCanvas.IndexOf(target);
                baseCanvas.RemoveAt(positionInCanvas);
        }
        /// <summary>
        /// Method that returns command execution
        /// </summary>
        public void UnExecute()
        {
            baseCanvas.Insert(positionInCanvas, target);
        }
    }
}
