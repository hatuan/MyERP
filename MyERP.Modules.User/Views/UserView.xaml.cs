using System.Windows;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using MyERP.Infrastructure;
using MyERP.Modules.User.ViewModels;
using MyERP.ViewModels;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace MyERP.Modules.User.Views
{
    [Export("UserView", typeof(IView))]
    public partial class UserView : UserControl, IView, IPartImportsSatisfiedNotification, INavigationAware
	{
        public UserView()
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

        public void OnImportsSatisfied()
        {
            IRegionManager regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this.SetValue(Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty, regionManager);

        }
	}
}