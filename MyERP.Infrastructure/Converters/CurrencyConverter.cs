using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;
using MyERP.DataAccess;

namespace MyERP.Converters
{
    public class CurrencyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var currencies = parameter as ICollection<Currency>;
            var id = (Guid)value;

           return currencies.FirstOrDefault(c => c.Id == id); 
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var currency = value as Currency;

            if (currency == null)
            {
                return null;
            }
            else
            {
                return currency.Id;
            }
        }

    }
}
