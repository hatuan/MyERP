using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyERP.ViewModels
{
    public interface IApplicationViewModel
    {
        ICommand SwitchContentRegionViewCommand { get; }
        ICommand SwitchModuleCommand { get; }
        string CurrentModuleName { get; }
        string CurrentViewName { get; }
        bool IsLoadingData { get; set; }
        Guid SessionId { get; }
        Guid OrganizationId { get; set; }
        DateTime WorkingDate { get; set; }
    }
}