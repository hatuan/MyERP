using System;
using System.Configuration;
using System.Globalization;

namespace MyERP.Web.Others
{
    public static class AppSettings
    {

        public static string MyERPBaseUrl
        {
            get
            {
                return Setting<string>("MyERPBaseUrl");
            }
        }

        public static string EHoaDonUrl
        {
            get
            {
                return Setting<string>("EHoaDonUrl");
            }
        }

        private static T Setting<T>(string name)
        {
            string value = ConfigurationManager.AppSettings[name];

            if (value == null)
            {
                throw new Exception(String.Format("Could not find setting '{0}',", name));
            }

            return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
    }
}