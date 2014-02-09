using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using MyERP.Infrastructure;
//using MyERP.Infrastructure.Extensions;
//using MyERP.Modules.Dashboard.ViewModels;
using MyERP.ViewModels;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;

namespace MyERP.Modules.Login.Views
{
    [ViewExport(RegionName = "ContentRegion")]
    public partial class LoginView : UserControl, INavigationAware
    {
        public LoginView()
        {
            InitializeComponent();
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            
        }
    }
}
