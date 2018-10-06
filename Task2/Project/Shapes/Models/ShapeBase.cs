namespace Shapes.Models
{
    /// <summary>
    /// Represents basic algorithms for the shape objects.
    /// </summary>
    [System.Serializable]
    public abstract class ShapeBase : System.ComponentModel.INotifyPropertyChanged
    {
        // PROPERTIES
        /// <summary>
        /// The name of shape.
        /// </summary>
        public string Name => this.GetType().Name;
        // EVENTS
        /// <summary>
        /// Notifies that some property is changed.
        /// </summary>
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        // METHODS
        /// <summary>
        /// Notifies event <see cref="PropertyChanged"/> that some property is changed.
        /// </summary>
        /// <param name="e">Data for event <see cref="PropertyChanged"/>.</param>
        protected virtual void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        /// <summary>
        /// Checks if current point is in shape.
        /// </summary>
        /// <param name="point">Current point.</param>
        /// <returns>
        /// True if current point is in shape, else - false.
        /// </returns>
        public abstract bool HitTest(System.Windows.Point point);
    }
}
