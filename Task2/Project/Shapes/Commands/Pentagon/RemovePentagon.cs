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
            for (int i = 0; i < baseCanvas.Count; i++)
            {
                if (baseCanvas[i] == target)
                {
                    positionInCanvas = i;
                    break;
                }
            }
            baseCanvas.Remove(target);
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
