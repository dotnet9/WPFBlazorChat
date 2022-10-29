using BlazorComponent;
using WPFBlazorChat.Messagers;
using WPFBlazorChat.Messages;
using WPFBlazorChat.Models;

namespace WPFBlazorChat.Razors;

public partial class WeChatView
{
    List<(string icon, string text)> quickMenus = new()
    {
        ("mdi-message-text", "消息"),
        ("mdi-email", "邮件"),
        ("mdi-domain", "Office"),
    };

    StringNumber model = 1;

    List<User>? _users = null;
    User? checkedUser;
    string chatMsg;
    string receiveMsg;

    protected override Task OnInitializedAsync()
    {
        _users = UserService.GetUsers();

        Messenger.Default.Subscribe<SendChatLogMessage>(this, ReceiveMsg, ThreadOption.UiThread, null);
        return base.OnInitializedAsync();
    }

    void ShowUser(User user)
    {
        checkedUser = user;
    }

    void ReceiveMsg(SendChatLogMessage msg)
    {
        InvokeAsync(() =>
        {
            var sender = msg.Log.Sender == CurrentUser.UserName ? "我" : msg.Sender;
            receiveMsg += $"{sender}: {msg.Log.SendTime:yyyy-MM-dd HH:mm:ss}\r\n{msg.Log.Message}\r\n";
            StateHasChanged();
        });
    }

    void SendMsg()
    {
        if (string.IsNullOrWhiteSpace(chatMsg))
        {
            return;
        }

        var newMsg = new ChatLog(CurrentUser!.UserName!, checkedUser?.UserName, chatMsg, DateTime.Now);

        Messenger.Default.Publish(this, new SendChatLogMessage(this, newMsg));
        chatMsg = string.Empty;
    }
}