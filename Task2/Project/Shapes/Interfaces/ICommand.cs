namespace Shapes.Interfaces
{
    /// <summary>
    /// Defines structure of the command.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Returns command name.
        /// </summary>
        string Name { get; }
        /// <summary>
        /// Execute command. Change model's state.
        /// </summary>
        void Execute();
        /// <summary>
        /// Unexecute command. Return model to its previous state.
        /// </summary>
        void UnExecute();
    }
}
