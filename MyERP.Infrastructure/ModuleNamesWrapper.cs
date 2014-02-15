using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MyERP.Infrastructure
{
    /// <summary>
    /// Exposes ModuleNames' constants as properties - needed in XAML files, as we cannot use static/constants there.
    /// </summary>
    public class ModuleNamesWrapper
    {
        public static string HomeModule
        {
            get
            {
                return ModuleNames.HomeModule;
            }
        }

        public static string UserModule
        {
            get
            {
                return ModuleNames.UserModule;
            }
        }

        public static string MyERPModule
        {
            get
            {
                return ModuleNames.MyERPModule;
            }
        }

        public static string SettingModule
        {
            get
            {
                return ModuleNames.SettingModule;
            }
        }
    }
}
