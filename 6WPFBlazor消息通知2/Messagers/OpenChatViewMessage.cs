using WPFBlazorChat.Models;

namespace WPFBlazorChat.Messagers;

internal class OpenChatViewMessage:Message
{
    public UserInfo User { get; }

    public OpenChatViewMessage(object sender,UserInfo user) : base(sender)
    {
        User = user;
    }
}