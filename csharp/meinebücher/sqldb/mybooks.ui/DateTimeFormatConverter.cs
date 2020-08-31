using System;
using System.Globalization;
using System.Windows.Data;

namespace mybooks.ui
{
    public class DateTimeFormatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if ((DateTime)value == DateTime.MinValue) {
                return string.Empty;
            }
            return ((DateTime)value).ToShortDateString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}