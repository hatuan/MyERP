using System.Windows.Controls;
using MyERP.Infrastructure;

namespace MyERP.Views
{
    [ViewExport(RegionName = "HeaderRegion")]
    public partial class HeaderView : UserControl
    {
        public HeaderView()
        {
            InitializeComponent();
        }
    }
}
