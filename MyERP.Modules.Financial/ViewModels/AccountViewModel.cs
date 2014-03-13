using System;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using MyERP.Infrastructure.ViewModels;

namespace MyERP.Modules.Financial.ViewModels
{
    public class AccountViewModel : NavigationAwareDataViewModel
    {
        public DomainContext Context { get; set; }

        #region NavigationAwareDataViewModel overrides
        public override void OnImportsSatisfied()
        {
            base.OnImportsSatisfied();
            //this.Context = this.ModulesRepository.Context;
        }
        #endregion
    }
}
