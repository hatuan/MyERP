using System;
using System.Windows.Data;

namespace MyERP.Converters
{
    public class IdNullToGuidConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                return (Guid)value;
            }
            else
            {
                return Guid.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((Guid) value != Guid.Empty)
                return (Guid) value;
            else
                return null;

        }
    }
}
