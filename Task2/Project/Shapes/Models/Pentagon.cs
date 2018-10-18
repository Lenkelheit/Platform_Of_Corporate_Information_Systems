using System.ComponentModel;

namespace Shapes.Models
{
    /// <summary>
    /// Represents class that models Pentagon
    /// </summary>
    [System.Serializable]
    public class Pentagon : ShapeBase
    {
        // CONSTANTS
        /// <summary>
        /// Shows how many edges in shape
        /// </summary>
        public const int NUM_OF_EDGE_IN_PENTAGON = 5;

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
        /// <returns>Pentagon color</returns>
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
        /// <returns>Pentagon stroke color</returns>
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
        /// <returns>Pentagon stroke thickness</returns>
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
        /// <returns>Pentagon opacity</returns>
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
        /// <returns>Pentagon edges</returns>
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
            color = System.Windows.Media.Color.FromRgb(255, 255, 255);
            strokeColor = System.Windows.Media.Color.FromRgb(72, 72, 72);
            strokeThickness = 5;
            opacity = 1;
            points = new System.Windows.Point[5];
        }
        /// <summary>
        /// Constructor with 1 parameter
        /// </summary>
        /// <param name="pentagonVertex">Collection of new pentagon vertex</param>
        /// <exception cref="System.ArgumentException">Vertex doesn't exist!</exception>
        public Pentagon(Vertex[] pentagonVertex) : this()
        {
            if (pentagonVertex != null)
            {
                for (int i = 0; i < NUM_OF_EDGE_IN_PENTAGON; i++)
                {
                    if (pentagonVertex[i] != null)
                    {
                        points[i] = pentagonVertex[i].Location;
                    }
                    else
                    {
                        throw new System.ArgumentException("Vertex doesn't exist!");
                    }
                }
            }
            else
            {
                throw new System.ArgumentException("Vertexes doesn't exist!");
            }
        }

        // METHODS
        /// <summary>
        /// Method that check if point is in the shape
        /// </summary>
        /// <param name="p">Target point</param>
        /// <returns>Availability point in shape</returns>
        public override bool HitTest(System.Windows.Point p)
        {
            bool hitted = false;

            // go through each of the vertices, plus
            // the next vertex in the list
            for (int i = 0; i < points.Length; ++i)
            {
                // get next vertex in list
                // if we've hit the end, wrap around to 0

                // get the Point at our current position
                // this makes our if statement a little cleaner
                System.Windows.Point pc = points[i];                           // c for "current"
                System.Windows.Point pn = points[(i+1) % points.Length];       // n for "next"

                // compare position, flip 'hitted' variable
                // back and forth
                if (((pc.Y >= p.Y && pn.Y < p.Y) || (pc.Y < p.Y && pn.Y >= p.Y)) &&
                     (p.X < (pn.X - pc.X) * (p.Y - pc.Y) / (pn.Y - pc.Y) + pc.X))
                {
                    hitted = !hitted;
                }
            }
            return hitted;
        }
    }
}
