using WPFBlazorChat.Shared.Models;
using WPFBlazorChat.Core.Messagers;

namespace WPFBlazorChat.Shared.Messages;

public class OpenWeChatMessage : Message
{
    public User User { get; }

    public OpenWeChatMessage(object sender, User user) : base(sender)
    {
        User = user;
    }
}