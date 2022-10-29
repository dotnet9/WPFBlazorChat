using BlazorComponent;
using WPFBlazorChat.Events;
using WPFBlazorChat.Models;

namespace WPFBlazorChat.Razors;

public partial class MainView
{
    // 用户列表
    List<User>? _users = null;
    private User? _selectedUser = null;

    // 点击的状态栏按钮索引
    StringNumber _toolBarButtonIndex = 1;

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
        _users = UserService.GetUsers();
        return base.OnInitializedAsync();
    }

    protected void SelectUser(User user)
    {
        _selectedUser = user;
        _isOpenSheet = true;
    }

    private void CloseSheet(bool needChat=true)
    {
        _isOpenSheet = false;
        if (needChat)
        {
            EventAggregator.GetEvent<OpenUserDialogEvent>().Publish(_selectedUser!);
        }
    }
}