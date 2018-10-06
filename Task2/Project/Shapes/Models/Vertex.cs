namespace Shapes.Models
{
    [System.Serializable]
    public class Vertex : ShapeBase
    {
        internal static int NumberOfVertex { get; set; }
        public System.Windows.Point Location { get; set; }
    }
}
