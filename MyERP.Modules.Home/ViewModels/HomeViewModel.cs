using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Infrastructure.Extensions;
using MyERP.Repositories;
using MyERP.ViewModels;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Home.ViewModels
{
    [Export]
    public class HomeViewModel : MyERP.Infrastructure.ViewModels.NavigationAwareDataViewModel
    {
        public ICommand SwitchToHomeWindowRegionCommand { get; set; }
        public ICommand LogoffCommand { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IApplicationViewModel ApplicationViewModel { get; set; }

        [Import]
        public SessionRepository SessionRepository { get; set; }

        [Import("HomeWindow", typeof(RadWindow))]
        public HomeWindow HomeWindow { get; set; }

        public HomeViewModel()
        {
            this.SwitchToHomeWindowRegionCommand = new DelegateCommand<string>(OnSwitchToHomeWindowRegion);
            this.LogoffCommand = new Microsoft.Practices.Prism.Commands.DelegateCommand(OnLogoff);
        }

        private void OnLogoff()
        {
            Session currentSession =
                SessionRepository.Context.Sessions.First(e => e.Id == ApplicationViewModel.SessionId);
            if (currentSession != null)
            {
                SessionRepository.Context.Sessions.Remove(currentSession);
                SessionRepository.SaveOrUpdateEntities();
            }
            //Close all windows
            RadWindowManager.Current.CloseAllWindows();
            //Clear Main menu region
            this.RegionManager.Regions[RegionNames.MainMenuRegion].ClearActiveViews();

            ApplicationViewModel.SwitchContentRegionViewCommand.Execute(ModuleNames.UserModule);
            this.RegionManager.RequestNavigate(RegionNames.UserWindowRegion, "LoginView");
        }

        private void OnSwitchToHomeWindowRegion(string viewName)
        {
            this.RegionManager.RequestNavigate(RegionNames.HomeWindowRegion, viewName);
        }
    }
}
