namespace WPFBlazorChat.Core.Services;

public interface IWindowService
{
    void Init();
    void StartMove();
    void StopMove();
    void Minimize();
    void Maximize();
    bool IsMaximized();
    void Close(bool allWindow = false);
}