using MyERP.Infrastructure;
using MyERP.Modules.Home.ViewModels;
using MyERP.ViewModels;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Home.Views
{
    [ViewExport(RegionName = RegionNames.MainMenuRegion, IsActiveByDefault = false)]
    public partial class HomeMainMenuView : UserControl
    {
        [Import]
        public HomeViewModel ViewModel
        {
            get
            {
                return this.DataContext as HomeViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }

        public HomeMainMenuView()
        {
            InitializeComponent();
        }
    }
}
