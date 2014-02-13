using MyERP.Infrastructure;
using MyERP.ViewModels;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace MyERP.Views
{
    [ViewExport(RegionName = "ContentRegion")]
    public partial class LoginView : UserControl
	{
		public LoginView()
		{
			// Required to initialize variables
			InitializeComponent();
		}

        [Import]
        public LoginViewModel ViewModel
        {
            private get
            {
                return this.DataContext as LoginViewModel;
            }

            set
            {
                this.DataContext = value;
            }
        }
	}
}