using BlazorComponent.I18n;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Prism.Events;
using System.Windows;
using WPFBlazorChat.Models;
using WPFBlazorChat.Services;
using WPFBlazorChat.ViewModels;

namespace WPFBlazorChat.Views;

public partial class ChatWindow : Window
{
    public ChatWindowViewModel? ViewModel
    {
        get { return this.DataContext as ChatWindowViewModel; }
        set { this.DataContext = value; }
    }

    public ChatWindow(IEventAggregator eventAggregator, ChatUserItem user)
    {
        InitializeComponent();

        this.ViewModel ??= new ChatWindowViewModel(user);

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMasaBlazor();
        serviceCollection.TryAddScoped<I18n>();
        serviceCollection.TryAddScoped<CookieStorage>();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.TryAddSingleton<IUserService, UserService>();
        serviceCollection.AddSingleton(user);
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