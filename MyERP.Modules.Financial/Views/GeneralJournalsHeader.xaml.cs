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
using MyERP.Infrastructure;
using MyERP.Modules.Financial.ViewModels;

namespace MyERP.Modules.Financial.Views
{
    [ViewExport(RegionName = "GeneralJournalsHeader")]
    public partial class GeneralJournalsHeader : UserControl
    {
        public GeneralJournalsHeader()
        {
            InitializeComponent();
        }

        [Import]
        public GeneralJournalDocumentsViewModel ViewModel
        {
            private get
            {
                return this.DataContext as GeneralJournalDocumentsViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
