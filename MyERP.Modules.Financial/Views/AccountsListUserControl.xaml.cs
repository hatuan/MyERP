using System.Windows.Controls;
using MyERP.Infrastructure;

namespace MyERP.Modules.Financial.Views
{
     [ViewExport(RegionName = AccountsViewRegionNames.AccountsOverview)]
    public partial class AccountsListUserControl : UserControl
    {
        
        public AccountsListUserControl()
        {
            InitializeComponent();
        }
    }
}
