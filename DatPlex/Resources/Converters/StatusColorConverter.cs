using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace DatPlex.Resources.Converters
{
    public class FileExistsColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string text = (string)value;
            if (string.IsNullOrWhiteSpace(Path.GetFileName(text)))
                return new SolidColorBrush(Colors.White);
            if (File.Exists(text))
                return new SolidColorBrush(Colors.PaleGreen);
            return new SolidColorBrush(Colors.Coral);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

    }
}
