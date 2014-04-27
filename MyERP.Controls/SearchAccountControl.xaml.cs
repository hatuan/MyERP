using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MyERP.Infrastructure.Annotations;
using MyERP.Repositories;
using MyERP.Web;
using MyERP.DataAccess;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace MyERP.Controls
{
    public partial class SearchAccountControl : UserControl, INotifyPropertyChanged
    {
        public SearchAccountControl()
        {
            InitializeComponent();

            this.OkCommand = new DelegateCommand(this.OnOkCommandExecuted);
            this.SearchCommand = new DelegateCommand(this.OnSearchCommandExecuted);
            LayoutRoot.DataContext = this;
        }

        private readonly AccountRepository _accountRepository = new AccountRepository();

        private IEnumerable<Account> _accounts;

        public IEnumerable<Account> Accounts
        {
            get { return _accounts; }
            set
            {
                _accounts = value;
                OnPropertyChanged("Accounts");
            }
        }

        private Account _selectedAccount = null;
        public Account SelectedAccount
        {
            get { return _selectedAccount; }
            set
            {
                _selectedAccount = value;
                OnPropertyChanged("SelectedAccount");
            }
        }

        public bool IsBusy { get; set; }

        public ICommand OkCommand { get; set; }
        private void OnOkCommandExecuted(object obj)
        {
            RadWindow window = this.ParentOfType<RadWindow>();
            window.DialogResult = true;
            window.Close();
        }

        public ICommand SearchCommand { get; set; }
        private void OnSearchCommandExecuted(object obj)
        {

            IsBusy = true;
            _accountRepository.GetAccountsByLookupValue(searchValue.Text, accounts =>
            {
                Accounts = accounts;
                IsBusy = false;
            });
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
