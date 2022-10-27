using Prism.Ioc;
using Prism.Modularity;
using System.Windows;
using WPFBlazorChat.Modules.ModuleName;
using WPFBlazorChat.Services;
using WPFBlazorChat.Services.Interfaces;
using WPFBlazorChat.Views;

namespace WPFBlazorChat;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    protected override Window CreateShell()
    {
        return Container.Resolve<MainWindow>();
    }

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        containerRegistry.RegisterSingleton<IMessageService, MessageService>();
    }

    protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
    {
        moduleCatalog.AddModule<ModuleNameModule>();
    }
}
