namespace Shapes.Models
{
    /// <summary>
    /// Represents one of points for creating the shape objects.
    /// </summary>
    [System.Serializable]
    public class Vertex : ShapeBase
    {
        // CONST
        private const int RADIUS = 5;
        // FIELDS
        private System.Windows.Point location;
        internal static int NumberOfVertex { get; set; }
        // PROPERTIES
        /// <summary>
        /// Point position on the coordinate plane.
        /// </summary>
        public System.Windows.Point Location
        {
            get
            {
                return location;
            }
            set
            {
                if (location != value)  
                {
                    location = value;
                    OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("Location"));
                }
            }
        }
        // CONSTRUCTORS
        /// <summary>
        /// Basic constructor without parameters.
        /// </summary>
        public Vertex()
        {
            location = new System.Windows.Point();
        }
        // METHODS
        /// <summary>
        /// Calculates distance between two vertices.
        /// </summary>
        /// <param name="firstVertex">First vertex.</param>
        /// <param name="secondVertex">Second vertex.</param>
        /// <returns>
        /// The distance between two vertices.
        /// </returns>
        public static double GetDistance(Vertex firstVertex, Vertex secondVertex)
        {
            return System.Math.Sqrt(System.Math.Pow(secondVertex.Location.X - firstVertex.Location.X, 2) +
                System.Math.Pow(secondVertex.Location.Y - firstVertex.Location.Y, 2));
        }
        /// <summary>
        /// Checks if current point is in vertex.
        /// </summary>
        /// <param name="point">Current point.</param>
        /// <returns>
        /// True if current point is in vertex, else - false.
        /// </returns>
        public override bool HitTest(System.Windows.Point point)
        {
            return GetDistance(this, new Vertex { Location = point }) <= RADIUS;
        }
    }
}
