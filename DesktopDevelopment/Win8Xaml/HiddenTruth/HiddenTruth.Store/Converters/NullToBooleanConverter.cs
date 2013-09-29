using System;
using System.Reflection;
using Windows.UI.Xaml.Data;
using HiddenTruth.Library.Model;

namespace HiddenTruth.Store.Converters
{
    public class NullToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
            {
                return false;
            }

            if (value is ItemModel)
            {
                return !string.IsNullOrEmpty((value as ItemModel).Id);
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return value;
        }
    }
}
