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
using MyERP.Repositories;
using MyERP.Web;
using MyERP.DataAccess;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace MyERP.Controls
{
    public partial class SearchCurrencyControl : UserControl, INotifyPropertyChanged
    {
        public SearchCurrencyControl()
        {
            InitializeComponent();

            this.OkCommand = new DelegateCommand(this.OnOkCommandExecuted);
            this.SearchCommand = new DelegateCommand(this.OnSearchCommandExecuted);
            LayoutRoot.DataContext = this;
        }

        private readonly CurrencyRepository _currencyRepository = new CurrencyRepository();

        private IEnumerable<Currency> _currencies;

        public IEnumerable<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                _currencies = value;
                OnPropertyChanged("Currencies");
            }
        }

        private Currency _selectedCurrency = null;
        public Currency SelectedCurrency
        {
            get { return _selectedCurrency; }
            set
            {
                _selectedCurrency = value;
                OnPropertyChanged("SelectedCurrency");
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
            _currencyRepository.GetCurrenciesByLookupValue(searchValue.Text, currencies =>
            {
                Currencies = currencies;
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
