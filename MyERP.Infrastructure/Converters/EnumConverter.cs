using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace MyERP.Converters
{
     /// <summary>
     /// http://www.xamlplayground.org/post/2010/09/03/A-generic-enum-converter-to-map-values.aspx
     /// 
     /// public enum MessageType
     /// {
     ///     Normal,
     ///     Urgent,
     ///     Critical
     /// }
     /// 
     /// <UserControl xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation" 
     ///            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" 
     ///            xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
     ///            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
     ///            xmlns:cv="clr-namespace:SilverlightPlayground.Converters;assembly=SilverlightPlayground"
     ///            mc:Ignorable="d" x:Class="SilverlightPlayground.MyApplication.Shell" d:DesignWidth="456">
     ///   <UserControl.Resources>
     ///       <cv:EnumConverter x:Key="mapTypeToBrush">
     ///          <cv:EnumConverter.Items>
     ///              <SolidColorBrush Color="#00000000" />
     ///              <SolidColorBrush Color="#FFFF9900" />
     ///              <SolidColorBrush Color="#FFFF0000" />
     ///          </cv:EnumConverter.Items>
     ///       </cv:EnumConverter>
     ///   </UserControl.Resources>
     ///   <Grid x:Name="LayoutRoot">
     ///       <Rectangle Fill="{Binding ReveivedMessageType, Converter={StaticResource mapTypeToBrush}}" Width="100" Height="100" />
     ///   </Grid>
     /// </UserControl>
     /// 
     /// <cv:EnumConverter x:Key="bool2Visibility">
     ///     <cv:EnumConverter.Items>
     ///         <Visibility>Collapsed</Visibility>
     ///         <Visibility>Visible</Visibility>
     ///      </cv:EnumConverter.Items>
     /// </cv:EnumConverter>
     /// </summary>
    public class EnumConverter : IValueConverter
    {
        private List<object> items;
     
        public List<object> Items 
        { 
            get
            {
                if (items == null)
                   items = new List<object>();
    
               return items;
           }
       }
    
       public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
       {
           if (value == null)
               throw new ArgumentNullException("value");
           else if (value is bool)
               return this.Items.ElementAtOrDefault(System.Convert.ToByte(value));
           else if (value is byte)
               return this.Items.ElementAtOrDefault(System.Convert.ToByte(value));
           else if (value is short)
               return this.Items.ElementAtOrDefault(System.Convert.ToInt16(value));
           else if (value is int)
               return this.Items.ElementAtOrDefault(System.Convert.ToInt32(value));
           else if (value is long)
               return this.Items.ElementAtOrDefault(System.Convert.ToInt32(value));
           else if (value is Enum)
               return this.Items.ElementAtOrDefault(System.Convert.ToInt32(value));
    
           throw new InvalidOperationException(string.Format("Invalid input value of type '{0}'", value.GetType()));
       }
    
       public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
       {
           if (value == null)
               throw new ArgumentNullException("value");
    
           return this.Items.Where(b => b.Equals(value)).Select((a, b) => b);
       }
   }
}
