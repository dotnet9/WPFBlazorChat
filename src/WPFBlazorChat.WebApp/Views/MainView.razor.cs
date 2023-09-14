using BlazorComponent;
using WPFBlazorChat.Core.Messagers;
using WPFBlazorChat.Shared.Messages;
using WPFBlazorChat.Shared.Models;

namespace WPFBlazorChat.WebApp.Views;

public partial class MainView
{
    private User? _selectedUser = null;

    private string appId = Guid.NewGuid().ToString("N");

    // 确认对话框
    private bool _showComfirmDialog = false;

    // 点击的状态栏按钮索引
    private StringNumber _toolBarButtonIndex = 0;

    // 状态栏按钮颜色
    private string StatusBarButtonColors
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
        Messenger.Default.Subscribe<ChoiceUserMessage>(this, SelectUser, ThreadOption.UiThread, null);
        return base.OnInitializedAsync();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await MainInterop.Init(appId);
        }
    }

    protected void SelectUser(ChoiceUserMessage msg)
    {
        InvokeAsync(() =>
        {
            _selectedUser = msg.User;
            _isOpenSheet = true;
            this.StateHasChanged();
        });
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