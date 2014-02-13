using MyERP.Infrastructure;
using MyERP.ViewModels;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace MyERP.Views
{
    [ViewExport(RegionName = "MainMenuRegion", IsActiveByDefault=false)]
    public partial class MainMenuView : UserControl
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

        public MainMenuView()
        {
            InitializeComponent();
        }
    }
}
