using Microsoft.Extensions.DependencyInjection;
using System.Windows;

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