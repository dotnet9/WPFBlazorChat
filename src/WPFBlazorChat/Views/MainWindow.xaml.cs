﻿using System.Windows;
using WPFBlazorChat.Helpers;

namespace WPFBlazorChat.Views;

public partial class MainWindow : Window
{

    public MainWindow()
    {
        Resources.SetIoc();

        InitializeComponent();


        Helpers.MouseMove.Init();
    }
}