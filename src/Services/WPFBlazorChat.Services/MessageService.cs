using WPFBlazorChat.Services.Interfaces;

namespace WPFBlazorChat.Services;
public class MessageService : IMessageService
{
    public string GetMessage()
    {
        return "Hello from the Message Service";
    }
}
