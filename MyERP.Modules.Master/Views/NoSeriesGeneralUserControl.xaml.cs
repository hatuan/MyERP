using System.ComponentModel.Composition;
using System.Windows.Controls;
using MyERP.Infrastructure;
using MyERP.Modules.Master.ViewModels;

namespace MyERP.Modules.Master.Views
{
    [ViewExport(RegionName = NoSeriesViewRegionNames.NoSeriesGeneral)]
    public partial class NoSeriesGeneralUserControl : UserControl
    {
        public NoSeriesGeneralUserControl()
        {
            InitializeComponent();
        }

        [Import]
        public NoSeriesViewModel ViewModel
        {
            private get
            {
                return this.DataContext as NoSeriesViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }
    }
}
