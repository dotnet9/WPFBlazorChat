using System.Windows;
using WPFBlazorChat.Messages;
using WPFBlazorChat.Views;

namespace WPFBlazorChat;

public partial class App : Application
{
    public App()
    {
        // 订阅打开子窗口消息，在主窗口点击【+】按钮
        Messenger.Default.Subscribe<OpenSecondViewMessage>(this, msg =>
        {
            var chatWin = new SecondWindowView();
            chatWin.Show();
        }, ThreadOption.UiThread);
    }
}