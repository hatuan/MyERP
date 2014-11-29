using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using MyERP.DataAccess;
using MyERP.Infrastructure.Annotations;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using ViewModelBase = MyERP.Infrastructure.ViewModels.ViewModelBase;
using WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation;


namespace MyERP.Controls
{
    public partial class LookupAccountControl : UserControl, INotifyPropertyChanged
    {
        public LookupAccountControl()
        {
            InitializeComponent();

            if (!ViewModelBase.IsInDesignModeStatic)
            {
                _accountRepository = new AccountRepository();
                this.SearchCommand = new DelegateCommand(this.OnSearchCommandExecuted);
                LayoutRoot.DataContext = this;
                
                this.loadTimer = new DispatcherTimer();
                // You can control the load delay between typing in the textbox and going to the server.
                this.loadTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
                this.loadTimer.Tick += this.OnLoadTimerTick;
            }
        }

        private readonly DispatcherTimer loadTimer;

        private void OnLoadTimerTick(object sender, EventArgs e)
        {
            if (this.loadTimer.IsEnabled)
            {
                this.loadTimer.Stop();
            }
            IsBusy = true;
            _accountRepository.GetAccountsByLookupValue(textBox.SearchText, results =>
            {
                this.Accounts = new ObservableCollection<Account>(results);;
                IsBusy = false;
            });
        }

        private readonly AccountRepository _accountRepository;

        readonly RadWindow _searchWindow = new RadWindow();

        private void TextBox_OnSearchTextChanged(object sender, EventArgs e)
        {
            if (this.loadTimer.IsEnabled)
            {
                this.loadTimer.Stop();
            }

            this.loadTimer.Start();
        }

        public bool IsBusy { get; set; }

        public ICommand SearchCommand { get; set; }

        private void OnSearchCommandExecuted(object obj)
        {
            StyleManager.SetTheme( _searchWindow, new Windows8Theme());
            
            _searchWindow.Width = 600;
            _searchWindow.Height = 600;
            var searchAccountControl = new SearchAccountControl
            {
                searchValue = {Text = textBox.SearchText},
                SelectedAccount = SelectedAccount,
                Accounts = Accounts
            };
            _searchWindow.Content = searchAccountControl;
            _searchWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _searchWindow.HideMinimizeButton = true;
            _searchWindow.HideMaximizeButton = true;
            _searchWindow.Closed += (sender, args) =>
            {
                if (_searchWindow.DialogResult == true)
                {
                    Accounts = searchAccountControl.Accounts;
                    SelectedAccount = searchAccountControl.SelectedAccount;
                }
            };
            _searchWindow.ShowDialog();
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
           "SelectedAccount", typeof(Account), typeof(LookupAccountControl), new PropertyMetadata(null, OnSelectedAccountChanged));

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
