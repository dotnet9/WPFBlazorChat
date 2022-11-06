using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WPFBlazorChat.Views;

public partial class MainWindowView : Window
{
    public MainWindowView()
    {
        InitializeComponent();
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.AddMasaBlazor();
        Resources.Add("services", serviceCollection.BuildServiceProvider());
    }
}