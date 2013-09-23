using System;
using Windows.UI.Xaml.Data;
using Google.Apis.Blogger.v3.Data;

namespace HiddenTruth.Store.Converters
{
    public class ModelToTitleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if((Post)value != null)
            {
                return ((Post) value).Title;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
