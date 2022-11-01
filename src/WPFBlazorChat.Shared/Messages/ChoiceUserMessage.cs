using WPFBlazorChat.Core.Messagers;
using WPFBlazorChat.Shared.Models;

namespace WPFBlazorChat.Shared.Messages;

public class ChoiceUserMessage : Message
{
    public User User { get; }

    public ChoiceUserMessage(object sender, User user) : base(sender)
    {
        User = user;
    }
}