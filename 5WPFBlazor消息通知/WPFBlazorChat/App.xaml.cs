using System.Windows;
using WPFBlazorChat.Messages;
using WPFBlazorChat.Views;

namespace WPFBlazorChat;

public partial class App : Application
{
    public App()
    {

        // 订阅打开聊天窗口消息，在主窗口点击用户时，确认后会发送此消息
        Messenger.Default.Subscribe<OpenSecondViewMessage>(this, msg =>
        {
            var chatWin = new SecondWindowView();
            chatWin.Show();
        }, ThreadOption.UiThread);
    }
}