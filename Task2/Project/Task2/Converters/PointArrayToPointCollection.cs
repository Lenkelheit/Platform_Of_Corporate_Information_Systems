namespace Task2
{
    public class PointArrayToPointCollection : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new System.Windows.Media.PointCollection((System.Windows.Point[])value);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Windows.Point[] points = new System.Windows.Point[Shapes.Models.Pentagon.NUM_OF_EDGE_IN_PENTAGON];
            ((System.Windows.Media.PointCollection)value).CopyTo(points, 0);
            return points;
        }
    }
}
