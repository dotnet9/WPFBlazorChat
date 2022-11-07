using System.Windows;
using Microsoft.Extensions.DependencyInjection;

namespace WPFBlazorChat.Views;

public partial class SecondWindowView : Window
{
    public SecondWindowView()
    {
        InitializeComponent();
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.AddMasaBlazor();
        Resources.Add("services", serviceCollection.BuildServiceProvider());
    }
}