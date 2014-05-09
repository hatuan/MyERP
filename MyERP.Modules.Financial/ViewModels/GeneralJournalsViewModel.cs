using System;
using System.ComponentModel.Composition;
using System.Windows;
using MyERP.Modules.Financial.Views;


namespace MyERP.Modules.Financial.ViewModels
{
    [Export]
    public class GeneralJournalsViewModel
    {
        public GeneralJournalsViewModel()
        {
        }

        [Import]
        public GeneralJournalDocumentsViewModel GeneralJournalDocumentsViewModel { get; set; }

        [Import]
        public GeneralJournalLinesViewModel GeneralJournalLinesViewModel { get; set; }
    }
}
