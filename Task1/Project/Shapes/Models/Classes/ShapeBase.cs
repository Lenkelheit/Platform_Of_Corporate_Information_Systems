using Shapes.Models.Enums;

namespace Shapes.Models.Classes
{
    /// <summary>
    /// Represents basic algorithms for the shape objects.
    /// </summary>
    public abstract class ShapeBase : Interfaces.IShape
    {
        // PROPERTIIES
        /// <summary>
        /// Returns the perimeter of the shape.
        /// </summary>
        public abstract double GetPerimeter { get; }
        /// <summary>
        /// Returns the square of the shape.
        /// </summary>
        public abstract double GetSquare { get; }
        /// <summary>
        /// Returns the position of the shape whithin coordinate querter.
        /// </summary>
        public CoordinateQuarters GetQuarter
        {
            get
            {
                Point middlePoint = GetMiddlePoint();

                if(middlePoint.X > 0)
                {
                    return middlePoint.Y > 0 ? CoordinateQuarters.First : CoordinateQuarters.Fourth;
                }
                else return middlePoint.Y > 0 ? CoordinateQuarters.Second : CoordinateQuarters.Third;
            }
        }

        // METHODS
        /// <summary>
        /// Return the middle point of the shape.
        /// </summary>
        /// <returns>
        /// The middle point of the shape.
        /// </returns>
        protected abstract Point GetMiddlePoint();
    }
}
