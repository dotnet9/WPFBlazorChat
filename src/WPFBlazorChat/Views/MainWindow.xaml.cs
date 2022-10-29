using BlazorComponent.I18n;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System.Windows;
using WPFBlazorChat.Services;

namespace WPFBlazorChat.Views;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMasaBlazor();
        serviceCollection.TryAddScoped<I18n>();
        serviceCollection.TryAddScoped<CookieStorage>();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.TryAddSingleton<IUserService, UserService>();
        Resources.Add("services", serviceCollection.BuildServiceProvider()); ;

        InitializeComponent();


        Helpers.MouseMove.Init();
    }
}