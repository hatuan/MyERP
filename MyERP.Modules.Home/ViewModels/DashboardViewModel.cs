using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ServiceModel.DomainServices.Client;
using System.Linq;
using CRM.Repositories;
using MyERP.Repositories;

namespace MyERP.Modules.Home.ViewModels
{
    [Export]
    public class DashboardViewModel : MyERP.Infrastructure.ViewModels.NavigationAwareDataViewModel
    {
        //#region Repositories
        [Import]
        public DashboardRepository DashboardRepository { get; set; }
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

        public int RecentContactsCount
        {
            get
            {
                return 0;
            }
        }

        public int RecentMessagesCount
        {
            get
            {
                return 0;
            }
        }

        public int ActivitiesCount
        {
            get
            {
                return 0;
            }
        }

        public int OpenOpportunitiesCount
        {
            get
            {
                return 0;
            }
        }

        public int OverdueOpportunitiesCount
        {
            get
            {
                return 0;
            }
        }

        public int TodosCount
        {
            get
            {
                return 0;
            }
        }

        #endregion

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            this.Context = this.DashboardRepository.Context;
        }
        #endregion
    }
}
