using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Modules.Financial.ViewModels;
using MyERP.ViewModels;
using Telerik.Windows.Controls;


namespace MyERP.Modules.Financial.Views
{
    [ViewExport(RegionName = AccountsViewRegionNames.AccountDetails)]
    public partial class AccountDetailsUserControl : UserControl
    {
        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

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

        public AccountDetailsUserControl()
        {
            InitializeComponent();
        }
    }
}
