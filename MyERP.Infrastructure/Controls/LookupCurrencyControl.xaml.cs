using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using MyERP.Infrastructure.Annotations;
using MyERP.Web;
using MyERP.DataAccess;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace MyERP.Controls
{
    public partial class LookupCurrencyControl : UserControl, INotifyPropertyChanged
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

        //private Currency _selectedCurrency;

        //public Currency SelectedCurrency
        //{
        //    get
        //    {
        //        return _selectedCurrency;
        //    }
        //    set
        //    {
        //        _selectedCurrency = value;
        //        Id = _selectedCurrency != null ? _selectedCurrency.Id : Guid.Empty;
        //        OnPropertyChanged("Id");
        //    }
        //}


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

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }


    public class LookupCurrencyControlViewModel : INotifyPropertyChanged
    {
        public LookupCurrencyControlViewModel()
        {
            MyERPDomainContext context = new MyERPDomainContext();
            EntityQuery<Currency> getCurrenciesQuery = context.GetCurrenciesQuery().OrderBy(c => c.Code);

            this._currencies = new QueryableDomainServiceCollectionView<Currency>(context, getCurrenciesQuery);
            this._currencies.AutoLoad = true;
            this._currencies.LoadedData += this.CurrenciesLoadedData;
        }

        private Currency _selectedCurrency = null;
        public Currency SelectedCurrency 
        {
            get
            {
                return this._selectedCurrency;
            }
            set
            {
                this._selectedCurrency = value;
                this.OnPropertyChanged("SelectedCurrency");
            }
        }

        private Guid _id = Guid.Empty;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private readonly QueryableDomainServiceCollectionView<Currency> _currencies = null;
        public ICollectionView Currencies
        {
            get
            {
                return this._currencies;
            }
        }

        internal void UpdateDate(Guid id)
        {
            this.Id = id;
            this.SelectedCurrency = id == Guid.Empty ? null : this.Currencies.AsQueryable().Cast<Currency>().FirstOrDefault(c => c.Id == id);
        }

        void CurrenciesLoadedData(object sender, Telerik.Windows.Controls.DomainServices.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                MessageBox.Show(e.Error.ToString(), "Load Error", MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
            OnPropertyChanged("Currencies");
            UpdateDate(Id);
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

    }
}
