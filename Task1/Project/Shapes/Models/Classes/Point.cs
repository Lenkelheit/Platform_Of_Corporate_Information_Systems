using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Models simple point on two-dimensional space
    /// </summary>
    struct Point
    {
        /// <summary>
        /// Point position on abscis
        /// </summary>
        public double X;
        /// <summary>
        /// Point position on ordinate
        /// </summary>
        public double Y;
        /// <summary>
        /// Basic constructor that takes 2 parameters
        /// </summary>
        /// <param name="x">Abscis position</param>
        /// <param name="y">Ordinate position</param>
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }
        /// <summary>
        /// Method that returns distance between two points
        /// </summary>
        /// <param name="A">First Point</param>
        /// <param name="B">Second point</param>
        /// <returns>Distance betweeen points</returns>
        public static double Distance(Point A, Point B)
        {
            return (Sqrt(Pow(A.X - B.X, 2) + Pow(A.Y - B.Y, 2)));
        }
    }
}

