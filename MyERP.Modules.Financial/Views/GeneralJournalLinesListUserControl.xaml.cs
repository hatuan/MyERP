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
    [ViewExport(RegionName = GeneralJournalsViewRegionNames.GeneralJournalLinesOverview, IsActiveByDefault = false)]
    public partial class GeneralJournalLinesListUserControl : UserControl
    {
        public GeneralJournalLinesListUserControl()
        {
            InitializeComponent();
        }

        [Import]
        public GeneralJournalLinesViewModel ViewModel
        {
            private get
            {
                return this.DataContext as GeneralJournalLinesViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
