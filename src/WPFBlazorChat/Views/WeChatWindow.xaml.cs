using WPFBlazorChat.Helpers;
using WPFBlazorChat.Shared.Models;

namespace WPFBlazorChat.Views;

public partial class WeChatWindow : Window
{
    public WeChatWindow(User user)
    {
        var services = IocHelper.GetIoc();
        services.AddSingleton(user);
        Resources.SetIoc(services);

        InitializeComponent();
    }
}