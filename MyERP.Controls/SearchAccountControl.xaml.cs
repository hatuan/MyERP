using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MyERP.DataAccess;
using MyERP.Repository.MyERPService;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using ViewModelBase = MyERP.Infrastructure.ViewModels.ViewModelBase;

namespace MyERP.Controls
{
    public partial class SearchAccountControl : UserControl, INotifyPropertyChanged
    {
        public SearchAccountControl()
        {
            InitializeComponent();
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                _accountRepository = new AccountRepository();
                this.OkCommand = new DelegateCommand(this.OnOkCommandExecuted);
                this.SearchCommand = new DelegateCommand(this.OnSearchCommandExecuted);
                LayoutRoot.DataContext = this;
            }
        }

        private readonly AccountRepository _accountRepository;

        private ObservableCollection<Account> _accounts;

        public ObservableCollection<Account> Accounts
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
            _accountRepository.GetAccountsByLookupValue(searchValue.Text, results =>
            {
                Accounts = new ObservableCollection<Account>(results);
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
