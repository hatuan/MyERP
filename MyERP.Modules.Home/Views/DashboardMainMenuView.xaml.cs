using MyERP.Infrastructure;
using MyERP.ViewModels;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace MyERP.Modules.Home.Views
{
    [ViewExport(RegionName = "MainMenuRegion", IsActiveByDefault=false)]
    public partial class DashboardMainMenuView : UserControl
    {
        [Import]
        public IApplicationViewModel ApplicationViewModel
        {
            private get
            {
                return this.DataContext as IApplicationViewModel;
            }

            set
            {
                this.DataContext = value;
            }
        }

        public DashboardMainMenuView()
        {
            InitializeComponent();
        }
    }
}
