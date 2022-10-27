using WPFBlazorChat.Models;

namespace WPFBlazorChat.Services;
public interface IUserService
{
    List<ChatUserItem> GetUsers();
}
