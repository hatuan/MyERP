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
            "Id", typeof(Guid), typeof(LookupAccountControl), new PropertyMetadata(Guid.Empty, OnIdChanged));

        private static void OnIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newGuid = (Guid)e.NewValue;
            var lookupControl = d as LookupAccountControl;

            if (lookupControl != null)
            {
            }
        }

        public IEnumerable<Account> Accounts
        {
            get
            {
                return (IEnumerable<Account>)GetValue(AccountsProperty);
            }
            set
            {
                SetValue(AccountsProperty, value);
            }
        }

        public static readonly DependencyProperty AccountsProperty = DependencyProperty.Register(
            "Accounts", typeof(IEnumerable), typeof(LookupAccountControl), new PropertyMetadata(Enumerable.Empty<Account>()));

        public Account SelectedAccount
        {
            get
            {
                return (Account)GetValue(SelectedAccountProperty);
            }
            set
            {
                SetValue(SelectedAccountProperty, value);
            }
        }

        public static readonly DependencyProperty SelectedAccountProperty = DependencyProperty.Register(
           "SelectedAccount", typeof(Account), typeof(LookupAccountControl), new PropertyMetadata(null, OnSelectedAccountChanged));

        private static void OnSelectedAccountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var newAccount = (Account)e.NewValue;
            var lookupControl = d as LookupAccountControl;

            if (lookupControl != null)
            {
                lookupControl.textBox.SelectedItem = newAccount;
                lookupControl.dropDownGrid.SelectedItem = newAccount;
                lookupControl.Id = newAccount == null ? Guid.Empty : newAccount.Id;
            }
        }
    }

}
