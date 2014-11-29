using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Data;
using System;

namespace MyERP.Converters
{
    public class ObjectToUpperCaseStringConverter : IValueConverter
    {
        public static readonly ObjectToUpperCaseStringConverter Instance = new ObjectToUpperCaseStringConverter();

        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return String.Empty;
            }
            string stringValue = value.ToString();
            string processedValue = stringValue.ToUpper();

            return processedValue;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return String.Empty;
            }

            string stringValue = value.ToString().Trim();
            string result = stringValue.ToUpper();
            
            return result;
        }
    }
}