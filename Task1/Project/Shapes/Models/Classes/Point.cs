using static System.Math;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Models simple point on two-dimensional space
    /// </summary>
    public struct Point
    {
        // FIELDS
        double x;
        double y;
        // CONSTRUCTORS
        /// <summary>
        /// Basic constructor that takes 2 parameters
        /// </summary>
        /// <param name="xCoord">Abscis position</param>
        /// <param name="yCoord">Ordinate position</param> 
        public Point(double xCoord, double yCoord)
        {
            x = xCoord;
            y = yCoord;
        }
        // PROPERTIES
        /// <summary>
        /// Property that return absciss coordinate
        /// </summary>
        public double X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        /// <summary>
        /// Property that return ordinate coordinate
        /// </summary>
        public double Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        // METHODS
        /// <summary>
        /// Method that returns distance between two points
        /// </summary>
        /// <param name="A">First Point</param>
        /// <param name="B">Second point</param>
        /// <returns>Distance betweeen points</returns>
        public static double Distance(Point A, Point B)
        {
            return Sqrt(Pow(A.X - B.X, 2) + Pow(A.Y - B.Y, 2));
        }
    }
}

