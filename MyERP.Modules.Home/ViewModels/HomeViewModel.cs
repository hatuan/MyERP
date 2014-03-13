using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using System.Linq;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Repositories;

namespace MyERP.Modules.Home.ViewModels
{
    [Export]
    public class HomeViewModel : MyERP.Infrastructure.ViewModels.NavigationAwareDataViewModel
    {
        public ICommand SwitchToHomeWindowRegionCommand { get; set; }

        [Import]
        public IRegionManager RegionManager { get; set; }

        public HomeViewModel()
        {
            this.SwitchToHomeWindowRegionCommand = new DelegateCommand<string>(OnSwitchToHomeWindowRegion);
        }

        private void OnSwitchToHomeWindowRegion(string viewName)
        {
            this.RegionManager.RequestNavigate(RegionNames.HomeWindowRegion, viewName);
        }
    }
}
