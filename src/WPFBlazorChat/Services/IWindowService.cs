namespace WPFBlazorChat.Services;

public interface IWindowService
{
    void Init();
    void StartMove();
    void StopMove();
    void Minimize();
    void Maximize();
    void Close();
}