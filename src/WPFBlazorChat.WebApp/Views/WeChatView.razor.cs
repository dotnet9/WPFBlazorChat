using BlazorComponent;
using Microsoft.AspNetCore.Components.Web;
using WPFBlazorChat.Core.Messagers;
using WPFBlazorChat.Shared.Messages;
using WPFBlazorChat.Shared.Models;

namespace WPFBlazorChat.WebApp.Views;

public partial class WeChatView
{
    private bool _miniDrawer = true;
    private bool _drawer = true;

    private List<(string icon, string text)> quickMenus = new()
    {
        ("mdi-message-text", "消息"),
        ("mdi-email", "邮件"),
        ("mdi-domain", "Office"),
    };

    private StringNumber _model = 1;
    private string? _searchKey;
    private List<User>? _users = null;
    private User? _checkedUser;
    private string? _chatMsg;
    private string? _receiveMsg;

    protected override Task OnInitializedAsync()
    {
        WindowService.Init();

        // 获取好友，或者包含自己的群组
        _users = UserService.GetUsers().Where(x => ((x.Type != (int)UserType.Group && x.Id != CurrentUser.Id))
                                                   || (x.Type == (int)UserType.Group &&
                                                       x.Members!.Contains(CurrentUser.Id))).ToList();

        Messenger.Default.Subscribe<SendChatLogMessage>(this, ReceiveMsg, ThreadOption.UiThread, null);
        return base.OnInitializedAsync();
    }

    void ShowUser(User user)
    {
        _receiveMsg = string.Empty;
        _checkedUser = user;
    }

    void ReceiveMsg(SendChatLogMessage msg)
    {
        // 发送者为当前窗口所属的用户，或者接收者为当前窗口所属的用户且发送者为选择的用户
        if (msg.Log.Sender.Id == CurrentUser.Id || msg.Log.Sender.Id == _checkedUser?.Id
                                                || _checkedUser?.Members?.Contains(msg.Log.Sender.Id) == true)
        {
            InvokeAsync(() =>
            {
                var sender = msg.Log.Sender.Id == CurrentUser.Id ? "我" : msg.Log.Recipient.UserName;
                _receiveMsg += $"{sender}: {msg.Log.SendTime:yyyy-MM-dd HH:mm:ss}\r\n{msg.Log.Message}\r\n";
                StateHasChanged();
            });
        }
    }

    void SendMsg(KeyboardEventArgs args)
    {
        if (args.Key != "Enter" || string.IsNullOrWhiteSpace(_chatMsg) || _checkedUser == null)
        {
            return;
        }

        var newMsg = new ChatLog(CurrentUser!, _checkedUser, _chatMsg, DateTime.Now);

        Messenger.Default.Publish(this, new SendChatLogMessage(this, newMsg));
        _chatMsg = string.Empty;
    }
}