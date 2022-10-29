using System.Windows;
using System.Windows.Threading;

namespace WPFBlazorChat.Helpers;

public static class MouseMove
{
    private static bool isMoving = false;

    private static double startMouseX = 0;
    private static double startMouseY = 0;
    private static double startWindLeft = 0;
    private static double startWindTop = 0;

    public static void Init()
    {
        DispatcherTimer dispatcherTimer = new();
        dispatcherTimer.Tick += UpdateWindowPos;
        dispatcherTimer.Interval = new TimeSpan(0, 0, 0, 0, 50);
        dispatcherTimer.Start();
    }

    public static void StartMove()
    {
        isMoving = true;
        startMouseX = GetX();
        startMouseY = GetY();
        startWindLeft = GetActiveWindow().Left;
        startWindTop = GetActiveWindow().Top;
    }

    public static void EndMove()
    {
        isMoving = false;
    }

    public static void UpdateWindowPos(object sender, EventArgs e)
    {
        if (isMoving)
        {
            double moveX = GetX() - startMouseX;
            double moveY = GetY() - startMouseY;
            GetActiveWindow().Left = startWindLeft + moveX;
            GetActiveWindow().Top = startWindTop + moveY;
        }
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