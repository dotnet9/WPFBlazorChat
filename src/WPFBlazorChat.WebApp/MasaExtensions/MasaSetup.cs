using BlazorComponent.I18n;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WPFBlazorChat.WebApp.MasaExtensions;

public static class MasaSetup
{
    public static void AddMasaSetup(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddMasaBlazor();
        services.TryAddScoped<I18n>();
        services.TryAddScoped<CookieStorage>();
        services.AddHttpContextAccessor();
    }
}