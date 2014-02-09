using System.Windows.Input;

namespace MyERP.ViewModels
{
    public interface IApplicationViewModel
    {
        ICommand SwitchContentRegionViewCommand { get; }
        string CurrentViewName { get; }
        bool IsLoadingData { get; set; }
    }
}