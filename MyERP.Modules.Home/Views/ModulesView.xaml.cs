using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Modules.Home.ViewModels;
using MyERP.ViewModels;
using MyERP.DataAccess;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Home.Views
{
    [ViewExport(RegionName = RegionNames.HomeWindowRegion, IsActiveByDefault = false)]
    public partial class ModulesView : INavigationAware
    {
        public ModulesView()
        {
            InitializeComponent();
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel;

        [Import]
        public ModulesViewModel ViewModel
        {
            private get
            {
                return this.DataContext as ModulesViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            //this.RegionManager.RequestNavigate(RegionNames.MainMenuRegion, "HomeMainMenuView");
            var win = this.ParentOfType<HomeWindow>();
            
            win.CanClose = false;
            win.Width = 1210;
            win.Height = 700;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private void TitleStateChanged(object sender, Telerik.Windows.RadRoutedEventArgs e)
        {
        	var item = e.OriginalSource as RadTileViewItem;
			if (item != null)
			{
				RadFluidContentControl fluid = item.ChildrenOfType<RadFluidContentControl>().FirstOrDefault();
				if (fluid != null)
				{
					switch (item.TileState)
					{
						case TileViewItemState.Maximized:
							fluid.State = FluidContentControlState.Large;
							break;
						case TileViewItemState.Minimized:
							fluid.State = FluidContentControlState.Small;
							break;
						case TileViewItemState.Restored:
							fluid.State = FluidContentControlState.Normal;
							break;
						default:
							break;
					}
				}
			}
        }

        private void OnGeneralLeaderJournalsButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            Module setupEntity = (sender as Button).DataContext as Module;

            if (setupEntity.IdAsName == ModuleName.GeneralLeaderJournals)
            {
                this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.FinancialModule);
                this.EventAggregator.GetEvent<GeneralLeaderJournalsClickedEvent>().Publish(setupEntity);
            }
        }

        private void OnGeneralLeaderReportsButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
        }

        private void OnGeneralLeaderSetupsButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            Module setupEntity = (sender as Button).DataContext as Module;

            if (setupEntity.IdAsName == ModuleName.GeneralLeaderSetupChartOfAccounts)
            {
                this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.FinancialModule);
                this.EventAggregator.GetEvent<AccountClickedEvent>().Publish(setupEntity);
            }
        }

        private void OnSetupsButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            Module setupEntity = (sender as Button).DataContext as Module;

        }
    }
}
