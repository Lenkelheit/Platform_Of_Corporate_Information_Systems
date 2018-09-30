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
        public string Name { get; set; }
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
    }
}
