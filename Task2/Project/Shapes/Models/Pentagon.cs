namespace Shapes.Models
{
    [System.Serializable]
    public class Pentagon : ShapeBase
    {
        public System.Windows.Media.Color Color { get; set; }
        public System.Windows.Media.Color StrokeColor { get; set; }
        public double StrokeThickness { get; set; }
        public double Opacity { get; set; }
        public System.Windows.Point[] Points { get; set; }

        public Pentagon()
        {
            throw new System.NotImplementedException();
        }
        public bool HitTest(System.Windows.Point p)
        {
            throw new System.NotImplementedException();
        }
    }
}
