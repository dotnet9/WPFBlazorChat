using BlazorComponent.I18n;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Windows;
using WPFBlazorChat.Models;
using WPFBlazorChat.Services;

namespace WPFBlazorChat.Views;

public partial class WeChatWindow : Window
{

    public WeChatWindow(User user)
    {
        InitializeComponent();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMasaBlazor();
        serviceCollection.TryAddScoped<I18n>();
        serviceCollection.TryAddScoped<CookieStorage>();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.TryAddSingleton<IUserService, UserService>();
        serviceCollection.AddSingleton(user);
        Resources.Add("services", serviceCollection.BuildServiceProvider());
    }

    private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}