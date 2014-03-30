using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using MyERP.Web;
using MyERP.DataAccess;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace MyERP.Controls
{
    public partial class LookupCurrencyControl : UserControl
    {
        public LookupCurrencyControl()
        {
            InitializeComponent();

            this.Loaded += OnLookupControlLoaded;
        }

        void OnLookupControlLoaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= OnLookupControlLoaded;

            this.innerViewModel = new LookupCurrencyControlViewModel();
            this.LayoutRoot.DataContext = this.innerViewModel;
            this.innerViewModel.UpdateDate(this.Id);
            this.textBox.SelectedItem = this.innerViewModel.SelectedCurrency;
            this.dropDownGrid.SelectedItem = this.innerViewModel.SelectedCurrency;
            this.innerViewModel.PropertyChanged += this.OnInnerViewModelPropertyChanged;

            this.dropDownButton.PopupPlacementTarget = this.textBox;
        }


        private LookupCurrencyControlViewModel innerViewModel;
        
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

            if (lookupControl.innerViewModel != null)
            {
                lookupControl.innerViewModel.PropertyChanged -= lookupControl.OnInnerViewModelPropertyChanged;
                lookupControl.innerViewModel.UpdateDate(newGuid);
                lookupControl.textBox.SelectedItem = lookupControl.innerViewModel.SelectedCurrency;
                lookupControl.dropDownGrid.SelectedItem = lookupControl.innerViewModel.SelectedCurrency;
                lookupControl.innerViewModel.PropertyChanged += lookupControl.OnInnerViewModelPropertyChanged;
            }
        }

        
        private void OnInnerViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedCurrency")
            {
                var selectedItem = (sender as LookupCurrencyControlViewModel).SelectedCurrency;
                this.Id = selectedItem != null
                    ? (sender as LookupCurrencyControlViewModel).SelectedCurrency.Id
                    : Guid.Empty;
            }
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
            this._currencies.LoadedData += CurrenciesLoadedData;
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
