using WPFBlazorChat.Shared.Models;
using WPFBlazorChat.Core.Messagers;

namespace WPFBlazorChat.Shared.Messages;

public class SendChatLogMessage : Message
{
    public ChatLog Log { get; }

    public SendChatLogMessage(object sender, ChatLog log) : base(sender)
    {
        Log = log;
    }
}