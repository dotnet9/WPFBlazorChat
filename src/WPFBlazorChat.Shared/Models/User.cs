namespace WPFBlazorChat.Shared.Models;

public class User
{
    public string Id { get; set; } = null!;
    public string Avatar { get; set; } = null!;
    public string UserName { get; set; } = null!;
    public string Memo { get; set; } = null!;

    public int Type { get; set; }

    /// <summary>
    /// 如果是分组，此字段填写成员ID："1,3,5"
    /// </summary>
    public string? Members { get; set; }
}

public enum UserType
{
    User = 0,
    Group = 1
}