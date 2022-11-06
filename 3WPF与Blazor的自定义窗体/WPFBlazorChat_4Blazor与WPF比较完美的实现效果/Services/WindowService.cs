using System;
using System.Linq;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using Application = System.Windows.Application;

namespace WPFBlazorChat.Services;

public class WindowService
{
    private static bool _isMoving;
    private static double _startMouseX;
    private static double _startMouseY;
    private static double _startWindLeft;
    private static double _startWindTop;

    public static void Init()
    {
        DispatcherTimer dispatcherTimer = new();
        dispatcherTimer.Tick += UpdateWindowPos;
        dispatcherTimer.Interval = TimeSpan.FromMilliseconds(17);
        dispatcherTimer.Start();
    }

    public static void StartMove()
    {
        _isMoving = true;
        _startMouseX = GetX();
        _startMouseY = GetY();
        var window = GetActiveWindow();
        if (window == null)
        {
            return;
        }

        _startWindLeft = window.Left;
        _startWindTop = window.Top;
    }

    public static void StopMove()
    {
        _isMoving = false;
    }

    public static void Minimize()
    {
        var window = GetActiveWindow();
        if (window != null)
        {
            window.WindowState = WindowState.Minimized;
        }
    }

    public static void Maximize()
    {
        var window = GetActiveWindow();
        if (window != null)
        {
            window.WindowState =
                window.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }
    }


    public static bool IsMaximized()
    {
        var window = GetActiveWindow();
        if (window != null)
        {
            return window.WindowState == WindowState.Maximized;
        }

        return false;
    }

    public static void Close(bool allWindow = false)
    {
        if (allWindow)
        {
            Application.Current?.Shutdown();
            return;
        }

        var window = GetActiveWindow();
        if (window != null)
        {
            window.Close();
        }
    }


    private static void UpdateWindowPos(object? sender, EventArgs e)
    {
        if (!_isMoving)
        {
            return;
        }

        double moveX = GetX() - _startMouseX;
        double moveY = GetY() - _startMouseY;
        Window? window = GetActiveWindow();
        if (window == null)
        {
            return;
        }

        window.Left = _startWindLeft + moveX;
        window.Top = _startWindTop + moveY;
    }

    private static int GetX()
    {
        return Control.MousePosition.X;
    }

    private static int GetY()
    {
        return Control.MousePosition.Y;
    }

    private static Window? GetActiveWindow()
    {
        return Application.Current.Windows.Cast<Window>().FirstOrDefault(currentWindow => currentWindow.IsActive);
    }
}