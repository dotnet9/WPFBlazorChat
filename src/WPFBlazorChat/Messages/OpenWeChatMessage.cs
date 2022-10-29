using WPFBlazorChat.Messagers;
using WPFBlazorChat.Models;

namespace WPFBlazorChat.Messages;

public class OpenWeChatMessage : Message
{
    public User User { get; }

    public OpenWeChatMessage(object sender, User user) : base(sender)
    {
        User = user;
    }
}