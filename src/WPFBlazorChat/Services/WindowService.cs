using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using Application = System.Windows.Application;

namespace WPFBlazorChat.Services;

public class WindowService : IWindowService
{
    private bool _isMoving;
    private double _startMouseX;
    private double _startMouseY;
    private double _startWindLeft;
    private double _startWindTop;

    public void Init()
    {
        DispatcherTimer dispatcherTimer = new();
        dispatcherTimer.Tick += UpdateWindowPos;
        dispatcherTimer.Interval = TimeSpan.FromMicroseconds(17);
        dispatcherTimer.Start();
    }

    public void StartMove()
    {
        _isMoving = true;
        _startMouseX = GetX();
        _startMouseY = GetY();
        _startWindLeft = GetActiveWindow()!.Left;
        _startWindTop = GetActiveWindow()!.Top;
    }

    public void StopMove()
    {
        _isMoving = false;
    }

    public void Minimize()
    {
        GetActiveWindow()!.WindowState = WindowState.Minimized;
    }

    public void Maximize()
    {
        Window? window = GetActiveWindow();
        window!.WindowState = window!.WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
    }


    public bool IsMaximized()
    {
        return GetActiveWindow()!.WindowState == WindowState.Maximized;
    }

    public void Close()
    {
        GetActiveWindow()!.Close();
    }


    private void UpdateWindowPos(object? sender, EventArgs e)
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