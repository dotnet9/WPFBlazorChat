using Microsoft.Extensions.DependencyInjection;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using WPFBlazorChat.Views;

namespace WPFBlazorChat;

public partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
    }
}