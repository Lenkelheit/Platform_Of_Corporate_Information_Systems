namespace DataControl.Interfaces
{
    public interface IFileService
    {
        void Save(Shapes.Models.Canvas item, string fileName);
        void Load(out Shapes.Models.Canvas item, string fileName);
    }
}
