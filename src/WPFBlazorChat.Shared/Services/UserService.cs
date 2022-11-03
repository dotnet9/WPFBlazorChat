using System.Text;
using System.Text.Json;
using WPFBlazorChat.Shared.Models;

namespace WPFBlazorChat.Shared.Services;

public class UserService : IUserService
{
    private List<User>? _users = null;

    public List<User> GetUsers()
    {
        if (_users is { Count: > 0 })
        {
            return _users;
        }

        using var stream = new MemoryStream(Resources.users);
        using var reader = new StreamReader(stream, Encoding.UTF8);
        return _users ??= JsonSerializer.Deserialize<List<User>>(stream)!;
    }
}