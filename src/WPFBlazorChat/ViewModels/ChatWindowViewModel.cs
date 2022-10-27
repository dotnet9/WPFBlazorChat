using Prism.Mvvm;
using WPFBlazorChat.Models;

namespace WPFBlazorChat.ViewModels;

public class ChatWindowViewModel : BindableBase
{
    public ChatWindowViewModel(ChatUserItem user)
    {
        this.Title = $"{user.UserName}的对话";
    }

    private string _title = "的对话";

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }
}