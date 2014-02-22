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
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.ViewModels;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Home.Views
{
    [ViewExport(RegionName = RegionNames.HomeWindowRegion, IsActiveByDefault = false)]
    public partial class ModulesView : INavigationAware
    {
        public ModulesView()
        {
            InitializeComponent();
            Loaded += (sender, args) =>
            {
                HomeWindow win = this.ParentOfType<HomeWindow>();
                win.CanClose = false;
                win.HomeWindowRegionPlaceholder.Width = this.Width;
                win.HomeWindowRegionPlaceholder.Height = this.Height;
            };
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }


        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
