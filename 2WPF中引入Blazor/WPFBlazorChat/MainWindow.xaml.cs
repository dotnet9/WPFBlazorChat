﻿using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace WPFBlazorChat;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddWpfBlazorWebView();
        Resources.Add("services", serviceCollection.BuildServiceProvider());
    }
}