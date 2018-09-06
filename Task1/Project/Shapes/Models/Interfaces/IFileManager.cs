namespace Shapes.Models.Interfaces
{
    public interface IFileManager
    {
        void ReadFromFile(System.IO.Stream fileStream);
        void WtiteToFile(System.IO.Stream fileStream);
    }
}
