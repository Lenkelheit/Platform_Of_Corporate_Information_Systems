using System.ComponentModel;

namespace Shapes.Models
{
    [System.Serializable]
    public class Pentagon : ShapeBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
