using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Modules.Financial.ViewModels;

namespace MyERP.Modules.Financial.Views
{
    [ViewExport(RegionName = RegionNames.FinancialWindowRegion, IsActiveByDefault = false)]
    public partial class AccountsView : UserControl, INavigationAware
    {
        public AccountsView()
        {
            InitializeComponent();
        }

        [Import]
        public AccountViewModel ViewModel
        {
            private get
            {
                return this.DataContext as AccountViewModel;
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
