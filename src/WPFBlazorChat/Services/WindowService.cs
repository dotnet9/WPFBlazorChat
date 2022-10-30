using System.Windows;
using System.Windows.Threading;

namespace WPFBlazorChat.Services;
public class WindowService: IWindowService
{
    private bool _isMoving = false;
    private double _startMouseX = 0;
    private double _startMouseY = 0;
    private double _startWindLeft = 0;
    private double _startWindTop = 0;

    public void Init()
    {
        DispatcherTimer dispatcherTimer = new();
        dispatcherTimer.Tick += UpdateWindowPos;
        dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
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
        GetActiveWindow()!.WindowState=WindowState.Minimized;
    }

    public void Maximize()
    {
        var window = GetActiveWindow();
        if (window.WindowState == WindowState.Maximized)
        {
            window.WindowState = WindowState.Normal;
        }
        else
        {
            window.WindowState = WindowState.Maximized;
        }
    }

    public void Close()
    {
        GetActiveWindow().Close();
    }


    private void UpdateWindowPos(object? sender, EventArgs e)
    {
        if (!_isMoving)
        {
            return;
        }

        double moveX = GetX() - _startMouseX;
        double moveY = GetY() - _startMouseY;
        GetActiveWindow()!.Left = _startWindLeft + moveX;
        GetActiveWindow()!.Top = _startWindTop + moveY;
    }

    private static int GetX()
    {
        return System.Windows.Forms.Control.MousePosition.X;
    }

    private static int GetY()
    {
        return System.Windows.Forms.Control.MousePosition.Y;
    }

    private static Window? GetActiveWindow()
    {
        return Application.Current.Windows.Cast<Window>().FirstOrDefault(currentWindow => currentWindow.IsActive);
    }
}
