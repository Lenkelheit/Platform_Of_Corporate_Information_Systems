namespace Shapes.Interfaces
{
    public interface ICommand
    {
        string Name { get; }
        void Execute();
        void UnExecute();
    }
}
