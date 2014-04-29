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
            Module clickEntity = (sender as Button).DataContext as Module;

            switch (clickEntity.IdAsName)
            {
                case ModuleName.GeneralLeaderJournals:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.FinancialModule);
                    this.EventAggregator.GetEvent<GeneralLeaderJournalsClickedEvent>().Publish(clickEntity);
                    break;
            }
        }

        private void OnGeneralLeaderReportsButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
        	// TODO: Add event handler implementation here.
            Module clickEntity = (sender as Button).DataContext as Module;

            switch (clickEntity.IdAsName)
            {
            }
        }

        private void OnGeneralLeaderSetupsButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
             Module clickEntity = (sender as Button).DataContext as Module;

            switch (clickEntity.IdAsName)
            {
                case ModuleName.GeneralLeaderSetupAccountOpeningBalances:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.FinancialModule);
                    this.EventAggregator.GetEvent<GeneralLeaderSetupAccountsOpeningBalanceClickedEvent>().Publish(clickEntity);
                    break;
                
                case ModuleName.GeneralLeaderSetupChartOfAccounts:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.FinancialModule);
                    this.EventAggregator.GetEvent<GeneralLeaderSetupChartOfAccountsClickedEvent>().Publish(clickEntity);
                    break;

                case ModuleName.GeneralLeaderSetup:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.FinancialModule);
                    this.EventAggregator.GetEvent<GeneralLeaderSetupClickedEvent>().Publish(clickEntity);
                    break;
            }
        }

        private void OnSetupsButtonClicked(object sender, System.Windows.RoutedEventArgs e)
        {
            Module clickEntity = (sender as Button).DataContext as Module;

            switch (clickEntity.IdAsName)
            {
                case ModuleName.SetupCurencies:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.SetupModule);
                    this.EventAggregator.GetEvent<SetupCurenciesClickedEvent>().Publish(clickEntity);
                    break;

                case ModuleName.SetupCurenciesExchangeRate:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.SetupModule);
                    this.EventAggregator.GetEvent<SetupCurenciesExchangeRateClickedEvent>().Publish(clickEntity);
                    break;

                case ModuleName.SetupClientInformation:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.SetupModule);
                    this.EventAggregator.GetEvent<SetupClientInformationClickedEvent>().Publish(clickEntity);
                    break;

                case ModuleName.SetupOrganizations:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.SetupModule);
                    this.EventAggregator.GetEvent<SetupOrganizationsClickedEvent>().Publish(clickEntity);
                    break;

                case ModuleName.SetupUsers:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.SetupModule);
                    this.EventAggregator.GetEvent<SetupUsersClickedEvent>().Publish(clickEntity);
                    break;
                    
                case ModuleName.SetupNoSeries:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.SetupModule);
                    this.EventAggregator.GetEvent<SetupNoSeriesClickedEvent>().Publish(clickEntity);
                    break;

                case ModuleName.SetupPeriod:
                    this.ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.SetupModule);
                    this.EventAggregator.GetEvent<SetupPeriodClickedEvent>().Publish(clickEntity);
                    break;
                    
            }
            
        }
    }
}
