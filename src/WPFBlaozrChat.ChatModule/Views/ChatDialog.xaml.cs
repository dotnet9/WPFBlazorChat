using BlazorComponent.I18n;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Prism.Events;
using System.Windows;
using WPFBlazorChat.Core;

namespace WPFBlaozrChat.ChatModule.Views;

/// <summary>
/// Interaction logic for ViewA.xaml
/// </summary>
public partial class ChatDialog : Window
{
    public ChatDialog(IEventAggregator eventAggregator)
    {
        InitializeComponent();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMasaBlazor();
        serviceCollection.TryAddScoped<I18n>();
        serviceCollection.TryAddScoped<CookieStorage>();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.TryAddSingleton<IUserService, UserService>();
        serviceCollection.AddSingleton(eventAggregator);
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