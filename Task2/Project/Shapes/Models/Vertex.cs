using System.ComponentModel;

namespace Shapes.Models
{
    [System.Serializable]
    public class Vertex : ShapeBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
