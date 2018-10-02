using System.ComponentModel;

namespace Shapes.Models
{
    /// <summary>
    /// Represents class that models Pentagon
    /// </summary>
    [System.Serializable]
    public class Pentagon : ShapeBase, INotifyPropertyChanged
    { 
        // FIELDS
        /// <summary>
        /// Field that contains color of Pentagon
        /// </summary>
        System.Windows.Media.Color color;
        /// <summary>
        /// Field that contains stroke color  of Pentagon
        /// </summary>
        System.Windows.Media.Color strokeColor;
        /// <summary>
        /// Field that contains stroke thickness of Pentagon
        /// </summary>
        double strokeThickness;
        /// <summary>
        /// Field that contains opacity of Pentagon
        /// </summary>
        double opacity;
        /// <summary>
        /// Field that contains arrat of points which builds Pentagon
        /// </summary>
        System.Windows.Point[] points;
        /// <summary>
        /// Event that messages about property change
        /// </summary>
        new public event PropertyChangedEventHandler PropertyChanged;

        // PROPERTIES
        /// <summary>
        /// Property that enable to interract with color
        /// </summary>
        /// /// <retruns>Pentagon color</retruns>
        public System.Windows.Media.Color Color
        {
            get
            {
                return color;
            }
            set
            {
                if (color != value)
                {
                    color = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Color"));
                }
            }
        }
        /// <summary>
        /// Property that enable to interract with stroke color
        /// </summary>
        /// /// <retruns>Pentagon stroke color</retruns>
        public System.Windows.Media.Color StrokeColor
        {
            get
            {
                return strokeColor;
            }
            set
            {
                if (strokeColor != value)
                {
                    strokeColor = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("StrokeColor"));
                }
            }
        }
        /// <summary>
        /// Property that enable to interract with stroke thickness
        /// </summary>
        /// /// <retruns>Pentagon stroke thickness</retruns>
        public double StrokeThickness
        {
            get
            {
                return strokeThickness;
            }
            set
            {
                if (strokeThickness != value)
                {
                    strokeThickness = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("StrokeThickness"));
                }
            }
        }
        /// <summary>
        /// Property that enable to interract with opacity
        /// </summary>
        /// /// <retruns>Pentagon opacity</retruns>
        public double Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                if (opacity != value)
                {
                    opacity = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Opacity"));
                }
            }
        }
        /// <summary>
        /// Property that enable to interract with Pentagon edge points
        /// </summary>
        /// <retruns>Pentagon stroke color</retruns>
        System.Windows.Point[] Points
        {
            get
            {
                return points;
            }
            set
            {
                if (points != value)
                {
                    points = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Points"));
                }
            }
        }

        //CONSTRUCTORS
        /// <summary>
        /// Default constructor without parameters
        /// </summary>
        public Pentagon()
        {

        }

        //METHODS
        /// <summary>
        /// Method that invokes PropertyChanged
        /// </summary>
        /// <param name="e">Changed propery argument</param>
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(e.PropertyName));
        }
        /// <summary>
        /// Method that check if point is in the shape
        /// </summary>
        /// <param name="p">Target point</param>
        /// <returns>Availability point in shape</returns>
        public bool HitTest(System.Windows.Point p)
        {
            throw new System.NotImplementedException();
        }
    }
}
