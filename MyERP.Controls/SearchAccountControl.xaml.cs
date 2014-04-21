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
using MyERP.Web;
using MyERP.DataAccess;
using Telerik.Windows.Controls;

namespace MyERP.Controls
{
    public partial class SearchAccountControl : UserControl, INotifyPropertyChanged
    {
        public SearchAccountControl()
        {
            InitializeComponent();

            this.OkCommand = new DelegateCommand(this.OnOkCommandExecuted);
            LayoutRoot.DataContext = this;
        }

        private IEnumerable<Account> _accounts = Enumerable.Empty<Account>();

        public IEnumerable<Account> Accounts
        {
            get { return _accounts; }
            set
            {
                if(_accounts == value)
                    return;

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

        public ICommand OkCommand { get; set; }
        private void OnOkCommandExecuted(object obj)
        {
            RadWindow window = this.ParentOfType<RadWindow>();
            window.DialogResult = true;
            window.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
