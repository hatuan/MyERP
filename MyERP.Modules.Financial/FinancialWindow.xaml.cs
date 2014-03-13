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

namespace MyERP.Modules.Financial
{
    /// <summary>
    /// Interaction logic for FinancialWindow.xaml
    /// </summary>
    [Export("FinancialWindow", typeof(RadWindow))]
    public partial class FinancialWindow : IPartImportsSatisfiedNotification
    {
        [Import]
        public IRegionManager RegionManager { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        public FinancialWindow()
        {
            InitializeComponent();
            
        }

        public void OnImportsSatisfied()
        {
            //IRegionManager regionManager = ServiceLocator.Current.GetInstance<IRegionManager>();
            this.SetValue(Microsoft.Practices.Prism.Regions.RegionManager.RegionManagerProperty, RegionManager);
            this.EventAggregator.GetEvent<AccountClickedEvent>().Subscribe(OnAccountClickedEvent);
        }

        public void OnAccountClickedEvent(object args)
        {
            System.Diagnostics.Debug.WriteLine("AccountClickedEvent");
        }
    }
}
