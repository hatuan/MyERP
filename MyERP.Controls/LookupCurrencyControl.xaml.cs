using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using MyERP.DataAccess;

namespace MyERP.Controls
{
    public partial class LookupCurrencyControl : UserControl
    {
        public LookupCurrencyControl()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
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
                lookupControl.dropDownGrid.SelectedItem = newCurrency;
                lookupControl.Id = newCurrency == null ? Guid.Empty : newCurrency.Id;
            }
        }
    }
}
