using System;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using Microsoft.Practices.Prism.Regions;
using MyERP.DataAccess;
using MyERP.Infrastructure.ViewModels;
using MyERP.Repositories;

namespace MyERP.Modules.Financial.ViewModels
{
    [Export]
    public class AccountsViewModel : NavigationAwareDataViewModel
    {
        [Import]
        public AccountRepository AccountRepository { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

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

        private ICollectionView _accounts = null;
        public ICollectionView Accounts
        {
            get
            {
                //if (this.accounts == null)
                //{
                //this.ContactRepository.GetContacts(items =>
                //{
                //    this.accounts = new QueryableCollectionView(new ObservableCollection<Contact>(items));
                //    this.RaisePropertyChanged("accounts");
                //});
                //}
                
                return this._accounts;
            }
            set
            {
                this._accounts = value;
                //select contact if the user has tried to navigate to one in the UI
                //if (value != null && this.contactToSelect != null)
                //{
                //    this.SelectedContact = contactToSelect;
                //}
                this.RaisePropertyChanged("Accounts");
            }
        }

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
        }
        #endregion
    }
}
