using System;
using System.Collections.Generic;
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

namespace MyERP.Modules.Master.Views
{
    [ViewExport(RegionName = NoSeriesViewRegionNames.NoSeriesOverview)]
    public partial class NoSeriesListUserControl : UserControl
    {
        public NoSeriesListUserControl()
        {
            InitializeComponent();
        }
    }
}
