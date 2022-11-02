using WPFBlazorChat.Core.Messagers;
using WPFBlazorChat.Shared.Messages;
using WPFBlazorChat.Views;

namespace WPFBlazorChat;

public partial class App
{
    public App()
    {
        // 订阅打开聊天窗口消息，在主窗口点击用户时，确认后会发送此消息
        Messenger.Default.Subscribe<OpenWeChatMessage>(this, msg =>
        {
            var chatWin = new WeChatWindow(msg.User);
            chatWin.Show();
        }, ThreadOption.UiThread, null);
    }
}