using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Modules.Financial.ViewModels;
using MyERP.ViewModels;

namespace MyERP.Modules.Financial.Views
{
     [ViewExport(RegionName = AccountsViewRegionNames.AccountsOverview)]
    public partial class AccountsListUserControl : UserControl
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

        public AccountsListUserControl()
        {
            InitializeComponent();
        }

        private void gridView_AddingNewDataItem(object sender, Telerik.Windows.Controls.GridView.GridViewAddingNewEventArgs e)
        {
            Account newAccount = new Account();
            Session currentSession =
                ViewModel.AccountRepository.Context.Sessions.First(c => c.Id == ApplicationViewModel.SessionId);
            newAccount.RecCreatedById = newAccount.RecModifiedById = currentSession.UserId;

            e.NewObject = newAccount;
            
        }
    }
}
