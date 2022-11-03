using BlazorChat.BlazorServer.Services;
using WPFBlazorChat.Core.Services;
using WPFBlazorChat.Shared.Models;
using WPFBlazorChat.Shared.Services;
using WPFBlazorChat.WebApp.MasaExtensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddMasaSetup();

builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IWindowService, WindowService>();
builder.Services.AddSingleton(new User { Id = "2", UserName = "Ð¡ÁúÅ®" });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();