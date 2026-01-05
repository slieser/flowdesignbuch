using System;
using System.Globalization;
using Avalonia.Data;
using Avalonia.Data.Converters;

namespace mybooks.ui
{
    public class DateTimeFormatConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo? culture) {
            if (value == null || (DateTime)value == DateTime.MinValue) {
                return string.Empty;
            }
            return ((DateTime)value).ToShortDateString();
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo? culture) {
            // Since the DataGrid is read-only, ConvertBack shouldn't be called
            // But if it is, return UnsetValue to indicate no conversion
            return BindingOperations.DoNothing;
        }
    }
}