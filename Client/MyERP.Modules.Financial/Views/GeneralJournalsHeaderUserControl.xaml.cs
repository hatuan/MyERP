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
    public partial class GeneralJournalsHeaderUserControl : UserControl
    {
        public GeneralJournalsHeaderUserControl()
        {
            InitializeComponent();
        }
    }
}
