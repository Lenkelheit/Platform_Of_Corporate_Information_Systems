namespace Shapes.Models
{
    [System.Serializable]
    public class Vertex : ShapeBase
    {
        internal static int numberOfVertex;
        public int NumberOfVertex
        {
            get
            {
                return numberOfVertex;
            }
            set
            {
                numberOfVertex = value;
            }
        }
        public System.Windows.Point Location { get; set; }
    }
}
