using Prism.Regions;
using WPFBlazorChat.Core.Mvvm;
using WPFBlazorChat.Services.Interfaces;

namespace WPFBlazorChat.Modules.ModuleName.ViewModels;
public class ViewAViewModel : RegionViewModelBase
{
    private string _message;
    public string Message
    {
        get { return _message; }
        set { SetProperty(ref _message, value); }
    }

    public ViewAViewModel(IRegionManager regionManager, IMessageService messageService) :
        base(regionManager)
    {
        Message = messageService.GetMessage();
    }

    public override void OnNavigatedTo(NavigationContext navigationContext)
    {
        //do something
    }
}
