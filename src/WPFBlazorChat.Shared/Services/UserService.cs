using System.Text.Json;
using WPFBlazorChat.Shared.Models;

namespace WPFBlazorChat.Shared.Services;

public class UserService : IUserService
{
    private List<User>? _users = null;

    public List<User>? GetUsers()
    {
        return _users ??= JsonSerializer.Deserialize<List<User>>(
            System.IO.File.ReadAllText($"{AppDomain.CurrentDomain.BaseDirectory}Datas/user.json"));
    }
}