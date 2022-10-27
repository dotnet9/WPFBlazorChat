using Prism.Events;
using WPFBlazorChat.Models;

namespace WPFBlazorChat.Events;
public class OpenUserDialogEvent : PubSubEvent<ChatUserItem>
{
}