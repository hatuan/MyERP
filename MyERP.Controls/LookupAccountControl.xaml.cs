using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyERP.DataAccess;
using Telerik.Windows.Controls;
using WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation;


namespace MyERP.Controls
{
    public partial class LookupAccountControl : UserControl
    {
        public LookupAccountControl()
        {
            InitializeComponent();

            this.SearchCommand = new DelegateCommand(this.OnSearchCommandExecuted);
            LayoutRoot.DataContext = this;
        }

        RadWindow searchWindow = new RadWindow();

        public ICommand SearchCommand { get; set; }

        private void OnSearchCommandExecuted(object obj)
        {
            StyleManager.SetTheme( searchWindow, new Windows8Theme());
            
            searchWindow.Width = 600;
            searchWindow.Height = 600;
            var searchAccountControl = new SearchAccountControl();
            searchAccountControl.SelectedAccount = SelectedAccount;
            searchAccountControl.Accounts = Accounts;
            searchWindow.Content = searchAccountControl;
            searchWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            searchWindow.HideMinimizeButton = true;
            searchWindow.HideMaximizeButton = true;
            searchWindow.Closed += (sender, args) =>
            {
                if (searchWindow.DialogResult == true)
                {
                    SelectedAccount = searchAccountControl.SelectedAccount;
                }
            };
            searchWindow.ShowDialog();
        }

        public Guid Id
        {
            get
            {
                return (Guid)GetValue(IdProperty);
            }
            set
            {
                SetValue(IdProperty, value);
            }
        }

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
            "Id", typeof(Guid), typeof(LookupAccountControl), new PropertyMetadata(Guid.Empty, OnIdChanged));

        private static void OnIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newGuid = (Guid)e.NewValue;
            var lookupControl = d as LookupAccountControl;

            if (lookupControl != null)
            {
            }
        }

        public IEnumerable<Account> Accounts
        {
            get
            {
                return (IEnumerable<Account>)GetValue(AccountsProperty);
            }
            set
            {
                SetValue(AccountsProperty, value);
            }
        }

        public static readonly DependencyProperty AccountsProperty = DependencyProperty.Register(
            "Accounts", typeof(IEnumerable), typeof(LookupAccountControl), new PropertyMetadata(Enumerable.Empty<Account>()));

        public Account SelectedAccount
        {
            get
            {
                return (Account)GetValue(SelectedAccountProperty);
            }
            set
            {
                SetValue(SelectedAccountProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedAccountProperty = DependencyProperty.Register(
           "SelectedCurrency", typeof(Account), typeof(LookupAccountControl), new PropertyMetadata(null, OnSelectedAccountChanged));

        private static void OnSelectedAccountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newAccount = (Account)e.NewValue;
            var lookupControl = d as LookupAccountControl;

            if (lookupControl != null)
            {
                lookupControl.textBox.SelectedItem = newAccount;
                lookupControl.Id = newAccount == null ? Guid.Empty : newAccount.Id;
            }
        }

        private void OnAccountsButtonClicked(object sender, RoutedEventArgs e)
        {
            var account = (sender as Button).DataContext as Account;
            this.SelectedAccount = Accounts.FirstOrDefault(c => c.Id == account.Id);
        }
    }

}
