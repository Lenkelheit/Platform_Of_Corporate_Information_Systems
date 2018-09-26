namespace Shapes.Models
{
    [System.Serializable]
    public abstract class ShapeBase
    {
        public string Name => this.GetType().Name;
    }
}
