using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using MyERP.Infrastructure;
using MyERP.Modules.Financial.ViewModels;

namespace MyERP.Modules.Financial.Views
{
    [ViewExport(RegionName = GeneralJournalsViewRegionNames.GeneralJournalsHeader)]
    public partial class GeneralJournalsHeaderUserControl : UserControl, IPartImportsSatisfiedNotification
    {
        public GeneralJournalsHeaderUserControl()
        {
            InitializeComponent();
        }

        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import] 
        public GeneralJournalDocumentsViewModel GeneralJournalDocumentsViewModel { get; set; }

        [Import]
        public GeneralJournalLinesViewModel GeneralJournalLinesViewModel { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        #region IPartImportsSatisfiedNotification
        public void OnImportsSatisfied()
        {
            this.EventAggregator.GetEvent<GeneralJournalsHeaderSwitchEvent>().Subscribe(OnGeneralJournalsHeaderSwitch);
            
        }
        #endregion
        
        #region INavigationAware
        //public void OnNavigatedTo(NavigationContext navigationContext)
        //{
        //    this.DataContext = null;
        //}

        //public bool IsNavigationTarget(NavigationContext navigationContext)
        //{
        //    return true;
        //}

        //public void OnNavigatedFrom(NavigationContext navigationContext)
        //{

        //}
        #endregion

        public void OnGeneralJournalsHeaderSwitch(object obj)
        {
            System.Diagnostics.Debug.WriteLine(String.Format("GeneralJournalsHeaderSwitchEvent {0}", obj));
            this.DataContext = (obj as UserControl).DataContext;
        }

    }
}
