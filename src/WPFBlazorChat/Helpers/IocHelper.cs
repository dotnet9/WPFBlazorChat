using WPFBlazorChat.Core.Services;
using WPFBlazorChat.Shared.Services;
using WPFBlazorChat.WebApp.MasaExtensions;

namespace WPFBlazorChat.Helpers;

public static class IocHelper
{
    public const string IocKey = "services";

    private static ServiceCollection? _services = null;

    public static ServiceCollection GetIoc()
    {
        if (_services != null)
        {
            return _services!;
        }

        _services = new ServiceCollection();
        _services.AddMasaSetup();
        _services.AddWpfBlazorWebView();
        _services.TryAddSingleton<IUserService, UserService>();
        _services.TryAddSingleton<IWindowService, WindowService>();

        return _services!;
    }

    public static void SetIoc(this ResourceDictionary resourceDictionary, ServiceCollection services)
    {
        if (!resourceDictionary.Contains(IocKey))
        {
            resourceDictionary.Add(IocKey, services.BuildServiceProvider());
        }
    }

    public static void SetIoc(this ResourceDictionary resourceDictionary)
    {
        var service = GetIoc();
        resourceDictionary.SetIoc(service);
    }
}