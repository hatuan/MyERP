using System.ComponentModel.Composition;
using System.Windows.Controls;
using MyERP.Infrastructure;
using MyERP.ViewModels;

namespace MyERP.Views
{
    [ViewExport(RegionName = "HeaderRegion")]
    public partial class HeaderView : UserControl
    {
        public HeaderView()
        {
            InitializeComponent();
        }

        [Import]
        public IApplicationViewModel ViewModel
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
    }
}
