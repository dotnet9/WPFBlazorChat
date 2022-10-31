using WPFBlazorChat.Shared.Models;

namespace WPFBlazorChat.Shared.Services;

public interface IUserService
{
    List<User>? GetUsers();
}