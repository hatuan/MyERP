using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Modules.Financial.ViewModels;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Financial.Views
{
    [ViewExport(RegionName = RegionNames.FinancialWindowRegion, IsActiveByDefault = false)]
    public partial class GeneralJournalsView : UserControl, IPartImportsSatisfiedNotification, INavigationAware
    {
        public GeneralJournalsView()
        {
            InitializeComponent();
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public GeneralJournalsViewModel ViewModel
        {
            private get
            {
                return this.DataContext as GeneralJournalsViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        #region IPartImportsSatisfiedNotification
        public void OnImportsSatisfied()
        {
            
        }
        #endregion

        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var win = this.ParentOfType<FinancialWindow>();
            win.CanClose = false;
            win.Width = 1210;
            win.Height = 700;

            if (DataContext is ICloseable)
            {
                (DataContext as ICloseable).RequestClose += (_, __) =>
                {
                    RadWindow window = this.ParentOfType<FinancialWindow>();
                    window.Close();
                };
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }
        #endregion
    }
}
