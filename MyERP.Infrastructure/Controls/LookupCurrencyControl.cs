using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.ViewModel;
using MyERP.DataAccess;
using MyERP.Infrastructure.Annotations;
using MyERP.Web;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace MyERP.Controls
{
    public class LookupCurrencyControl : Control
    {
        private bool _isTemplateApplied;
        private RadAutoCompleteBox textBox;
        private RadDropDownButton dropDownButton;
        private RadGridView dropDownGrid;
        private Panel rootPanel;
        private LookupCurrencyViewModel innerViewModel;

        public LookupCurrencyControl()
        {
            _isTemplateApplied = false;
            DefaultStyleKey = typeof (LookupCurrencyControl);
            
            this.Unloaded += this.OnLookupCurrencyControlUnloaded;
        }

        public static readonly DependencyProperty IdProperty = DependencyProperty.Register(
            "Id", typeof(Guid), typeof(LookupCurrencyControl), new PropertyMetadata(Guid.Empty,OnIdChanged));

        private static void OnIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newGuid = (Guid)e.NewValue;
            var lookupCurrencyControl = d as LookupCurrencyControl;

            if (lookupCurrencyControl.innerViewModel != null)
            {
                lookupCurrencyControl.innerViewModel.PropertyChanged -= lookupCurrencyControl.OnViewModelPropertyChanged;
                lookupCurrencyControl.innerViewModel.UpdateDate(newGuid);
                lookupCurrencyControl.textBox.SelectedItem = lookupCurrencyControl.innerViewModel.SelectedCurrency;
                lookupCurrencyControl.dropDownGrid.SelectedItem = lookupCurrencyControl.innerViewModel.SelectedCurrency;
                lookupCurrencyControl.innerViewModel.PropertyChanged += lookupCurrencyControl.OnViewModelPropertyChanged;
            }
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


        public override void OnApplyTemplate()
        {
            if (_isTemplateApplied) return;
            
            textBox = GetTemplateChild("textBox") as RadAutoCompleteBox;
            dropDownButton = GetTemplateChild("dropDownButton") as RadDropDownButton;
            dropDownGrid = GetTemplateChild("dropDownGrid") as RadGridView;
            rootPanel = GetTemplateChild("PART_LayoutRoot") as Panel;

            this.rootPanel.DataContext = new LookupCurrencyViewModel();
            this.innerViewModel = this.rootPanel.DataContext as LookupCurrencyViewModel;
            this.innerViewModel.UpdateDate(this.Id);
            this.textBox.SelectedItem = this.innerViewModel.SelectedCurrency;
            this.dropDownGrid.SelectedItem = this.innerViewModel.SelectedCurrency;
            this.innerViewModel.PropertyChanged += this.OnViewModelPropertyChanged;

            this.dropDownButton.PopupPlacementTarget = this.textBox;
            base.OnApplyTemplate();

            _isTemplateApplied = true; 
        }
        
        void OnLookupCurrencyControlUnloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= this.OnLookupCurrencyControlUnloaded;
            innerViewModel.PropertyChanged -= this.OnViewModelPropertyChanged;
        }
        private void OnViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedCurrency")
            {
                Currency selectedCurrency = (sender as LookupCurrencyViewModel).SelectedCurrency;
                this.Id = selectedCurrency != null
                    ? (sender as LookupCurrencyViewModel).SelectedCurrency.Id
                    : Guid.Empty;
            }
        }
    }

    public class LookupCurrencyViewModel : INotifyPropertyChanged
    {
        public LookupCurrencyViewModel()
        {
            MyERPDomainContext context = new MyERPDomainContext();
            EntityQuery<Currency> getAccountsQuery = context.GetCurrenciesQuery().OrderBy(c => c.Code);

            this._curencies = new QueryableDomainServiceCollectionView<Currency>(context, getAccountsQuery);
            this._curencies.AutoLoad = true;
            this._curencies.LoadedData += _curencies_LoadedData;

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
                if (_selectedCurrency == value)
                    return;
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

        private readonly QueryableDomainServiceCollectionView<Currency> _curencies = null;
        public ICollectionView Currencies
        {
            get
            {
                return this._curencies;
            }
        }

        void _curencies_LoadedData(object sender, Telerik.Windows.Controls.DomainServices.LoadedDataEventArgs e)
        {
            if (e.HasError)
            {
                MessageBox.Show(e.Error.ToString(), "Load Error", MessageBoxButton.OK);
                e.MarkErrorAsHandled();
            }
            OnPropertyChanged("Currencies");
            UpdateDate(Id);
        }

        internal void UpdateDate(Guid id)
        {
            this.Id = id;
            this.SelectedCurrency = id == Guid.Empty ? null : this.Currencies.AsQueryable().Cast<Currency>().FirstOrDefault(c => c.Id == id);
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
