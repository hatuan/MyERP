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

        private void OnDataFormCurrentItemChanged(object sender, System.EventArgs e)
        {
            //Huy trang thai Edit khi chon (chuyen) sang account khac
            (sender as RadDataForm).CancelEdit();
        }

        private void dataForm_AddedNewItem(object sender, Telerik.Windows.Controls.Data.DataForm.AddedNewItemEventArgs e)
        {
            Account newAccount = e.NewItem as Account;
           
        }

        private void dataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
        {
            //accountsDataSource.SubmitChanges();
        }

        private void dataForm_DeletedItem(object sender, Telerik.Windows.Controls.Data.DataForm.ItemDeletedEventArgs e)
        {
            //accountsDataSource.SubmitChanges();
        }
    }
}
