using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Media;

namespace TelerikUniversity.Wpf.Converters
{
    public class ColorToSolidColorBrush : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            SolidColorBrush result = new SolidColorBrush(Colors.Transparent);

            if (value != null)
                result = new SolidColorBrush((Color)value);

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color result = Colors.Transparent;

            if (value != null)
                result = ((SolidColorBrush)value).Color;

            return result;
        }

        #endregion
    }
}
