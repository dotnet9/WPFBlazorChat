using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WPFBlazorChat.Models;

namespace WPFBlazorChat.Views;


public partial class ChatWindow : Window
{
    public ChatWindow(UserInfo user)
    {
        InitializeComponent();
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.AddMasaBlazor();
        serviceCollection.AddSingleton(user);
        Resources.Add("services", serviceCollection.BuildServiceProvider());
    }
}