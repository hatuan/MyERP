using System;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Modules.User.ViewModels;
using MyERP.ViewModels;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace MyERP.Modules.User.Views
{
    [ViewExport(RegionName = RegionNames.UserWindowRegion, IsActiveByDefault = false)]
    public partial class LoginView : UserControl, INavigationAware, IPartImportsSatisfiedNotification
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
            UserWindow win = this.ParentOfType<UserWindow>();
            win.HideMaximizeButton = true;
            win.HideMinimizeButton = true;
            win.ResizeMode = ResizeMode.NoResize;
            win.UserWindowRegionPlaceholder.Width = this.Width;
            win.UserWindowRegionPlaceholder.Height = this.Height;
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
            if (DataContext is ICloseable)
            {
                (DataContext as ICloseable).RequestClose += (_, __) =>
                {
                    RadWindow window = this.ParentOfType<RadWindow>();
                    window.Close();
                };
            }
        }
	}
}