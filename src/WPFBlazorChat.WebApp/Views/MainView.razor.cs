using BlazorComponent;
using WPFBlazorChat.Core.Messagers;
using WPFBlazorChat.Shared.Messages;
using WPFBlazorChat.Shared.Models;

namespace WPFBlazorChat.WebApp.Views;

public partial class MainView
{
    // 用户列表
    List<User>? _users = null;
    private User? _selectedUser = null;

    // 点击的状态栏按钮索引
    StringNumber _toolBarButtonIndex = 0;

    // 状态栏按钮颜色
    string StatusBarButtonColors
    {
        get
        {
            if (_toolBarButtonIndex == 0) return "blue-grey";
            if (_toolBarButtonIndex == 1) return "teal";
            if (_toolBarButtonIndex == 2) return "brown";
            if (_toolBarButtonIndex == 3) return "indigo";
            return "blue-grey";
        }
    }

    // 是否显示底部工作表
    bool _isOpenSheet;

    protected override Task OnInitializedAsync()
    {
        WindowService.Init();
        _users = UserService.GetUsers();
        return base.OnInitializedAsync();
    }

    protected void SelectUser(User user)
    {
        _selectedUser = user;
        _isOpenSheet = true;
    }

    private void CloseSheet(bool needChat = true)
    {
        _isOpenSheet = false;
        if (needChat)
        {
            Messenger.Default.Publish(this, new OpenWeChatMessage(this, _selectedUser!));
        }
    }
}