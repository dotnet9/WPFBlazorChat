using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WPFBlazorChat.Helpers;
using WPFBlazorChat.Models;

namespace WPFBlazorChat.Views;

public partial class WeChatWindow : Window
{
    public WeChatWindow(User user)
    {
        var services = ServiceCollectionExtension.GetIoc();
        services.AddSingleton(user);
        Resources.SetIoc(services);

        InitializeComponent();

        Helpers.MouseMove.Init();
    }
}