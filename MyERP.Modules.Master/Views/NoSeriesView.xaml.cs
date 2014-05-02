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
using MyERP.Modules.Master.ViewModels;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Master.Views
{
    [ViewExport(RegionName = RegionNames.MasterWindowRegion, IsActiveByDefault = false)]
    public partial class NoSeriesView : UserControl, IPartImportsSatisfiedNotification, INavigationAware
    {
        public NoSeriesView()
        {
            InitializeComponent();
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public NoSeriesViewModel ViewModel
        {
            private get
            {
                return this.DataContext as NoSeriesViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var win = this.ParentOfType<MasterWindow>();
            win.CanClose = false;
            win.Width = 1200;
            win.Height = 700;

            if (DataContext is ICloseable)
            {
                (DataContext as ICloseable).RequestClose += (_, __) =>
                {
                    RadWindow window = this.ParentOfType<MasterWindow>();
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

        #region IPartImportsSatisfiedNotification
        public void OnImportsSatisfied()
        {

        }
        #endregion
    }
}
