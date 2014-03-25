using System.Windows.Controls;
using MyERP.Infrastructure;
using Telerik.Windows.Controls;


namespace MyERP.Modules.Financial.Views
{
    [ViewExport(RegionName = AccountsViewRegionNames.AccountDetails)]
    public partial class AccountDetailsUserControl : UserControl
    {
        public AccountDetailsUserControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnDataFormCurrentItemChanged(object sender, System.EventArgs e)
        {
            //Huy trang thai Edit khi chon (chuyen) sang account khac
            (sender as RadDataForm).CancelEdit();
        }

        private void dataForm_AddedNewItem(object sender, Telerik.Windows.Controls.Data.DataForm.AddedNewItemEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }

        private void dataForm_EditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }
    }
}
