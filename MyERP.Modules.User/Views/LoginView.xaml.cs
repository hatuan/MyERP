using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Modules.User.ViewModels;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using MyERP.ViewModels;
using Telerik.Windows.Controls;

namespace MyERP.Modules.User.Views
{
    [ViewExport(RegionName = "ContentRegion")]
    public partial class LoginView : UserControl, INavigationAware
	{
		public LoginView()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public LoginViewModel ViewModel
        {
            private get
            {
                return this.DataContext as LoginViewModel;
            }

            set
            {
                this.DataContext = value;
            }
        }

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