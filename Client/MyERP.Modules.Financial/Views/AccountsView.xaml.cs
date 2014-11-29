using System;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Modules.Financial.ViewModels;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Financial.Views
{
    [ViewExport(RegionName = RegionNames.FinancialWindowRegion, IsActiveByDefault = false)]
    public partial class AccountsView : UserControl, IPartImportsSatisfiedNotification, INavigationAware
    {
        public AccountsView()
        {
            InitializeComponent();
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public AccountsViewModel ViewModel
        {
            private get
            {
                return this.DataContext as AccountsViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        #region INavigationAware 
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var win = this.ParentOfType<FinancialWindow>();
            win.CanClose = false;
            win.Width = 1210;
            win.Height = 700;

            if (DataContext is ICloseable)
            {
                (DataContext as ICloseable).RequestClose += (_, __) =>
                {
                    RadWindow window = this.ParentOfType<FinancialWindow>();
                    window.Close();
                };
            }

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        #endregion

        #region IPartImportsSatisfiedNotification
        public void OnImportsSatisfied()
        {
            RoutedEventHandler loadedHandler = null;
            loadedHandler = (s, e) =>
            {
                this.Loaded -= loadedHandler;
                this.ViewModel.State = AccountsViewState.List;
            };

            this.Loaded += loadedHandler;
        }
        #endregion
    }
}
