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
    public partial class LookupAccountControl : UserControl
    {
        public LookupAccountControl()
        {
            InitializeComponent();

            this.Loaded += OnLookupAccountControlLoaded;
        }

        void OnLookupAccountControlLoaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= OnLookupAccountControlLoaded;

            this.innerViewModel = new LookupAccountControlViewModel();
            this.LayoutRoot.DataContext = this.innerViewModel;
            this.innerViewModel.UpdateDate(this.Id);
            this.textBox.SelectedItem = this.innerViewModel.SelectedAccount;
            this.dropDownGrid.SelectedItem = this.innerViewModel.SelectedAccount;
            this.innerViewModel.PropertyChanged += this.OnInnerViewModelPropertyChanged;

            this.dropDownButton.PopupPlacementTarget = this.textBox;
        }


        private LookupAccountControlViewModel innerViewModel;
        
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

            if (lookupControl.innerViewModel != null)
            {
                lookupControl.innerViewModel.PropertyChanged -= lookupControl.OnInnerViewModelPropertyChanged;
                lookupControl.innerViewModel.UpdateDate(newGuid);
                lookupControl.textBox.SelectedItem = lookupControl.innerViewModel.SelectedAccount;
                lookupControl.dropDownGrid.SelectedItem = lookupControl.innerViewModel.SelectedAccount;
                lookupControl.innerViewModel.PropertyChanged += lookupControl.OnInnerViewModelPropertyChanged;
            }
        }

        
        private void OnInnerViewModelPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "SelectedCurrency")
            {
                var selectedItem = (sender as LookupAccountControlViewModel).SelectedAccount;
                this.Id = selectedItem != null
                    ? (sender as LookupAccountControlViewModel).SelectedAccount.Id
                    : Guid.Empty;
            }
        }
    }


    public class LookupAccountControlViewModel : INotifyPropertyChanged
    {
        public LookupAccountControlViewModel()
        {
            MyERPDomainContext context = new MyERPDomainContext();
            EntityQuery<Account> getAccountsQuery = context.GetAccountsQuery().OrderBy(c => c.Code);

            this._accounts = new QueryableDomainServiceCollectionView<Account>(context, getAccountsQuery);
            this._accounts.AutoLoad = true;
            this._accounts.LoadedData += AccountsLoadedData;
        }

        private Account _selectedAccount = null;
        public Account SelectedAccount 
        {
            get
            {
                return this._selectedAccount;
            }
            set
            {
                this._selectedAccount = value;
                this.OnPropertyChanged("SelectedCurrency");
            }
        }

        private Guid _id = Guid.Empty;

        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private readonly QueryableDomainServiceCollectionView<Account> _accounts = null;
        public ICollectionView Accounts
        {
            get
            {
                return this._accounts;
            }
        }

        internal void UpdateDate(Guid id)
        {
            this.Id = id;
            this.SelectedAccount = id == Guid.Empty ? null : this.Accounts.AsQueryable().Cast<Account>().FirstOrDefault(c => c.Id == id);
        }

        void AccountsLoadedData(object sender, Telerik.Windows.Controls.DomainServices.LoadedDataEventArgs e)
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
