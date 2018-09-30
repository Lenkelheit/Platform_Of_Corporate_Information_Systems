namespace Shapes.Models
{
    /// <summary>
    /// Represents one of points for creating the shape objects.
    /// </summary>
    [System.Serializable]
    public class Vertex : ShapeBase
    {
        // FIELDS
        private System.Windows.Point location;
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
            location = new System.Windows.Point(0, 0);
        }
    }
}
