using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Setup
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    [Export("SetupWindow", typeof(RadWindow))]
    public partial class SetupWindow : IPartImportsSatisfiedNotification
    {
        [Import]
        public IRegionManager RegionManager { get; set; }

        public SetupWindow()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            //IRegionManager regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this.SetValue(Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty, RegionManager);
        }
    }
}
