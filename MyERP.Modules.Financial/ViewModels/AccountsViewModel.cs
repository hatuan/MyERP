using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using MyERP.DataAccess;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.ViewModels;
using MyERP.Web;
using Telerik.Windows.Data;

namespace MyERP.Modules.Financial.ViewModels
{
    [Export]
    public class AccountsViewModel : NavigationAwareDataViewModel
    {
        public AccountsViewModel()
        {
            MyERPDomainContext context = new MyERPDomainContext();
            EntityQuery<Account> getAccountsQuery = context.GetAccountsQuery().OrderBy(c => c.Code);
            this._accounts = new QueryableDomainServiceCollectionView<Account>(context, getAccountsQuery);
            this._accounts.AutoLoad = true;
            this._accounts.LoadedData += _accounts_LoadedData;
            this._accounts.PropertyChanged += _accounts_PropertyChanged;
            this._accounts.SubmittedChanges += _accounts_SubmittedChanges;

            this._codeSortDescriptor = new SortDescriptor() {Member = "Code"};
            
            this.AddNewCommand = new DelegateCommand(this.OnAddNewCommandExecuted);
            this.SubmitChangesCommand = new DelegateCommand(OnSubmitChangesExcuted, SubmitChangesCommandCanExecute);
            this.RejectChangesCommand = new DelegateCommand(OnRejectChangesExcuted, SubmitChangesCommandCanExecute);
            this.RefreshCommand = new DelegateCommand(OnRefreshExcuted, RefreshCommandCanExecute);
        }

        [Import]
        public AccountRepository AccountRepository { get; set; }

        public ICommand AddNewCommand { get; set; }
        public ICommand SubmitChangesCommand { get; set; }
        public ICommand RejectChangesCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ChangeCodeCommand { get; set; }
        public ICommand CloseWindowCommand { get; set; }
        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        private AccountsViewState _state;
        public AccountsViewState State
        {
            get
            {
                return this._state;
            }
            set
            {
                if (this._state == value)
                {
                    return;
                }
                this._state = value;
                this.RaisePropertyChanged("State");
            }
        }

        private Account _selectedAccount;
        public Account SelectedAccount
        {
            get
            {
                return this._selectedAccount;
            }
            set
            {
                if (this._selectedAccount == value)
                {
                    return;
                }
                this._selectedAccount = value;
                this.RaisePropertyChanged("SelectedAccount");
            }
        }

        private readonly QueryableDomainServiceCollectionView<Account> _accounts;
        public ICollectionView Accounts
        {
            get
            {
              
                return this._accounts;
            }
        }

        public bool IsBusy
        {
            get { return this._accounts.IsBusy; }
        }

        private readonly SortDescriptor _codeSortDescriptor;

        void _accounts_LoadedData(object sender, Telerik.Windows.Controls.DomainServices.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                MessageBox.Show(e.Error.ToString(), "Load Error", MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }
        

        void _accounts_SubmittedChanges(object sender, Telerik.Windows.Controls.DomainServices.DomainServiceSubmittedChangesEventArgs e)
        {
            if (e.HasError)
            {
                MessageBox.Show(e.Error.ToString(), "Submit Error", MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
        }

        void _accounts_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "CanLoad":
                    ((DelegateCommand)RefreshCommand).RaiseCanExecuteChanged();
                    break;
                case "IsBusy":
                    RaisePropertyChanged(e.PropertyName);
                    break;
                case "HasChanges":
                    ((DelegateCommand)SubmitChangesCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)RejectChangesCommand).RaiseCanExecuteChanged();
                    break;
            }
        }

        private void OnAddNewCommandExecuted()
        {
            Account newAccount = new Account();
            Session currentSession =
                AccountRepository.Context.Sessions.First(c => c.Id == ApplicationViewModel.SessionId);
            newAccount.RecCreatedById = newAccount.RecModifiedById = currentSession.UserId;

            _accounts.AddNew(newAccount);
        }
        
        private bool SubmitChangesCommandCanExecute()
        {
            return this._accounts.HasChanges;
        }

        private void OnRejectChangesExcuted()
        {
            this._accounts.RejectChanges();
        }

        private void OnSubmitChangesExcuted()
        {
            this._accounts.SubmitChanges();
        }

        private bool RefreshCommandCanExecute()
        {
            return this._accounts.CanLoad;
        }

        private void OnRefreshExcuted()
        {
            this._accounts.Load();
        }

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
        }
        #endregion
    }
}
