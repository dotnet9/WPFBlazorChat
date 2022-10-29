using BlazorComponent.I18n;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Prism.Events;
using System.Windows;
using WPFBlazorChat.Events;
using WPFBlazorChat.Models;
using WPFBlazorChat.Services;

namespace WPFBlazorChat.Views;

public partial class MainWindow : Window
{
    private readonly IEventAggregator _eventAggregator;

    public MainWindow(IEventAggregator eventAggregator)
    {
        _eventAggregator = eventAggregator;

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMasaBlazor(x => x.ConfigureTheme(theme =>
        {
            theme.Dark = true;
            theme.Themes.Dark.Primary = "#4318FF";
            theme.Themes.Dark.Accent = "#4318FF";
        }));
        serviceCollection.TryAddScoped<I18n>();
        serviceCollection.TryAddScoped<CookieStorage>();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.TryAddSingleton<IUserService, UserService>();
        serviceCollection.AddSingleton(_eventAggregator);
        Resources.Add("services", serviceCollection.BuildServiceProvider());

        eventAggregator.GetEvent<OpenUserDialogEvent>().Subscribe(ShowUser);

        InitializeComponent();


        Helpers.MouseMove.Init();
    }

    private void ShowUser(User user)
    {
        var chatWin = new ChatWindow(_eventAggregator, user);
        chatWin.Show();
    }
}