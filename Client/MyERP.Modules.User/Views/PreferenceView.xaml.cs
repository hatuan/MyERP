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
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Modules.User.ViewModels;
using MyERP.ViewModels;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace MyERP.Modules.User.Views
{
    [ViewExport(RegionName = RegionNames.UserWindowRegion, IsActiveByDefault = false)]
    public partial class PreferenceView : UserControl, INavigationAware, IPartImportsSatisfiedNotification
    {
        public PreferenceView()
        {
            InitializeComponent();
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public PreferenceViewModel ViewModel
        {
            private get
            {
                return this.DataContext as PreferenceViewModel;
            }

            set
            {
                this.DataContext = value;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            UserWindow win = this.ParentOfType<UserWindow>();
            win.HideMaximizeButton = true;
            win.HideMinimizeButton = true;
            win.ResizeMode = ResizeMode.NoResize;
            win.UserWindowRegionPlaceholder.Width = this.Width;
            win.UserWindowRegionPlaceholder.Height = this.Height;

            ViewModel.ApplicationViewModel.IsLoadingData = true;
            ViewModel.OrganizationRepository.GetOrganizations(organizations =>
            {
                ViewModel.ApplicationViewModel.IsLoadingData = false;
                ViewModel.Organizations = organizations;
            });
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
            
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void OnImportsSatisfied()
        {
            if (DataContext is ICloseable)
            {
                (DataContext as ICloseable).RequestClose += (_, __) =>
                {
                    RadWindow window = this.ParentOfType<RadWindow>();
                    window.Close();
                };
            }

        }
    }
}
