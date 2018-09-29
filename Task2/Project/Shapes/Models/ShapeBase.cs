namespace Shapes.Models
{
    [System.Serializable]
    public abstract class ShapeBase : System.ComponentModel.INotifyPropertyChanged
    {
        public string Name => this.GetType().Name;

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(System.ComponentModel.PropertyChangedEventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}
