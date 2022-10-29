using WPFBlazorChat.Models;

namespace WPFBlazorChat.Services;
public interface IUserService
{
    List<User>? GetUsers();
}
