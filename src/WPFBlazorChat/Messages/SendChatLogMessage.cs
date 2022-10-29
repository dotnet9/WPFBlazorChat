using WPFBlazorChat.Messagers;
using WPFBlazorChat.Models;

namespace WPFBlazorChat.Messages;

public class SendChatLogMessage : Message
{
    public ChatLog Log { get; }

    public SendChatLogMessage(object sender, ChatLog log) : base(sender)
    {
        Log = log;
    }
}