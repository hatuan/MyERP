using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using MyERP.Infrastructure;
using MyERP.Infrastructure.Extensions;
using MyERP.Modules.Home.ViewModels;
using MyERP.ViewModels;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;

namespace MyERP.Modules.Home.Views
{
    [ViewExport(RegionName = "ContentRegion")]
    public partial class DashboardView : UserControl, INavigationAware
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public DashboardViewModel ViewModel
        {
            private get
            {
                return this.DataContext as DashboardViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.RegionManager.RequestNavigate(RegionNames.MainMenuRegion, "DashboardMainMenuView");
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
