namespace Shapes.Models.Interfaces
{
    /// <summary>
    /// Defines the basic rules for creating type Shape objects.
    /// </summary>
    public interface IShape
    {
        /// <summary>
        /// Returns the square of the shape.
        /// </summary>
        double GetSquare { get; }
        /// <summary>
        /// Returns the perimeter of the shape.
        /// </summary>
        double GetPerimeter { get; }
        /// <summary>
        /// Returns the position of the shape whithin coordinate querter.
        /// </summary>
        Enums.CoordinateQuarters GetQuarter { get; }
    }
}
