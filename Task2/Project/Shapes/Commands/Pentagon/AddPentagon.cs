namespace Shapes.Commands.Pentagon
{
    /// <summary>
    /// Represents command of adding <see cref="Models.Pentagon"/>.
    /// </summary>
    public class AddPentagon : Interfaces.ICommand
    {
        // PROPERTIES
        /// <summary>
        /// Command name.
        /// </summary>
        public string Name => "Pentagon added";
        /// <summary>
        /// Adds <see cref="Models.Pentagon"/>.
        /// </summary>
        public void Execute()
        {
            throw new System.NotImplementedException();
        }
        /// <summary>
        /// Restores previous state without added <see cref="Models.Pentagon"/>.
        /// </summary>
        public void UnExecute()
        {
            throw new System.NotImplementedException();
        }
    }
}
