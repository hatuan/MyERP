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
    public partial class LookupCurrencyControl : UserControl
    {
        public LookupCurrencyControl()
        {
            InitializeComponent();

            this.SearchCommand = new DelegateCommand(this.OnSearchCommandExecuted);
            LayoutRoot.DataContext = this;
        }

        RadWindow searchWindow = new RadWindow();

        public ICommand SearchCommand { get; set; }

        private void OnSearchCommandExecuted(object obj)
        {
            StyleManager.SetTheme(searchWindow, new Windows8Theme());

            searchWindow.Width = 600;
            searchWindow.Height = 600;
            var searchCurrencyControl = new SearchCurrencyControl();
            searchCurrencyControl.SelectedCurrency = SelectedCurrency;
            searchCurrencyControl.Currencies = Currencies;
            searchWindow.Content = searchCurrencyControl;
            searchWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            searchWindow.HideMinimizeButton = true;
            searchWindow.HideMaximizeButton = true;
            searchWindow.Closed += (sender, args) =>
            {
                if (searchWindow.DialogResult == true)
                {
                    SelectedCurrency = searchCurrencyControl.SelectedCurrency;
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
            "Id", typeof(Guid), typeof(LookupCurrencyControl), new PropertyMetadata(Guid.Empty, OnIdChanged));

        private static void OnIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newGuid = (Guid)e.NewValue;
            var lookupControl = d as LookupCurrencyControl;
            if (lookupControl != null)
            {
            }
        }

        public IEnumerable<Currency> Currencies
        {
            get
            {
                return (IEnumerable<Currency>)GetValue(CurrenciesProperty);
            }
            set
            {
                SetValue(CurrenciesProperty, value);
            }
        }

        public static readonly DependencyProperty CurrenciesProperty = DependencyProperty.Register(
            "Currencies", typeof(IEnumerable), typeof(LookupCurrencyControl), new PropertyMetadata(Enumerable.Empty<Currency>()));


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

        private void OnAccountsButtonClicked(object sender, RoutedEventArgs e)
        {
            var selectedItem = (sender as Button).DataContext as Currency;
            this.SelectedCurrency = Currencies.FirstOrDefault(c => c.Id == selectedItem.Id);
        }
    }
}
