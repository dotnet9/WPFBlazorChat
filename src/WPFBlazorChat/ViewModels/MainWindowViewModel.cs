using Prism.Mvvm;

namespace WPFBlazorChat.ViewModels;

public class MainWindowViewModel : BindableBase
{
    private string _title = "WPF blazor对话小程序(WPF+Prism+Masa Blazor)";

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
}