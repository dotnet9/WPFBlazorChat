﻿using BlazorComponent.I18n;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Prism.Events;
using Prism.Mvvm;
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
        InitializeComponent();

        var serviceCollection = new ServiceCollection();
        serviceCollection.AddMasaBlazor();
        serviceCollection.TryAddScoped<I18n>();
        serviceCollection.TryAddScoped<CookieStorage>();
        serviceCollection.AddHttpContextAccessor();
        serviceCollection.AddWpfBlazorWebView();
        serviceCollection.TryAddSingleton<IUserService, UserService>();
        serviceCollection.AddSingleton(_eventAggregator);
        Resources.Add("services", serviceCollection.BuildServiceProvider());

        eventAggregator.GetEvent<OpenUserDialogEvent>().Subscribe(ShowUser);
    }

    private void ShowUser(ChatUserItem user)
    {
        var chatWin = new ChatWindow(_eventAggregator, user);
        chatWin.Show();
    }

    private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
    {
        this.DragMove();
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        this.Close();
    }
}