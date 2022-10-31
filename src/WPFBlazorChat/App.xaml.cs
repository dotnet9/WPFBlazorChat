using WPFBlazorChat.Core.Messagers;
using WPFBlazorChat.Shared.Messages;
using WPFBlazorChat.Views;

namespace WPFBlazorChat;

public partial class App
{
    public App()
    {
        Messenger.Default.Subscribe<OpenWeChatMessage>(this, msg =>
        {
            var chatWin = new WeChatWindow(msg.User);
            chatWin.Show();
        }, ThreadOption.UiThread, null);
    }
}