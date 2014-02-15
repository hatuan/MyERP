using System;
using System.Globalization;
using System.Windows.Data;
using MyERP.Infrastructure.Assets.Resources;


namespace MyERP.Converters
{
    public class ObjectToApplicationStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string str = value.ToString();

            return ApplicationStrings.ResourceManager.GetString(str, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
