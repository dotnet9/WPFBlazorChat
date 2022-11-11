using WPFBlazorChat.Models;

namespace WPFBlazorChat.Messagers;

internal class SendMessage : Message
{
    public UserInfo FromUser { get; }
    public string Message { get; }

    public SendMessage(object sender,UserInfo sendUser, string message) : base(sender)
    {
        FromUser = sendUser;
        Message = message;
    }
}