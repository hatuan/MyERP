using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using System.Linq;

namespace MyERP.Modules.Dashboard.ViewModels
{
    [Export]
    public class DashboardViewModel : MyERP.Infrastructure.ViewModels.NavigationAwareDataViewModel
    {
        //#region Repositories
        //[Import]
        //public DashboardRepository DashboardRepository { get; set; }
        //#endregion

        #region View-visible properties
        public DomainContext Context { get; set; }

        private bool isStatsLoading;
        public bool IsStatsLoading
        {
            get
            {
                return isStatsLoading;
            }
            set
            {
                isStatsLoading = value;
                this.RaisePropertyChanged("IsStatsLoading");
            }
        }
        #endregion

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            //this.Context = this.DashboardRepository.Context;
        }
        #endregion
    }
}
