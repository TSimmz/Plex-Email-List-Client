using System;
using System.Windows.Data;
using System.Windows.Media;

namespace DatPlex.Resources.Converters
{
    public class IsCheckedColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool? val = (bool?)value;
            if (Equals(null, val))
                return new SolidColorBrush(Colors.Black);
            return new SolidColorBrush(Colors.Blue);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}
