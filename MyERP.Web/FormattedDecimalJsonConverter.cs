using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace MyERP.Web
{
    /// <summary>
    /// https://stackoverflow.com/questions/4721143/how-to-localize-when-json-serializing
    /// List<decimal> values = new List<decimal> { 1.1M, 3.14M, -0.9M, 1000.42M };
    /// var converter = new FormattedDecimalConverter(CultureInfo.GetCultureInfo("fr-FR"));
    /// string json = JsonConvert.SerializeObject(values, converter);
    /// Console.WriteLine(json);
    /// ["1,1","3,14","-0,9","1000,42"]
    /// </summary>
    public class FormattedDecimalJsonConverter : JsonConverter
    {
        private CultureInfo culture;

        public FormattedDecimalJsonConverter(CultureInfo culture)
        {
            this.culture = culture;
        }

        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(decimal) ||
                    objectType == typeof(double) ||
                    objectType == typeof(float));
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(Convert.ToString(value, culture));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}