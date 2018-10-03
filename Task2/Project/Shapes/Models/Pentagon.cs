using System.ComponentModel;

namespace Shapes.Models
{
    /// <summary>
    /// Represents class that models Pentagon
    /// </summary>
    [System.Serializable]
    public class Pentagon : ShapeBase
    {
        // FIELDS
        System.Windows.Media.Color color;
        System.Windows.Media.Color strokeColor;
        double strokeThickness;
        double opacity;
        System.Windows.Point[] points;

        // PROPERTIES
        /// <summary>
        /// Property that enable to interract with color
        /// </summary>
        /// <retruns>Pentagon color</retruns>
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
        ///<retruns>Pentagon stroke color</retruns>
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
        ///<retruns>Pentagon stroke thickness</retruns>
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
        ///<retruns>Pentagon opacity</retruns>
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
        /// <retruns>Pentagon edges</retruns>
        /// <exception cref="System.ArgumentException">Pentagon should have 5 edges</exception>
        public System.Windows.Point[] Points
        {
            get
            {
                return points;
            }
            set
            {
                if (value.Length == 5)
                {
                    if (points != value)
                    {
                        points = value;
                        OnPropertyChanged(new PropertyChangedEventArgs("Points"));
                    } 
                }
                else
                {
                    throw new System.ArgumentException("Pentagon should have 5 edges");
                }
            }
        }

        //CONSTRUCTORS
        /// <summary>
        /// Default constructor without parameters
        /// </summary>
        public Pentagon()
        {
            color = new System.Windows.Media.Color();
            strokeColor = new System.Windows.Media.Color();
            strokeThickness = 0;
            opacity = 0;
            points = new System.Windows.Point[5];
        }

        //METHODS
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
