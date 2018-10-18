namespace Task2
{
    public class StringsToLower : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return System.Linq.Enumerable.Select((System.Collections.Generic.IEnumerable<string>)value, (s) => s.ToLower());
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
