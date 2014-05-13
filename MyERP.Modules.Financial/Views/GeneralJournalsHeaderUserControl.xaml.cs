using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using MyERP.DataAccess;
using MyERP.Infrastructure;
using MyERP.Modules.Financial.ViewModels;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Financial.Views
{
    [ViewExport(RegionName = GeneralJournalsViewRegionNames.GeneralJournalsHeader, IsActiveByDefault = false)]
    public partial class GeneralJournalsHeaderUserControl : UserControl, INavigationAware, IPartImportsSatisfiedNotification
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
            this.GeneralJournalDocumentsViewModel.PropertyChanged +=
                (sender, args) =>
                {
                    if (args.PropertyName == "SelectedGeneralJournalDocument" 
                        && GeneralJournalDocumentsViewModel.SelectedGeneralJournalDocument != null)
                        
                        GeneralJournalLinesViewModel.GeneralJournalDocument = GeneralJournalDocumentsViewModel.SelectedGeneralJournalDocument;
                };

        }
        #endregion
        
        #region INavigationAware
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.DataContext = GeneralJournalDocumentsViewModel;

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

        public void OnGeneralJournalsHeaderSwitch(object obj)
        {
            this.DataContext = (obj as UserControl).DataContext;

            if (DataContext is ICloseable)
            {
                (DataContext as ICloseable).RequestClose += (_, __) =>
                {
                    RadWindow window = this.ParentOfType<FinancialWindow>();
                    window.Close();
                };
            }
        }

    }
}
