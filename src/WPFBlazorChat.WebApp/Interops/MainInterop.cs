using Microsoft.JSInterop;

namespace WPFBlazorChat.WebApp.Interops;

public class MainInterop : IAsyncDisposable
{
    private readonly Lazy<Task<IJSObjectReference>> _moduleTask;

    public MainInterop(IJSRuntime js)
    {
        this._moduleTask = new Lazy<Task<IJSObjectReference>>(() =>
            js.InvokeAsync<IJSObjectReference>("import", "/js/main.js").AsTask());
    }

    public async ValueTask Init(string id)
    {
        IJSObjectReference module = await this._moduleTask.Value;

        await module.InvokeVoidAsync("init", id);
    }

    public async ValueTask DisposeAsync()
    {
        if (!this._moduleTask.IsValueCreated)
            return;
        IJSObjectReference module = await this._moduleTask.Value;
        try
        {
            await module.DisposeAsync();
        }
        catch
        {
        }
    }
}