using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using MyERP.Infrastructure;
using Telerik.Windows.Controls;

namespace MyERP.Modules.Master
{
    /// <summary>
    /// Interaction logic for UserWindow.xaml
    /// </summary>
    [Export("MasterWindow", typeof(RadWindow))]
    public partial class MasterWindow : IPartImportsSatisfiedNotification
    {
        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        public MasterWindow()
        {
            InitializeComponent();
        }

        public void OnImportsSatisfied()
        {
            this.SetValue(Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty, RegionManager);

            this.EventAggregator.GetEvent<NoSeriesClickedEvent>().Subscribe(OnNoSeriesClickedEvent);
        }

        public void OnNoSeriesClickedEvent(object obj)
        {
            this.RegionManager.RequestNavigate("MasterWindowRegion", "NoSeriesView");
        }
    }
}
