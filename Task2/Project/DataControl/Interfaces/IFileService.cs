namespace DataControl.Interfaces
{
    public interface IFileService
    {
        void Save(Shapes.Models.ShapeBase item, string fileName);
        void Load(out Shapes.Models.ShapeBase item, string fileName);
    }
}
