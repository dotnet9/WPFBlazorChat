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
        _users = UserService.GetUsers();

        Messenger.Default.Subscribe<SendChatLogMessage>(this, ReceiveMsg, ThreadOption.UiThread, null);
        return base.OnInitializedAsync();
    }

    void ShowUser(User user)
    {
        _checkedUser = user;
    }

    void ReceiveMsg(SendChatLogMessage msg)
    {
        InvokeAsync(() =>
        {
            var sender = msg.Log.Sender == CurrentUser.UserName ? "我" : msg.Sender;
            _receiveMsg += $"{sender}: {msg.Log.SendTime:yyyy-MM-dd HH:mm:ss}\r\n{msg.Log.Message}\r\n";
            StateHasChanged();
        });
    }

    void SendMsg(KeyboardEventArgs args)
    {
        if (args.Key != "Enter" || string.IsNullOrWhiteSpace(_chatMsg))
        {
            return;
        }

        var newMsg = new ChatLog(CurrentUser!.UserName!, _checkedUser?.UserName, _chatMsg, DateTime.Now);

        Messenger.Default.Publish(this, new SendChatLogMessage(this, newMsg));
        _chatMsg = string.Empty;
    }
}