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
using MyERP.Web;
using MyERP.DataAccess;
using Telerik.Windows.Controls;

namespace MyERP.Controls
{
    public partial class SearchCurrencyControl : UserControl, INotifyPropertyChanged
    {
        public SearchCurrencyControl()
        {
            InitializeComponent();

            this.OkCommand = new DelegateCommand(this.OnOkCommandExecuted);
            LayoutRoot.DataContext = this;
        }

        private IEnumerable<Currency> _currencies = Enumerable.Empty<Currency>();

        public IEnumerable<Currency> Currencies
        {
            get { return _currencies; }
            set
            {
                if(_currencies == value)
                    return;

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

        public ICommand OkCommand { get; set; }
        private void OnOkCommandExecuted(object obj)
        {
            RadWindow window = this.ParentOfType<RadWindow>();
            window.DialogResult = true;
            window.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
