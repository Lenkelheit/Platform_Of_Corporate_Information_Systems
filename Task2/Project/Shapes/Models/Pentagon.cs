namespace Shapes.Models
{
    [System.Serializable]
    public class Pentagon : ShapeBase
    {
        System.Windows.Media.Color color;
        System.Windows.Media.Color strokeColor;
        double strokeThickness;
        double opacity;
        System.Windows.Point[] points;


        public System.Windows.Media.Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public System.Windows.Media.Color StrokeColor
        {
            get
            {
                return strokeColor;
            }
            set
            {
                strokeColor = value;
            }
        }
        public double StrokeThickness
        {
            get
            {
                return strokeThickness;
            }
            set
            {
                strokeThickness = value;
            }
        }
        public double Opacity
        {
            get
            {
                return opacity;
            }
            set
            {
                opacity = value;
            }
        }
        public System.Windows.Point[] Points
        {
            get
            {
                return points;
            }
            set
            {
                points = value;
            }
        }

        public Pentagon()
        {

        }
        public bool HitTest(System.Windows.Point p)
        {
            
        }
    }
}
