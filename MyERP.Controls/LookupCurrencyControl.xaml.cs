using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using MyERP.Infrastructure.Annotations;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;
using Telerik.Windows.Controls;
using WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation;

namespace MyERP.Controls
{
    public partial class LookupCurrencyControl : UserControl, INotifyPropertyChanged
    {
        public LookupCurrencyControl()
        {
            InitializeComponent();

            if (!MyERP.Infrastructure.ViewModelBase.IsInDesignModeStatic)
            {
                _currencyRepository = new CurrencyRepository();
                this.SearchCommand = new DelegateCommand(this.OnSearchCommandExecuted);
                LayoutRoot.DataContext = this;

                this._loadTimer = new DispatcherTimer();
                // You can control the load delay between typing in the textbox and going to the server.
                this._loadTimer.Interval = new TimeSpan(0, 0, 0, 0, 500);
                this._loadTimer.Tick += this.OnLoadTimerTick;

            }
        }

        private readonly DispatcherTimer _loadTimer;

        private void OnLoadTimerTick(object sender, EventArgs e)
        {
            if (this._loadTimer.IsEnabled)
            {
                this._loadTimer.Stop();
            }

            IsBusy = true;
            _currencyRepository.GetCurrenciesByLookupValue(textBox.SearchText, results =>
            {
                Currencies = new ObservableCollection<Currency>(results);
                IsBusy = false;
            });
        }

        private readonly CurrencyRepository _currencyRepository;

        readonly RadWindow _searchWindow = new RadWindow();

        private void TextBox_OnSearchTextChanged(object sender, EventArgs e)
        {
            if (this._loadTimer.IsEnabled)
            {
                this._loadTimer.Stop();
            }

            this._loadTimer.Start();
        }

        public bool IsBusy { get; set; }

        public ICommand SearchCommand { get; set; }

        private void OnSearchCommandExecuted(object obj)
        {
            StyleManager.SetTheme(_searchWindow, new Windows8Theme());

            _searchWindow.Width = 600;
            _searchWindow.Height = 600;
            var searchCurrencyControl = new SearchCurrencyControl
            {
                searchValue = {Text = textBox.SearchText},
                SelectedCurrency = SelectedCurrency,
                Currencies = Currencies
            };
            _searchWindow.Content = searchCurrencyControl;
            _searchWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            _searchWindow.HideMinimizeButton = true;
            _searchWindow.HideMaximizeButton = true;
            _searchWindow.Closed += (sender, args) =>
            {
                if (_searchWindow.DialogResult == true)
                {
                    Currencies = searchCurrencyControl.Currencies;
                    SelectedCurrency = searchCurrencyControl.SelectedCurrency;
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
            "Id", typeof(Guid), typeof(LookupCurrencyControl), new PropertyMetadata(Guid.Empty, OnIdChanged));

        private static void OnIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newGuid = (Guid)e.NewValue;
            var lookupControl = d as LookupCurrencyControl;
            if (lookupControl != null)
            {
            }
        }

        private ObservableCollection<Currency> _currencies;
        public ObservableCollection<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                OnPropertyChanged("Currencies");
            }
        }

        public Currency SelectedCurrency
        {
            get
            {
                return (Currency)GetValue(SelectedCurrencyProperty);
            }
            set
            {
                SetValue(SelectedCurrencyProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedCurrencyProperty = DependencyProperty.Register(
           "SelectedCurrency", typeof(Currency), typeof(LookupCurrencyControl), new PropertyMetadata(null, OnSelectedCurrencyChanged));

        private static void OnSelectedCurrencyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newCurrency = (Currency)e.NewValue;
            var lookupControl = d as LookupCurrencyControl;

            if (lookupControl != null)
            {
                lookupControl.textBox.SelectedItem = newCurrency;
                lookupControl.Id = newCurrency == null ? Guid.Empty : newCurrency.Id;
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
