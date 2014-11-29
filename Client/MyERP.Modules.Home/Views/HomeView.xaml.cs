using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using MyERP.Infrastructure;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Home.Views
{
    [Export("HomeView", typeof(IView))]
    public partial class HomeView : UserControl, IView
    {
        public HomeView()
        {
            InitializeComponent();

            //Loaded += (sender, args) =>
            //{
            //    var win = this.ParentOfType<RadWindow>();
            //    win.CanClose = false;
            //};

            IRegionManager regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this.SetValue(Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty, regionManager);
        }
    }
}
