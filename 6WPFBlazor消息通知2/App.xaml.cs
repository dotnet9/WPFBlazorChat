using System.Windows;
using WPFBlazorChat.Messagers;
using WPFBlazorChat.Views;

namespace WPFBlazorChat;


public partial class App : Application
{
    public App()
    {
        Messenger.Default.Subscribe<OpenChatViewMessage>(this, msg =>
        {
            new ChatWindow(msg.User).Show();
        }, ThreadOption.UiThread);
    }
}