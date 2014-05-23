using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Windows;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;
using MyERP.ViewModels;
using Telerik.Windows.Data;

namespace MyERP.Modules.Financial.ViewModels
{
    [Export]
    public class AccountsViewModel : NavigationAwareDataViewModel, ICloseable
    {
        public AccountsViewModel()
        {
            
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

                ((DelegateCommand)DeleteCommand).RaiseCanExecuteChanged();
            }
        }

        private ObservableItemCollection<Account> _accounts;
        public ObservableItemCollection<Account> Accounts
        {
            get { return this._accounts; }
            set { _accounts = value; }
        }
        
        public bool IsBusy
        {
            get { return false; }
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
                    ((DelegateCommand)AddNewCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)CloseWindowCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)SubmitChangesCommand).RaiseCanExecuteChanged();
                    ((DelegateCommand)RejectChangesCommand).RaiseCanExecuteChanged();
                    break;
            }
        }


        private void OnAddNewCommandExecuted()
        {

        }

        private bool AddNewCommandCanExecute()
        {
            return true;
        }


        private bool SubmitChangesCommandCanExecute()
        {
            return true;
        }

        private void OnRejectChangesExcuted()
        {
        }

        private void OnSubmitChangesExcuted()
        {
        }

        private bool RefreshCommandCanExecute()
        {
            return true;
        }

        private void OnRefreshExcuted()
        {
        }

        private bool DeleteCommandCanExecute()
        {
            if(SelectedAccount == null)
                return false;

            return true;
        }

        private void OnDeleteExcuted()
        {
            if(SelectedAccount != null)
                this.Accounts.Remove(SelectedAccount);
        }

        private bool CloseWindowCanExecute()
        {
            if (this.RequestClose == null)
                return false;
            
            //Neu co thay doi thi khong cho dong cua so, bat buoc phai luu hay undo
            //if(this._accounts.HasChanges)
            //    return false;

            return true;
        }

        private void OnCloseWindowExcuted()
        {
            if (this.RequestClose != null)
            {
                this.RequestClose(null, EventArgs.Empty);
            }
        }

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();

            this.AddNewCommand = new DelegateCommand(OnAddNewCommandExecuted, AddNewCommandCanExecute);
            this.SubmitChangesCommand = new DelegateCommand(OnSubmitChangesExcuted, SubmitChangesCommandCanExecute);
            this.RejectChangesCommand = new DelegateCommand(OnRejectChangesExcuted, SubmitChangesCommandCanExecute);
            this.RefreshCommand = new DelegateCommand(OnRefreshExcuted, RefreshCommandCanExecute);
            this.DeleteCommand = new DelegateCommand(OnDeleteExcuted, DeleteCommandCanExecute);
            this.CloseWindowCommand = new DelegateCommand(OnCloseWindowExcuted, CloseWindowCanExecute);
        }
       
        #endregion

        public event EventHandler<EventArgs> RequestClose;
    }
}
