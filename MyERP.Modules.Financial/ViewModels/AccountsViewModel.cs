using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Infrastructure.Extensions;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;
using MyERP.ViewModels;

namespace MyERP.Modules.Financial.ViewModels
{
    [Export]
    public class AccountsViewModel : NavigationAwareDataViewModel, ICloseable
    {
        public AccountsViewModel()
        {
            this.Accounts = new ObservableCollectionEx<Account>(true);

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

        private ObservableCollectionEx<Account> _accounts;
        public ObservableCollectionEx<Account> Accounts
        {
            get { return this._accounts; }
            set
            {
                _accounts = value;
                _accounts.CollectionChanged += AccountCollectionChanged;
                this.RaisePropertyChanged("Accounts");
            }
        }

        private void AccountCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (Account item in e.OldItems)
                {
                    //Removed items
                    item.PropertyChanged -= AccountPropertyChanged;
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Account item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += AccountPropertyChanged;
                }
            }    
        }

        private void AccountPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Account entity = sender as Account;
            AccountRepository.Update(entity);
        }
        
        public bool IsBusy { get; set; }
        
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
            var newId = Guid.NewGuid();
            var newEntity = new Account()
            {
                OrganizationId = (SessionManager.Session["Organization"] as Organization).Id,
                ClientId = (Guid)SessionManager.Session["ClientId"],
                Id = newId,
                Code = "",
                Name = "",
                RecModifiedById = (SessionManager.Session["User"] as User).Id,
                RecCreatedById = (SessionManager.Session["User"] as User).Id,
                RecModified = DateTime.Now,
                RecCreated = DateTime.Now,
                Status = 1,
                Version = 1
            };
            this.Accounts.Add(newEntity);
            this.AccountRepository.AddNew("Accounts", newEntity);
            this.SelectedAccount = newEntity;
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
            AccountRepository.SaveChanges();
        }

        private bool RefreshCommandCanExecute()
        {
            return true;
        }

        private void OnRefreshExcuted()
        {
            Accounts.Clear();
            AccountRepository.GetAccounts(results => results.ForEach((item) => this.Accounts.Add(item)));
        }

        private bool DeleteCommandCanExecute()
        {
            if(SelectedAccount == null)
                return false;

            return true;
        }

        private void OnDeleteExcuted()
        {
            if (SelectedAccount != null)
            {
                this.AccountRepository.Delete(SelectedAccount);
                this.Accounts.Remove(SelectedAccount);
            }
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

        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);
            
            Accounts.Clear();
            AccountRepository.GetAccounts(results => results.ForEach((item) => this.Accounts.Add(item)));
            this.RaisePropertyChanged("Accounts");
        }

        #endregion

        public event EventHandler<EventArgs> RequestClose;
    }
}
