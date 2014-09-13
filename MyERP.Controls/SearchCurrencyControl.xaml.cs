using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Input;
using MyERP.Infrastructure.Annotations;
using MyERP.Repositories;
using MyERP.Repository.MyERPService;
using Telerik.Windows.Controls;
using ViewModelBase = MyERP.Infrastructure.ViewModels.ViewModelBase;

namespace MyERP.Controls
{
    public partial class SearchCurrencyControl : UserControl, INotifyPropertyChanged
    {
        public SearchCurrencyControl()
        {
            InitializeComponent();
            if (!ViewModelBase.IsInDesignModeStatic)
            {
                _currencyRepository = new CurrencyRepository();
                this.OkCommand = new DelegateCommand(this.OnOkCommandExecuted);
                this.SearchCommand = new DelegateCommand(this.OnSearchCommandExecuted);
                LayoutRoot.DataContext = this;
            }
        }

        private readonly CurrencyRepository _currencyRepository;

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
            _currencyRepository.GetCurrenciesByLookupValue(searchValue.Text, results =>
            {
                Currencies = new ObservableCollection<Currency>(results);
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
